
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.MODELS.CRM;
using libERP.MODELS.INVENTORY_ITEMS;
using libERP.SERVICES.ADMIN;
using libERP.SERVICES.COMMON;
using libERP.SERVICES.HR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace libERP.SERVICES.MASTER
{
    public class ServiceInventoryItems : DefaultService
    {
        public ServiceInventoryItems(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceInventoryItems()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }
                
        #region INVENTORY CATEGORY
        public List<SelectListItem> GetInventoryCategories()
        {
            string strSQL = "select Pk_InvCategory_ID as ID, Inv_Category +' ('+Category_ShortCode+')' as Description,B.Admin_UserList_Desc as Code,A.IsActive ";
            strSQL += "from[dbo].[TBL_MP_Master_Inventory_Category] A ";
            strSQL += "left join TBL_MP_Admin_UserList B ON A.FK_Userlist_ItemType_ID = B.PKID ";
            strSQL += "order by 2 ";
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = _dbContext.Database.SqlQuery<SelectListItem>(strSQL).ToList();
                foreach (SelectListItem item in lst)
                {
                    item.Description = string.Format("{0} - {1}", item.Description, item.Code);
                }
                lst= lst.OrderBy(X => X.Description).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public TBL_MP_Master_Inventory_Category GetInventoryCategoriesDBItem(int CategoryID)
        {
            TBL_MP_Master_Inventory_Category model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Inventory_Category.Where(x => x.Pk_InvCategory_ID == CategoryID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryCategoriesDBItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public int AddNewInventoryCategory(TBL_MP_Master_Inventory_Category objCategory)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Inventory_Category.Add(objCategory);
                _dbContext.SaveChanges();
                newID = objCategory.Pk_InvCategory_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::AddNewInventoryCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateInventoryCategory(TBL_MP_Master_Inventory_Category objCategory)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Inventory_Category editCategory = _dbContext.TBL_MP_Master_Inventory_Category.Where(x => x.Pk_InvCategory_ID == objCategory.Pk_InvCategory_ID).FirstOrDefault();
                editCategory.Inv_Category = objCategory.Inv_Category;
                editCategory.Category_ShortCode = objCategory.Category_ShortCode;
                editCategory.Category_Description = objCategory.Category_Description;
                editCategory.FK_BranchID = objCategory.FK_BranchID;
                editCategory.FK_CompanyID = objCategory.FK_CompanyID;
                editCategory.FK_Userlist_ItemType_ID = objCategory.FK_Userlist_ItemType_ID;
                editCategory.IsActive = objCategory.IsActive;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::UpdateInventoryCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public string GetInventoryCategoryNameForCategoryID(int invCategoryID)
        {
            string categoryName = string.Empty;
            try
            {
                TBL_MP_Master_Inventory_Category dbCategory = _dbContext.TBL_MP_Master_Inventory_Category.Where(x => x.Pk_InvCategory_ID == invCategoryID).FirstOrDefault();
                if (dbCategory != null)
                {
                    categoryName = string.Format("{0} ({1})", dbCategory.Inv_Category, dbCategory.Category_ShortCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryCategoryNameForCategoryID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return categoryName;
        }

        public int GetItemTypeIDforInventoryCategory(int invCategoryID)
        {
            int itemTypeID = 0;
            try
            {
                TBL_MP_Master_Inventory_Category dbCategory = _dbContext.TBL_MP_Master_Inventory_Category.Where(x => x.Pk_InvCategory_ID == invCategoryID).FirstOrDefault();
                if (dbCategory != null)
                {
                    itemTypeID = (int)dbCategory.FK_Userlist_ItemType_ID;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetItemTypeIDforInventoryCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return itemTypeID;
        }
        public List<SelectListItem> GetInventoryCategoriesOfItemType(int itemTypeID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                lst = (from xx in _dbContext.TBL_MP_Master_Inventory_Category
                       where xx.IsActive == true && xx.FK_Userlist_ItemType_ID == itemTypeID
                       orderby xx.Category_Description
                       select new SelectListItem()
                       {
                           Code = xx.HSNCode,
                           ID = xx.Pk_InvCategory_ID,
                           Description = xx.Inv_Category
                       }
                       ).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryCategoriesOfItemType", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetInventoryItemTypes()
        {
            //string strSQL = "select Pk_InvCategory_ID as ID, Inv_Category as Description,B.Admin_UserList_Desc as Code ";
            //strSQL += "from[dbo].[TBL_MP_Master_Inventory_Category] A ";
            //strSQL += "left join TBL_MP_Admin_UserList B ON A.FK_Userlist_ItemType_ID = B.PKID ";
            //strSQL += "order by 2 ";
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                int ItemTypeCategoryID = (new ServiceAppDefaults()).GetAllApplicationDefaultSettings().Where(x=>x.ID==(int)APP_DEFAULT_VALUES.ItemTypeCategoryID).FirstOrDefault().DEFAULT_VALUE;
                lst = (
                    from xx in _dbContext.TBL_MP_Admin_UserList
                    where xx.IsActive == true && xx.Fk_Admin_CategoryID == ItemTypeCategoryID
                    orderby xx.Admin_UserList_Desc
                    select new SelectListItem()
                    {
                        ID = xx.PKID,
                        Description = xx.Admin_UserList_Desc,
                        Code = xx.ShortCode
                    }
                      ).ToList();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemTypes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        #endregion

        #region INVENTORY LEVEL AND DETAILS
        public List<SelectListItem> GetInventoryLevelSelectlistItemsForCategories(int invCategoryID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            string strDescription = string.Empty;
            try
            {
                List<TBL_MP_Master_Inventory_Level> dbLevels = this.GetAllInventoryLevelsForCategory(invCategoryID);
                foreach (TBL_MP_Master_Inventory_Level item in dbLevels)
                {
                    strDescription = string.Format("{0}\n", item.Inventory_Level);
                    List<TBL_MP_Master_Inventory_Level_Details> dbLevelValues = this.GetAllLevelDetailsForInventoryLevel(item.Pk_Inv_Level_ID);
                    foreach (TBL_MP_Master_Inventory_Level_Details itemDetails in dbLevelValues)
                    {
                        strDescription += itemDetails.Inv_Level_Description + ", ";
                    }
                    strDescription = strDescription.TrimEnd(' ').TrimEnd(',');

                    SelectListItem selItem = new SelectListItem()
                    {
                        ID = item.Pk_Inv_Level_ID,
                        Description = strDescription,
                        Code = item.Sequence.ToString()
                    };
                    lst.Add(selItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryLevelSelectlistItemsForCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<SelectListItem> GetInventoryLevelValuesForInventoryLevel(int invLevelID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { ID = 0, Description = "(Select)" });
            string strDescription = string.Empty;
            try
            {
                List<TBL_MP_Master_Inventory_Level_Details> dbLevelValues = this.GetAllLevelDetailsForInventoryLevel(invLevelID);
                foreach (TBL_MP_Master_Inventory_Level_Details itemDetails in dbLevelValues)
                {
                    SelectListItem selItem = new SelectListItem()
                    {
                        ID = itemDetails.Pk_InvLevel_Dtls_ID,
                        Description = itemDetails.Inv_Level_Value
                    };
                    lst.Add(selItem);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryLevelValuesForInventoryLevel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<InventoryItemSpecificationModel> GetInventoryItemSpecificationModelForItemCategory(int invCategoryID)
        {
            List<InventoryItemSpecificationModel> lst = new List<InventoryItemSpecificationModel>();
            string strDescription = string.Empty;
            try
            {
                List<TBL_MP_Master_Inventory_Level> dbLevels = this.GetAllInventoryLevelsForCategory(invCategoryID).OrderBy(x => x.Sequence).ToList();
                foreach (TBL_MP_Master_Inventory_Level item in dbLevels)
                {
                    //strDescription = string.Format("{0}", item.Inventory_Level);

                    InventoryItemSpecificationModel selItem = new InventoryItemSpecificationModel()
                    {
                        InventoryLevelID = item.Pk_Inv_Level_ID,
                        InventoryLevelDescription = item.Inventory_Level.ToString()
                    };
                    lst.Add(selItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryLevelSelectlistItemsForCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<InventoryItemSpecificationModel> GetInventoryLevelWithValuesForInventoryItem(int itemID)
        {
            List<InventoryItemSpecificationModel> lstItems = new List<InventoryItemSpecificationModel>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("select ");
                sb.AppendLine("A.Pk_Item_Inv_Level_DetailsID as PKSpecificationID,");
                sb.AppendLine("B.Fk_Inv_Level_ID as InventoryLevelID,");
                sb.AppendLine("c.Inventory_Level as InventoryLevelDescription,");
                sb.AppendLine("A.Fk_InvLevel_Dtls_ID as InventoryLevelValueID,");
                sb.AppendLine("B.Inv_Level_Value as InventoryLevelValueDescription ");
                sb.AppendLine("from[dbo].[TBL_MP_Master_Item_InvLevel_Details] A ");
                sb.AppendLine("left join[dbo].[TBL_MP_Master_Inventory_Level_Details] B on a.Fk_InvLevel_Dtls_ID = B.Pk_InvLevel_Dtls_ID ");
                sb.AppendLine("left join[dbo].[TBL_MP_Master_Inventory_Level] C on B.Fk_Inv_Level_ID = C.Pk_Inv_Level_ID ");
                sb.AppendLine("where a.Fk_ItemID=" + itemID.ToString());
                string strQuery = sb.ToString();
                lstItems = _dbContext.Database.SqlQuery<InventoryItemSpecificationModel>(strQuery).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryLevelWithValuesForInventoryItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstItems;
        }
        public List<InventoryLevelModel> GetInventoryLevelWithDetailsForCategory(int categoryID)
        {
            List<InventoryLevelModel> lstLevels = new List<InventoryLevelModel>();
            try
            {
                List<TBL_MP_Master_Inventory_Level> dbLevels = this.GetAllInventoryLevelsForCategory(categoryID);
                foreach (TBL_MP_Master_Inventory_Level item in dbLevels)
                {
                    InventoryLevelModel model = new InventoryLevelModel()
                    {
                        CategoryID = categoryID,
                        InventoryLevelID = item.Pk_Inv_Level_ID,
                        InventoryLevelName = item.Inventory_Level,
                        Sequence = (int)item.Sequence
                    };
                    model.VALUES = new List<InventoryLevelDetailModel>();
                    List<TBL_MP_Master_Inventory_Level_Details> dbLevelValues = this.GetAllLevelDetailsForInventoryLevel(item.Pk_Inv_Level_ID);
                    foreach (TBL_MP_Master_Inventory_Level_Details itemDetails in dbLevelValues)
                    {
                        InventoryLevelDetailModel detail = new InventoryLevelDetailModel()
                        {
                            InventoryLevelID = item.Pk_Inv_Level_ID,
                            InventoryLevelDetailID = itemDetails.Pk_InvLevel_Dtls_ID,
                            InventoryLevelDetailName = itemDetails.Inv_Level_Value
                        };
                        model.VALUES.Add(detail);
                    }
                    lstLevels.Add(model);
                }
                lstLevels.OrderBy(X => X.Sequence);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryLevelWithDetailsForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstLevels;
        }
        public int GetGetNextSequenceNumberOfInventoryLevelForCategory(int categoryID)
        {
            int sequenceNo = 1;
            try
            {
                List<TBL_MP_Master_Inventory_Level> dbLevels = this.GetAllInventoryLevelsForCategory(categoryID);
                if (dbLevels.Count == 0)
                    sequenceNo = 1;
                else
                    sequenceNo = ((int)dbLevels.Max(x => x.Sequence)) + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetGetNextSequenceNumberOfInventoryLevelForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sequenceNo;
        }
        public List<InventoryItemModel> GetInventoryItemModelListForCategory(int invCategoryID)
        {
            List<InventoryItemModel> lstItems = null;
            try
            {
                //GET ALL INVENTORY ITEMS FROM THE DATABASE 
                lstItems = (from xx in _dbContext.TBL_MP_Master_Item.AsEnumerable()
                            where xx.Fk_InvCategory_ID == invCategoryID
                            select new InventoryItemModel()
                            {
                                ItemID = xx.Pk_ItemID,
                                ItemCode = xx.ItemCode,
                                HSNCode = xx.HSNCode,
                                ItemName = xx.Item_Name + "\n" +  xx.Long_Description+ "\n"+xx.PartNumber,
                                UOMID = (int)xx.Fk_UserList_BaseUOM_ID,
                                IsAssembly = (bool)xx.IsAssembly,
                                IsActive=(bool) xx.IsActive
                            }
                           ).ToList();
                //POPULATE LIST COLLECTION OF AAL UOM
                List<SelectListItem> listUOMs = (new ServiceMASTERS()).GetAllUOMs();
                //ASSIGN UOM NAME TO EACH ITEM
                foreach (InventoryItemModel item in lstItems)
                {
                    SelectListItem selUOM = listUOMs.Where(x => x.ID == item.UOMID).FirstOrDefault();
                    if (selUOM != null)
                    {
                        item.UOMName = selUOM.Description;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemModelListForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstItems;
        }
        public List<MultiSelectListItem> GetMultiSelectInventoryItemListForCategory(int invCategoryID)
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {
                //GET ALL INVENTORY ITEMS FROM THE DATABASE 
                List<TBL_MP_Master_Item> lstItems= (from xx in _dbContext.TBL_MP_Master_Item where xx.Fk_InvCategory_ID == invCategoryID && xx.IsActive == true select xx).ToList();
                foreach (TBL_MP_Master_Item xx in lstItems)
                {
                    MultiSelectListItem selItem = new MultiSelectListItem() {
                        ID = xx.Pk_ItemID,
                        Code = xx.ItemCode,
                        Selected = false,
                        EntityType = APP_ENTITIES.INVENTORY_ITEMS_LIST
                    };
                    selItem.Description = string.Format("{0} {1}\nCODE: {2} HSN:{3}", xx.Item_Name, xx.Long_Description, xx.ItemCode, xx.HSNCode);
                    list.Add(selItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetMultiSelectInventoryItemListForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<MultiSelectListItem> GetNonAssemblyMultiSelectInventoryItemListForCategory(int invCategoryID)
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {
                //GET ALL INVENTORY ITEMS FROM THE DATABASE 
                List<TBL_MP_Master_Item> lstItems = (from xx in _dbContext.TBL_MP_Master_Item where xx.Fk_InvCategory_ID == invCategoryID && xx.IsActive == true && xx.IsAssembly==false  select xx).ToList();
                foreach (TBL_MP_Master_Item xx in lstItems)
                {
                    MultiSelectListItem selItem = new MultiSelectListItem()
                    {
                        ID = xx.Pk_ItemID,
                        Code = xx.ItemCode,
                        Selected = false,
                        EntityType = APP_ENTITIES.INVENTORY_ITEMS_LIST
                    };
                    selItem.Description = string.Format("{0} {1}\nCODE: {2} HSN:{3}", xx.Item_Name, xx.Long_Description, xx.ItemCode, xx.HSNCode);
                    list.Add(selItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetNonAssemblyMultiSelectInventoryItemListForCategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<MultiSelectListItem> GetInventoryItemsForCategoriesMultiselect(int invCategoryID)
        {
            List<MultiSelectListItem> lst = new List<MultiSelectListItem>();
            try
            {
                List<TBL_MP_Master_Item> dbList = _dbContext.TBL_MP_Master_Item.Where(x => x.Fk_InvCategory_ID == invCategoryID).ToList();
                foreach (TBL_MP_Master_Item item in dbList)
                {
                    MultiSelectListItem selItem = new MultiSelectListItem()
                    {
                        ID = item.Pk_ItemID,
                        Selected = false,
                        EntityType = APP_ENTITIES.INVENTORY_ITEMS_LIST,
                        Description = string.Format("{0}\n{1}", item.Item_Name,item.Long_Description),
                        Code = item.ItemCode
                    };
                    lst.Add(selItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemsForCategoriesMultiselect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<EnquiryBOQItem> GetInventoryItemsForMultiselectInBOQ(int invCategoryID)
        {
            List<EnquiryBOQItem> lst = new List<EnquiryBOQItem>();
            try
            {
                List<TBL_MP_Master_Item> dbList = _dbContext.TBL_MP_Master_Item.Where(x => x.Fk_InvCategory_ID == invCategoryID).ToList();
                foreach (TBL_MP_Master_Item item in dbList)
                {
                    EnquiryBOQItem selItem = new EnquiryBOQItem()
                    {
                        ID = item.Pk_ItemID,
                        Selected = false,
                        Description = string.Format("{0}\n{1}\nCODE: {2}  HSN:{3}", item.Item_Name, item.Long_Description, item.ItemCode, item.HSNCode)
                    };
                    lst.Add(selItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemsForMultiselectInBOQ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public List<TBL_MP_Master_Inventory_Level> GetAllInventoryLevelsForCategory(int invCayegoryID)
        {
            return _dbContext.TBL_MP_Master_Inventory_Level.Where(x => x.Fk_InvCategory_ID == invCayegoryID).Where(x => x.IsActive == true).OrderBy(x=>x.Sequence).ToList();
        }
        public TBL_MP_Master_Inventory_Level GetInventoryLevelDBItem(int levelID)
        {
            return _dbContext.TBL_MP_Master_Inventory_Level.Where(x => x.Pk_Inv_Level_ID == levelID).FirstOrDefault();
        }
        public TBL_MP_Master_Inventory_Level_Details GetInventoryLevelDetailDBItem(int levelDetailID)
        {
            return _dbContext.TBL_MP_Master_Inventory_Level_Details.Where(x => x.Pk_InvLevel_Dtls_ID == levelDetailID && x.IsActive == true).FirstOrDefault();
        }
        public List<TBL_MP_Master_Inventory_Level_Details> GetAllLevelDetailsForInventoryLevel(int invLevelID)
        {
            return _dbContext.TBL_MP_Master_Inventory_Level_Details.Where(x => x.Fk_Inv_Level_ID == invLevelID && x.IsActive==true).OrderBy(x=>x.Inv_Level_Value).ToList();
        }
        public int AddNewInventoryLevel(TBL_MP_Master_Inventory_Level newLevel)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Inventory_Level.Add(newLevel);
                _dbContext.SaveChanges();
                newID = newLevel.Pk_Inv_Level_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::AddNewInventoryLevel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateInventoryLevel(TBL_MP_Master_Inventory_Level level)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Inventory_Level dbLevel = this.GetInventoryLevelDBItem(level.Pk_Inv_Level_ID);
                dbLevel.Fk_InvCategory_ID = level.Fk_InvCategory_ID;
                dbLevel.Inventory_Level = level.Inventory_Level;
                dbLevel.Sequence = level.Sequence;
                _dbContext.SaveChanges();
                result = true;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::UpdateInventoryLevel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public int AddNewInventoryLevelDetail(TBL_MP_Master_Inventory_Level_Details newDetail)
        {
            int newID = 0;
            try
            {
                _dbContext.TBL_MP_Master_Inventory_Level_Details.Add(newDetail);
                _dbContext.SaveChanges();
                newID = newDetail.Pk_InvLevel_Dtls_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::AddNewInventoryLevelDetail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateInventoryLevelDetail(TBL_MP_Master_Inventory_Level_Details level)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Inventory_Level_Details dbLevel = this.GetInventoryLevelDetailDBItem(level.Pk_InvLevel_Dtls_ID);
                dbLevel.Fk_Inv_Level_ID = level.Fk_Inv_Level_ID;
                dbLevel.Inv_Level_Description = level.Inv_Level_Description; 
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::UpdateInventoryLevelDetail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
          #endregion

        #region INVENTORY ITEM
        public List<SelectListItem> GetInventoryItemsForCategories(int invCategoryID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_Item> dbList = _dbContext.TBL_MP_Master_Item.Where(x => x.Fk_InvCategory_ID == invCategoryID).ToList();
                foreach (TBL_MP_Master_Item item in dbList)
                {
                    SelectListItem selItem = new SelectListItem()
                    {
                        ID = item.Pk_ItemID,
                        Description = string.Format("{0}\nCode:{1}\n", item.Item_Name, item.ItemCode),
                        Code = item.ItemCode
                    };
                    lst.Add(selItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemsForCategories", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lst;
        }
        public string GenerateNewInventoryItemCode(int catID)
        {
            string newCode = string.Empty;
            string itemTypeShortCode = string.Empty;
            string itemCategoryShortCode = string.Empty;

            try
            {
                
                TBL_MP_Master_Inventory_Category dbCategory = _dbContext.TBL_MP_Master_Inventory_Category.Where(x => x.Pk_InvCategory_ID == catID).FirstOrDefault();
                TBL_MP_Admin_UserList dbUserListItem = _dbContext.TBL_MP_Admin_UserList.Where(x => x.PKID == dbCategory.FK_Userlist_ItemType_ID).FirstOrDefault();

                int itemCount = _dbContext.TBL_MP_Master_Item.Where(x => x.Fk_InvCategory_ID == catID).Count();
                if (dbCategory != null) itemCategoryShortCode = dbCategory.Category_ShortCode;
                if (dbUserListItem != null) itemTypeShortCode = dbUserListItem.ShortCode;
                itemCount++;
                newCode = string.Format("{0}{1}{2}", itemCategoryShortCode, itemCount.ToString().PadLeft(4, '0'), itemTypeShortCode);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GenerateNewInventoryItemCode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newCode;
        }
        public List<MultiSelectListItem> GetAllInventoryItemsMultiSelect()
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            List<TBL_MP_Master_Item> dbServices = _dbContext.TBL_MP_Master_Item.Where(x=>x.IsActive==true).ToList();
            try
            {
                foreach (TBL_MP_Master_Item dbItem in dbServices)
                {
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Selected = false,
                        ID = dbItem.Pk_ItemID,
                        Description = dbItem.Item_Name,
                        Code = dbItem.ItemCode,
                        EntityType = APP_ENTITIES.INVENTORY_ITEMS_LIST
                    };
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllInventoryItemsMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public List<MultiSelectListItem> GetAllInventoryItemsMultiSelectHavingPattern(string searchPattern)
        {
            List<MultiSelectListItem> list = new List<MultiSelectListItem>();
            try
            {

                string strQuery = string.Format("select * from TBL_MP_Master_Item WHERE UPPER(ITEM_NAME) LIKE '%{0}%'", searchPattern.ToUpper());
                List<TBL_MP_Master_Item> dbServices = _dbContext.Database.SqlQuery<TBL_MP_Master_Item>(strQuery).ToList();
                List<SelectListItem> lstUnits = (new ServiceMASTERS()).GetAllUOMs();
                foreach (TBL_MP_Master_Item dbItem in dbServices)
                {
                    string strUOM = string.Empty;
                    SelectListItem selUOM = lstUnits.Where(x => x.ID == dbItem.Fk_UserList_BaseUOM_ID).FirstOrDefault();
                    if (selUOM != null) strUOM = selUOM.Description;
                    MultiSelectListItem item = new MultiSelectListItem()
                    {
                        Selected = false,
                        ID = dbItem.Pk_ItemID,
                        Description = string.Format("{0}\nUOM: {1}", dbItem.Item_Name, strUOM),
                        Code = dbItem.ItemCode,
                        EntityType = APP_ENTITIES.INVENTORY_ITEMS_LIST
                    };
                    list.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceMASTERS::GetAllInventoryItemsMultiSelect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
        public TBL_MP_Master_Item GetItemDBRecord(int itemID)
        {
            TBL_MP_Master_Item model = null;
            try
            {
                model = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == itemID).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetItemDBRecord", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return model;
        }
        public void UpdateItemImageFileName(int itemID, string strsourceFile)
        {
            string fName = string.Empty;
            TBL_MP_Master_Item dbItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == itemID).FirstOrDefault();
            if (dbItem != null)
            {

                if (dbItem.ImageFileName != null)
                    fName = dbItem.ImageFileName.ToString();
                else
                    fName = (new AppCommon()).GetUniqueFileName(strsourceFile);


                string serverPath = AppCommon.GetInventoryItemImagePath();
                string newFilePath = string.Format("{0}{1}", serverPath, fName);
                //saving file with a newly generate name on server
                File.Copy(strsourceFile, newFilePath, true);
                dbItem.ImageFileName = fName;
                _dbContext.SaveChanges();
            }

        }
        public int AddNewInventoryItemMasterInfo(TBL_MP_Master_Item item)
        {
            int newID = 0;
            try
            {
               
                TBL_MP_Master_Item newItem = new TBL_MP_Master_Item();
                newItem.CreatedDatetime = AppCommon.GetServerDateTime();
                newItem.CreatedBy  = item.CreatedBy;
                newItem.FK_BranchID = item.FK_BranchID;
                newItem.FK_YearID = item.FK_YearID;
                newItem.Fk_InvCategory_ID = item.Fk_InvCategory_ID;
                newItem.Fk_UserList_ItemType_ID = item.Fk_UserList_ItemType_ID;
                newItem.Fk_UserList_BaseUOM_ID = item.Fk_UserList_BaseUOM_ID;
                newItem.Fk_UserList_PurchaseUOM_ID = item.Fk_UserList_PurchaseUOM_ID;
                newItem.ItemCode = this.GenerateNewInventoryItemCode((int)item.Fk_InvCategory_ID);
                newItem.Item_Name = item.Item_Name;
                newItem.HSNCode = item.HSNCode;
                newItem.PartNumber = item.PartNumber;
                newItem.Long_Description = item.Long_Description;
                newItem.IsActive = true;
                newItem.IsAssembly = item.IsAssembly;
                _dbContext.TBL_MP_Master_Item.Add(newItem);
                _dbContext.SaveChanges();
                newID = newItem.Pk_ItemID;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceInventoryItem::AddNewInventoryItemMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateInventoryItemMasterInfo(TBL_MP_Master_Item item)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Item editItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == item.Pk_ItemID).FirstOrDefault();
                editItem.LastModifiedDate = AppCommon.GetServerDateTime();
                editItem.LastModifiedBy = item.LastModifiedBy;
                editItem.HSNCode = item.HSNCode;
                editItem.PartNumber = item.PartNumber;
                editItem.Fk_InvCategory_ID = item.Fk_InvCategory_ID;
                editItem.Fk_UserList_ItemType_ID = item.Fk_UserList_ItemType_ID;
                editItem.Fk_UserList_BaseUOM_ID = item.Fk_UserList_BaseUOM_ID;
                editItem.Fk_UserList_PurchaseUOM_ID = item.Fk_UserList_PurchaseUOM_ID;
                editItem.Item_Name = item.Item_Name;
                editItem.Long_Description = item.Long_Description;
                editItem.IsAssembly = item.IsAssembly;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += "\n" + ex.InnerException.Message;
                MessageBox.Show(errMessage, "ServiceInventoryItem::UpdateInventoryItemMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteInventoryItemMasterInfo(int itemID,string reason, int deletedBY)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Item editItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == itemID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = deletedBY;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceInventoryItem::DeleteInventoryItemMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteInventoryItemMasterInfo(int itemID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Item editItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == itemID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceInventoryItem::UndeleteInventoryItemMasterInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public void UpdateInventoryItemSpecifications(List<InventoryItemSpecificationModel> lstItemSpecifications, int ItemID)
        {
            TBL_MP_Master_Item_InvLevel_Details dbItemInventory = null;
            try
            {
                string uniqueString = string.Empty;

                foreach (InventoryItemSpecificationModel model in lstItemSpecifications)
                {
                    uniqueString += string.Format("{0}|", model.InventoryLevelValueID);
                    if (model.PKSpecificationID == 0 && model.InventoryLevelValueID != 0)
                    {
                        dbItemInventory = new TBL_MP_Master_Item_InvLevel_Details();
                        dbItemInventory.Fk_InvLevel_Dtls_ID = model.InventoryLevelValueID;
                        dbItemInventory.Fk_ItemID = ItemID;
                        _dbContext.TBL_MP_Master_Item_InvLevel_Details.Add(dbItemInventory);
                        _dbContext.SaveChanges();
                        model.PKSpecificationID = dbItemInventory.Pk_Item_Inv_Level_DetailsID;
                    }
                    else
                    {
                        dbItemInventory = _dbContext.TBL_MP_Master_Item_InvLevel_Details.Where(x => x.Pk_Item_Inv_Level_DetailsID == model.PKSpecificationID).FirstOrDefault();
                        if (dbItemInventory != null)
                        {
                            dbItemInventory.Fk_InvLevel_Dtls_ID = model.InventoryLevelValueID;
                            dbItemInventory.Fk_ItemID = ItemID;
                            _dbContext.SaveChanges();
                        }
                    }
                    TBL_MP_Master_Item dbItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == ItemID).FirstOrDefault();
                    if (dbItem != null)
                    {
                        dbItem.UniqueString = uniqueString;
                        _dbContext.SaveChanges();
                    }
                    

                }

                List<TBL_MP_Master_Item_InvLevel_Details> delItems = (from spec in _dbContext.TBL_MP_Master_Item_InvLevel_Details
                                                                      where spec.Fk_ItemID == ItemID && spec.Fk_InvLevel_Dtls_ID == 0
                                                                      select spec).ToList();
                _dbContext.TBL_MP_Master_Item_InvLevel_Details.RemoveRange(delItems);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItem::UpdateInventoryItemSpecifications", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ASSEMBLY ITEMS
        public List<AssemblyParentItem> GetInventoryItemListForAssembly(int invItemID)
        {
            List<AssemblyParentItem> lstModels = new List<AssemblyParentItem>();
            try
            {
                //POPULATE LIST COLLECTION OF AAL UOM
                //List<SelectListItem> listUOMs = (new ServiceMASTERS()).GetAllUOMs();
                
                //GET ALL CHILD  ITEMS OF THE INVENTORY ITEM
                List<TBL_MP_Master_Item_AssemblyChildItems> lstChildItems = (from xx in _dbContext.TBL_MP_Master_Item_AssemblyChildItems where xx.AssemblyItemID == invItemID select xx ).ToList();
                foreach (TBL_MP_Master_Item_AssemblyChildItems dbItem in lstChildItems)
                {
                    TBL_MP_Master_Item childItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == dbItem.AssemblyChildItemID).FirstOrDefault();
                    AssemblyParentItem item = new AssemblyParentItem();
                    item.ItemID = dbItem.AssemblyChildItemID;
                    item.Selected = false;
                    if(dbItem.DefaultQty!=null)
                        item.DefaultQTY = (decimal)dbItem.DefaultQty;
                    item.ItemDescription = string.Format("{0}\n{1}\nPART NO: {2}\nCODE:{3} HSN: {4}  UOM:{5}", 
                        childItem.Item_Name, childItem.Long_Description, childItem.PartNumber, childItem.ItemCode, childItem.HSNCode,"");
                    lstModels.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetInventoryItemListForAssembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModels;
        }
        public void UpdateAssemblyChildItems(int assemblyItemID, BindingList<AssemblyParentItem> assemblyItems)
        {
            try
            {
                //ADD EDIT ASSEMBLY CHILD ITEMS
                foreach (AssemblyParentItem item in assemblyItems)
                {
                    TBL_MP_Master_Item_AssemblyChildItems dbItem = (from xx in _dbContext.TBL_MP_Master_Item_AssemblyChildItems
                                                                    where xx.AssemblyItemID == assemblyItemID && xx.AssemblyChildItemID == item.ItemID
                                                                    select xx
                                                                     ).FirstOrDefault();
                    if (dbItem == null)
                    {
                        dbItem = new TBL_MP_Master_Item_AssemblyChildItems()
                        {
                            AssemblyItemID = assemblyItemID,
                            AssemblyChildItemID = item.ItemID,
                            DefaultQty = item.DefaultQTY
                        };
                        _dbContext.TBL_MP_Master_Item_AssemblyChildItems.Add(dbItem);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        dbItem.DefaultQty = item.DefaultQTY;
                        _dbContext.SaveChanges();
                    }
                }
                //DELETE ALL ITEMS THAT DO NOT EXISTS IN ASSEBLYITEMS COLLECTION
                List<TBL_MP_Master_Item_AssemblyChildItems> dbItems = _dbContext.TBL_MP_Master_Item_AssemblyChildItems.Where(x => x.AssemblyItemID == assemblyItemID).ToList();
                string childItemsToDelete = string.Empty;
                foreach (TBL_MP_Master_Item_AssemblyChildItems dbitem in dbItems)
                {
                    AssemblyParentItem item = assemblyItems.Where(x => x.ItemID == dbitem.AssemblyChildItemID).FirstOrDefault();
                    if (item == null)
                    {
                        childItemsToDelete += string.Format("{0}{1}", dbitem.PK_AssemblyChildID, DefaultStringSeperator);
                    }
                }
                if (childItemsToDelete == string.Empty)
                    return;

                childItemsToDelete = childItemsToDelete.TrimEnd(DefaultStringSeperator);
                string[] arrDelete = childItemsToDelete.Split(DefaultStringSeperator);
                foreach (string strID in arrDelete)
                {
                    int mID = int.Parse(strID);
                    TBL_MP_Master_Item_AssemblyChildItems dbItem = _dbContext.TBL_MP_Master_Item_AssemblyChildItems.Where(x=>x.PK_AssemblyChildID==mID).FirstOrDefault();
                    if(dbItem!=null)
                    {
                        _dbContext.TBL_MP_Master_Item_AssemblyChildItems.Remove(dbItem);
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::UpdateAssemblyChildItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public decimal GetDefaultQuantityofItemInAssembly(int assemblyItemID, int childItemID)
        {
            decimal Qty = 0;
            try
            {
                TBL_MP_Master_Item_AssemblyChildItems dbItem= (from xx in _dbContext.TBL_MP_Master_Item_AssemblyChildItems where xx.AssemblyItemID == assemblyItemID && xx.AssemblyChildItemID == childItemID select xx).FirstOrDefault();
                if (dbItem != null) Qty = (decimal)dbItem.DefaultQty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetDefaultQuantityofItemInAssembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Qty;
        }
        public BindingList<MultiSelectListItem> GetMultiselectInventoryItemListForAssembly(int ItemID)
        {
            BindingList<MultiSelectListItem> lstModels = new BindingList<MultiSelectListItem>();
            try
            {
                //POPULATE LIST COLLECTION OF AAL UOM
                //List<SelectListItem> listUOMs = (new ServiceMASTERS()).GetAllUOMs();

                //GET ALL CHILD  ITEMS OF THE INVENTORY ITEM
                List<TBL_MP_Master_Item_AssemblyChildItems> lstChildItems = (from xx in _dbContext.TBL_MP_Master_Item_AssemblyChildItems where xx.AssemblyItemID == ItemID select xx).ToList();
                foreach (TBL_MP_Master_Item_AssemblyChildItems dbItem in lstChildItems)
                {
                    TBL_MP_Master_Item childItem = _dbContext.TBL_MP_Master_Item.Where(x => x.Pk_ItemID == dbItem.AssemblyChildItemID).FirstOrDefault();
                    MultiSelectListItem item = new MultiSelectListItem();
                    item.ID= childItem.Pk_ItemID;
                    item.Code = childItem.ItemCode;
                    item.Selected = false;
                    item.Description = string.Format("{0}\n{1}\nPART NO: {2}\nCODE:{3} HSN: {4}  UOM:{5}",
                        childItem.Item_Name, childItem.Long_Description, childItem.PartNumber, childItem.ItemCode, childItem.HSNCode, "");
                    lstModels.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetMultiselectInventoryItemListForAssembly", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstModels;
        }
        #endregion

        #region INVENTORY ITEM ATTACHMENTS
        public int AddNewInventoryItemsAttachment(int ItemID, int docCategoryID, string title, string sourceFileNameWithPath, int createdBy)
        {
            int newID = 0;
            try
            {
                string newFileName = (new AppCommon()).GetUniqueFileName(sourceFileNameWithPath);
                string serverPath = AppCommon.GetInventoryItemAttachmentsImagePath();
                string newFileNameWithPath = string.Format("{0}{1}", serverPath, newFileName);
                File.Copy(sourceFileNameWithPath, newFileNameWithPath, true);

                TBL_MP_Master_Item_Attachments objItem = new TBL_MP_Master_Item_Attachments();
                objItem.FK_Inventory_Item_ID = ItemID;
                objItem.FK_CategoryID = docCategoryID;
                objItem.AttachmentFileName = newFileName;
                objItem.Title = title;
                objItem.IsActive = true;

                _dbContext.TBL_MP_Master_Item_Attachments.Add(objItem);
                _dbContext.SaveChanges();
                newID = objItem.PK_AttachmentID;

                // MAINTAINING HISTORY OF ATTACHED DOCUMENT
                TBL_MP_CRM_SM_DocumentHistory history = new TBL_MP_CRM_SM_DocumentHistory();
                history.AttachmentID = newID;
                history.EntityType = (int)APP_ENTITIES.INVENTORY_ITEM;
                history.EmployeeID = createdBy;
                history.CreateDatetime = AppCommon.GetServerDateTime();
                string userName = ServiceEmployee.GetEmployeeNameByID(createdBy);
                history.Description = string.Format("New Document created by {0} dt. {1}", userName, history.CreateDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(history);
                _dbContext.SaveChanges();

            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::AddNewInventoryItemsAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }
        public bool UpdateInventoryItemAttachment(int AttachmentID, int docCategoryID, string title, string sourceFileNameWithPath, int modifiedBy)
        {
            bool result = false;
            try
            {
                string serverPath = AppCommon.GetInventoryItemAttachmentsImagePath();
                TBL_MP_Master_Item_Attachments objItem = _dbContext.TBL_MP_Master_Item_Attachments.Where(x => x.PK_AttachmentID == AttachmentID).FirstOrDefault();

                File.Copy(sourceFileNameWithPath, string.Format("{0}{1}", serverPath, objItem.AttachmentFileName), true);
                objItem.FK_CategoryID = docCategoryID;
                objItem.Title = title;
                _dbContext.SaveChanges();


                TBL_MP_CRM_SM_DocumentHistory historyLead = new TBL_MP_CRM_SM_DocumentHistory();
                historyLead.AttachmentID = AttachmentID;
                historyLead.EntityType = (int)APP_ENTITIES.INVENTORY_ITEM;
                historyLead.EmployeeID = modifiedBy;
                historyLead.CreateDatetime = AppCommon.GetServerDateTime();
                string userName = ServiceEmployee.GetEmployeeNameByID(modifiedBy);
                historyLead.Description = string.Format("Modified by {0} dt. {1}", userName, historyLead.CreateDatetime.Value.ToString("dd MMMyy hh:mmtt"));
                _dbContext.TBL_MP_CRM_SM_DocumentHistory.Add(historyLead);
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::UpdateInventoryItemAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return result;
        }
        public TBL_MP_Master_Item_Attachments GetInventoryItemAttachmentDBRecord(int attachmentID)
        {
            return _dbContext.TBL_MP_Master_Item_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
        }
        public bool DeleteInventoryItemAttachment(int attachmentID, string reason, int empID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Item_Attachments editItem = _dbContext.TBL_MP_Master_Item_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = AppCommon.GetServerDateTime();
                editItem.DeletedBy = empID;
                editItem.IsActive = false;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceInventoryItem::DeleteInventoryItemAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteInventoryItemAttachment(int attachmentID, string reason)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Item_Attachments editItem = _dbContext.TBL_MP_Master_Item_Attachments.Where(x => x.PK_AttachmentID == attachmentID).FirstOrDefault();
                editItem.DeleteDatetime = null;
                editItem.DeletedBy = null;
                editItem.IsActive = true;
                editItem.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceInventoryItem::UndeleteInventoryItemAttachment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public List<SelectListItem> GetAllDeletedAttachments()
        {
            List<SelectListItem> lstAttachments = new List<SelectListItem>();
            try
            {
                List<TBL_MP_Master_Item_Attachments> dbAttachments = (from xx in _dbContext.TBL_MP_Master_Item_Attachments
                                                                      where xx.IsActive == false
                                                                      select xx
                                                                     ).ToList();
                foreach (TBL_MP_Master_Item_Attachments dbItem in dbAttachments)
                {
                    SelectListItem item = new SelectListItem();
                    item.ID = dbItem.PK_AttachmentID;
                    item.Description = string.Format("{0} ({1})\n{2}\n{3}", dbItem.Title,dbItem.TBL_MP_Master_UserList.Description1, dbItem.TBL_MP_Master_Item.Item_Name, dbItem.TBL_MP_Master_Item.Long_Description);
                    item.Code = AppCommon.GetInventoryItemAttachmentsImagePath() + dbItem.AttachmentFileName;
                    lstAttachments.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ServiceInventoryItems::GetDeletedAttachmentsForInventoryItem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return lstAttachments;
        }
         #endregion
       
        public List<SelectListItem> GetUniqueStringsOfItemsForCategory(int catID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            lst = (from xx in _dbContext.TBL_MP_Master_Item where xx.Fk_InvCategory_ID == catID select new SelectListItem() { ID = xx.Pk_ItemID, Description = xx.UniqueString }).ToList();
            return lst;
        }
        public bool DeleteInventoryItemInfo(int itemID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Inventory_Level deleteItem = _dbContext.TBL_MP_Master_Inventory_Level.Where(x => x.Pk_Inv_Level_ID == itemID).FirstOrDefault();
               //  TBL_MP_Master_Inventory_Level deleteItem = _dbContext.TBL_MP_Master_Inventory_Level.Where(x => x.Pk_Inv_Level_ID == itemID && ).FirstOrDefault();
                if (deleteItem != null)
                {
                    deleteItem.IsActive = false;
                    _dbContext.SaveChanges();
                    result = true;
                }



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::DeleteInventoryItemInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool DeleteInventoryItemvalueInfo(int itemID)
        {
            bool result = false;
            try
            {
                TBL_MP_Master_Inventory_Level_Details deleteItem = _dbContext.TBL_MP_Master_Inventory_Level_Details.Where(x => x.Pk_InvLevel_Dtls_ID == itemID).FirstOrDefault();
                if (deleteItem != null)
                {
                    deleteItem.IsActive = false;
                    _dbContext.SaveChanges();
                    result = true;
                }



            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::DeleteInventoryItemvalueInfo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        #region  INVENTORY ITEM - SUPPLIERS
        public List<SelectListItem> GetAllSuppliersForItem(int itemID)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            try
            {
                       lst = (from xx in _dbContext.TBL_MP_Master_Item_Suppliers
                      where xx.Fk_ItemID == itemID 
                       select new SelectListItem() { ID = xx.PK_RelationID, Description = xx.Tbl_MP_Master_Party.PartyName }).ToList();
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::GetAllSuppliersForItem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return lst;
        }
        public bool UpdateSuppliers(int itemID, string SelectedItemID)
        {
            bool result = false;
             try
             {
                  string[] arrSupplier = SelectedItemID.Split(',');
                  for (int i = 0; i <= arrSupplier.GetUpperBound(0); i++)
                  {
                        int currSupplierID = int.Parse(arrSupplier[i]);
                        TBL_MP_Master_Item_Suppliers dbRec = (from xx in _dbContext.TBL_MP_Master_Item_Suppliers
                                                          where xx.Fk_ItemID == itemID && xx.FK_SupplierID==currSupplierID
                                                          select xx).FirstOrDefault();
                        if (dbRec == null)
                        {
                            dbRec = new TBL_MP_Master_Item_Suppliers();
                            dbRec.Fk_ItemID = itemID;
                            dbRec.FK_SupplierID = currSupplierID;
                            dbRec.Is_Delete = false;
                            _dbContext.TBL_MP_Master_Item_Suppliers.Add(dbRec);
                            _dbContext.SaveChanges();
                        }
                  }
                        result = true;
             }
             catch (Exception ex)
             {
                 string errMessage = ex.Message;
                 if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                  MessageBox.Show(errMessage, "ServiceInventoryItems::UpdateSuppliers", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
                return result;
        }
        public bool RemoveSupplier( int SelectedItemID)
        {
            bool result = false;
            try
            {
                
                    TBL_MP_Master_Item_Suppliers dbRec = (from xx in _dbContext.TBL_MP_Master_Item_Suppliers
                                                          where xx.Fk_ItemID == SelectedItemID
                                                          select xx).FirstOrDefault();


                    if (dbRec != null)
                    {
                    dbRec.Is_Delete = true;
                        _dbContext.TBL_MP_Master_Item_Suppliers.Remove(dbRec);
                        _dbContext.SaveChanges();
                        result = true;
                    }
                
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceInventoryItems::RemoveSupplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        /*  
    public int AddSupplierToItem(int itemID, int supplierID)
    {
      
       TBL_MP_Master_Item_Suppliers model = new TBL_MP_Master_Item_Suppliers();
            try
            {

                  model = (from xx in _dbContext.TBL_MP_Master_Item_Suppliers
                           where xx.Fk_ItemID == itemID && xx.FK_SupplierID == supplierID
                                 select xx).FirstOrDefault();
                    if (model == null)
                    {
                        model = new TBL_MP_Master_Item_Suppliers();
                        model.Fk_ItemID = itemID;
                        model.FK_SupplierID = supplierID;
                        model.Is_Delete = false;
                        _dbContext.TBL_MP_Master_Item_Suppliers.Add(model);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        model.Is_Delete = false;
                        _dbContext.SaveChanges();
                    }


                }
                catch (Exception ex)
                {
                    string errMessage = ex.Message;
                    if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                   MessageBox.Show(errMessage, "ServiceInventoryItems::AddSupplierToItem", MessageBoxButtons.OK, MessageBoxIcon.Error);

               }
               return model;
               }

    
    */
        #endregion

    }
}
