
using libERP.MODELS;
using libERP.MODELS.COMMON;
using libERP.SERVICES.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libERP.SERVICES.MASTER
{
    public class ServiceContacts: DefaultService
    {
        public ServiceContacts(EXCEL_ERP_TESTEntities _context)
        {
            _dbContext = _context;
        }
        public ServiceContacts()
        {
            _dbContext = new EXCEL_ERP_TESTEntities();
        }

        public List<ContactInfoModel> GetAllContactsForParty(int partyID)
        {
            List<ContactInfoModel> contacts = new List<ContactInfoModel>();
            try
            {
                ServiceMASTERS _serice = new ServiceMASTERS(_dbContext);
                List<SelectListItem> departments = _serice.GetAllDepartments();
                List<SelectListItem> designations = _serice.GetAllDesignation();

                List<Tbl_MP_Master_PartyContact_Detail> dbList = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(xx => xx.FK_PartyID == (int?)partyID && xx.IsActive==true).ToList();
                foreach (Tbl_MP_Master_PartyContact_Detail item in dbList)
                {
                    ContactInfoModel model = new ContactInfoModel();

                    model.ContactID = item.PK_PartyContactDetails;
                    model.CompanyID = (int)item.FK_PartyID;
                    model.AlternateMobileNumber = item.AltMobileNo;
                    model.AlternateTelephoneNo = item.AltTelephoneNo;
                    model.ContactAddress = item.Address;
                    model.ContactName = item.ContactPersoneName;
                    model.ContactType = item.ContactType_Text;
                    model.EmailAddress = item.EmailID;
                    model.MobileNumber = item.MobileNo;             
                    model.TelephoneNo = item.TelephoneNo;
                    model.DepartmentID = item.FK_Department;
                    model.DesignationID = item.FK_Designation;
                    model.FAXNumber = item.FaxNo;
                    if (model.DepartmentID != null)
                    {
                        SelectListItem deptItem = departments.Where(x => x.ID == item.FK_Department).FirstOrDefault();
                        if(deptItem!=null) model.DepartmentName = deptItem.Description;
                    }
                    if (model.DesignationID!=null)
                    {
                        SelectListItem designationItem = designations.Where(x => x.ID == item.FK_Designation).FirstOrDefault();
                        if(designationItem!=null) model.DepartmentName = designationItem.Description;
                    }

                               

                    contacts.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceContacts::GetAllContactsForParty", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return contacts;
        }
        public List<MultiSelectListItem> GetMultiSelectListContactsForParty(int partyID)
        {
            List<MultiSelectListItem> contacts = new List<MultiSelectListItem>();
            try
            {
                List<Tbl_MP_Master_PartyContact_Detail> dbList = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(xx => xx.FK_PartyID == (int?)partyID).ToList();
                foreach (Tbl_MP_Master_PartyContact_Detail item in dbList)
                {
                    string strText1 = string.Empty;
                    string strText2 = string.Empty;
                    strText1 = string.Format("{0}\n{1}", item.ContactPersoneName.ToUpper(), item.Address.Trim());
                    if (item.FK_Designation_Text != null) strText1 += string.Format("{0}", item.FK_Designation_Text);
                    if (item.FK_Department_Text != null) strText1 += string.Format("{0}", item.FK_Department_Text);
                    
                    strText2 += string.Format("Mobile: {0} {1}\n", item.MobileNo, item.AltMobileNo);
                    strText2 += string.Format("Telephone: {0} {1}\n", item.TelephoneNo, item.AltTelephoneNo);
                    strText2 += string.Format("email: {0}\n", item.EmailID);

                    MultiSelectListItem model = new MultiSelectListItem();
                    model.ID = item.PK_PartyContactDetails;
                    model.Selected = false;
                    model.Code = strText1;
                    model.Description = strText2;
                    model.EntityType = APP_ENTITIES.CONTACTS;
                    contacts.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceContacts::GetAllContactsForParty", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return contacts;
        }
        public List<SelectContactModel> GetContactsOfPartyForSelection(int partyID)
        {
            List<SelectContactModel> contacts = new List<SelectContactModel>();
            try
            {
                ServiceMASTERS _serice = new ServiceMASTERS(_dbContext);
                
                List<Tbl_MP_Master_PartyContact_Detail> dbList = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(xx => xx.FK_PartyID == (int?)partyID).ToList();
                foreach (Tbl_MP_Master_PartyContact_Detail item in dbList)
                {
                    SelectContactModel model = new SelectContactModel();
                    model.Selected = false;
                    model.ContactID = item.PK_PartyContactDetails;

                    model.Description1 = string.Format("{0}   {1}\n{2}", item.ContactPersoneName,item.EmailID, item.Address);
                    model.Description2 = string.Empty;
                    if(item.TelephoneNo.Trim()!=string.Empty)
                        model.Description2 += string.Format("Phone: {0} {1}\n", item.TelephoneNo, item.AltTelephoneNo);
                    if (item.MobileNo.Trim() != string.Empty)
                        model.Description2 += string.Format("Mobile: {0} {1}\n",item.MobileNo, item.AltMobileNo);
                    if (item.FaxNo.Trim() != string.Empty)
                        model.Description2 += string.Format("FAX: {0}", item.FaxNo);


                    contacts.Add(model);
                }
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceContacts::GetContactsOfPartyForSelection", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return contacts;
        }
        public Tbl_MP_Master_PartyContact_Detail GetContactByContactID(int contactID)
        {
            return _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == contactID).FirstOrDefault();
        }
        public int AddNewContact(Tbl_MP_Master_PartyContact_Detail model)
        {
            try
            {
                _dbContext.Tbl_MP_Master_PartyContact_Detail.Add(model);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceContacts::AddNewContact", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return model.PK_PartyContactDetails; ;
        }
        public int UpdateContact(Tbl_MP_Master_PartyContact_Detail model)
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string errMessage = ex.Message;
                if (ex.InnerException != null) errMessage += string.Format("\n{0}", ex.InnerException.Message);
                MessageBox.Show(errMessage, "ServiceContacts::UpdateContact", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return model.PK_PartyContactDetails;
        }

        public bool DeletePartyContact(int partyConID,int deletedBy)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_PartyContact_Detail dbPartyCon = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == partyConID).FirstOrDefault();
                dbPartyCon.DeleteDateTime = AppCommon.GetServerDateTime();
                 dbPartyCon.DeletedBy = deletedBy;
                dbPartyCon.IsActive = false;
                //dbPartyCon.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceContacts::DeletePartyContact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public bool UndeleteContact(int ContID, string reason)
        {
            bool result = false;
            try
            {
                Tbl_MP_Master_PartyContact_Detail editCont = _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == ContID).FirstOrDefault();
                editCont.DeleteDateTime = null;
                editCont.DeletedBy = null;
                editCont.IsActive = true;
                editCont.DeleteRemarks = reason;
                _dbContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("{0}\n{1}", ex.Message, ex.InnerException.Message), "ServiceContacts::UndeleteContact", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        public Tbl_MP_Master_PartyContact_Detail GetContactID(int ContID)
        {
            return _dbContext.Tbl_MP_Master_PartyContact_Detail.Where(x => x.PK_PartyContactDetails == ContID).FirstOrDefault();
        }
    }
}
