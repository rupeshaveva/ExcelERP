using libERP.MODELS.COMMON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libERP.MODELS.HR
{
    public class EmployeeBaseModal
    {
        public int EmployeeID { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeFullName { get; set; }
        public string EmployeeContactNumbers { get; set; }
        public string EmployeeEmailAddress { get; set; }
        public SelectListItem DesignationInfo { get; set; }
        public SelectListItem DepartmentInfo { get; set; }
        public SelectListItem EmploymentType { get; set; }
        public SelectListItem CategoryInfo { get; set; }
        public EmployeeBaseModal() { DesignationInfo = new SelectListItem(); DepartmentInfo = new SelectListItem(); CategoryInfo = new SelectListItem(); }
    }

    public class EmployeeGeneralInfoModel : EmployeeBaseModal
    {
        public string PhoneNo1 { get; set; }
        public string AltPhoneNo { get; set; }
        public SelectListItem EmployeeBranchInfo { get; set; }
        public DateTime? DateOfAppointment { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public float ProbationPeriod { get; set; }
        public float NoticePeriod { get; set; }
        public string ResidentialAddress { get; set; }
        public string PermanentAddress { get; set; }
        public int JoiningLocationCityID { get; set; }
        public SelectListItem EmployeeBossInfo { get; set; }
        public string WeekOffDays { get; set; }
        public string ImageFileName { get; set; }
        public string OfficialEmailAddress { get; set; }
       // public string PersonalEmailAddress { get; set; }
       public string OfficialPhoneNo { get; set; }
        public EmployeeGeneralInfoModel() : base()
        {
            EmployeeBranchInfo = new SelectListItem();
            EmployeeBossInfo= new SelectListItem();
        }

      
    }
    public class EmployeeResignationInfoModel : EmployeeBaseModal
    {
        public bool IsResigned { get; set; }
        public DateTime? ResignedDate { get; set; }
        public DateTime? LeavingDate { get; set; }
        public string ReasonForResigning { get; set; }
        public bool HoldSalary { get; set; }

        public EmployeeResignationInfoModel() : base()
        {

        }

    }
    public class EmployeePersonalInfoModel : EmployeeBaseModal
    {
        public DateTime? DateOfBirth { get; set; }
        public string BirthPlace { get; set; }
        public SelectListItem GenderInfo { get; set; }
        public SelectListItem BloodGroupInfo { get; set; }
        public SelectListItem MeritalStatusInfo { get; set; }
        public DateTime? AnniversaryDate { get; set; }
        public string Language { get; set; }
        public bool SeniorCitizen { get; set; }
        public EmployeePersonalInfoModel()
        {
            this.GenderInfo = new SelectListItem();
            this.BloodGroupInfo = new SelectListItem();
            MeritalStatusInfo = new SelectListItem();
        }
    }
    public class EmployeeRelativeInfoModel : EmployeeBaseModal
    {
        public int EmplooyeeRelativeID { get; set; }
        public int RelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public string RelativeName { get; set; }
        public DateTime? RelativeDOB { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
      
    }
    public class EmployeeBankInfoModel : EmployeeBaseModal
    {
        public SelectListItem BankInfo { get; set; }
        public SelectListItem BankBranchInfo { get; set; }
        public SelectListItem BankAccountType { get; set; }
        public SelectListItem PaymentModeType { get; set; }

        public DateTime? LastCheckUpDate { get; set; }
        public DateTime? NextCheckUpDate { get; set; }

        public string AccountNo { get; set; }
        public string DebitCardNo { get; set; }
        public string CreditCardNo { get; set; }
        public string PFNumber { get; set; }
        public string ESICNumber { get; set; }
        public string PANNumber { get; set; }
        public string UANNumber { get; set; }


        public EmployeeBankInfoModel()
        {
            this.BankInfo = new SelectListItem();
            this.BankBranchInfo = new SelectListItem();
            this.BankAccountType = new SelectListItem();
            this.PaymentModeType = new SelectListItem();
        }


    }

    public class EmployeeQualificationInfoModel : EmployeeBaseModal
    {
        public int EmployeeQualificationID { get; set; }
        public string QualificationName { get; set; }
        public string NameOfInstitute { get; set; }
        public string Grade { get; set; }

        public string SearchText { get { return string.Format("{0} {1} {2} ", this.QualificationName, this.NameOfInstitute, this.Grade); } }
    }

    public class LastEmployerInfoModel : EmployeeBaseModal
    {
        public int LastEmployerID { get; set; }
        public string LastEmployerName { get; set; }
        public string LastEmployerAddress { get; set; }
        public int ContactNo { get; set; }
        public string SearchText { get { return string.Format("{0} {1} {2} ", this.LastEmployerName, this.LastEmployerAddress, this.ContactNo); } }
        public bool isActive { get; set; }
    }

    public class EmployeeAdditionalInfoModel : EmployeeBaseModal
    {
        public string Nationality { get; set; }
        public string AADHAR_NO { get; set; }


        public string LicenceNo { get; set; }
        public DateTime? LicenceIssueDate { get; set; }
        public DateTime? LicenceExpiryDate { get; set; }

        public string PassportNo { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public DateTime? PassportExpiryDate { get; set; }


        public SelectListItem VisaTypeInfo { get; set; }
        public string VisaNo { get; set; }
        public DateTime? VisaIssueDate { get; set; }
        public DateTime? VisaExpiryDate { get; set; }

        public string WorkPermitType { get; set; }
        public string WorkPermitNo { get; set; }
        public DateTime? WorkPermitIssueDate { get; set; }
        public DateTime? WorkPermitExpiryDate { get; set; }

        public EmployeeAdditionalInfoModel()
        {
            VisaTypeInfo = new SelectListItem();

        }


        public List<TBL_MP_Master_Employee_MedicalDetail> MedicalInfo { get; set; }
    }
    public class EmployeeSalaryHeadModel : EmployeeBaseModal
    {
        public bool IsSelected { get; set; }
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public int SalaryHeadID { get; set; }
        public string SalaryHeadName { get; set; }
        public SalaryHeadCalculatedOn HeadForCalculation { get; set; }
        public ITEM_CHARGE_TYPE ApplicableChargesType { get; set; }
        public decimal ApplicableChargesValue { get; set; }
        public string ApplicableChargesAsString
        {
            get
            {
                string str = string.Empty;
                if (this.ApplicableChargesType == ITEM_CHARGE_TYPE.PERCENTAGE)
                {
                    str = string.Format("{0:0.00}%", this.ApplicableChargesValue);
                }
                else
                {
                    str = string.Format("Rs. {0:0.00}", this.ApplicableChargesValue);
                }
                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC) str += " (B)";
                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_GROSS) str += " (G)";
                if (this.HeadForCalculation == SalaryHeadCalculatedOn.PERCENT_OF_BASIC_AND_DA) str += " (BA+DA)";
                return str;
            }
        }
        public decimal SalaryHeadAmount { get; set; }
        public EMPLOYMENT_TYPE EmploymentTYPE { get; set; }

        public EmployeeSalaryHeadModel() { this.ApplicableChargesType = ITEM_CHARGE_TYPE.NONE;  this.HeadForCalculation = SalaryHeadCalculatedOn.NONE; }
    }

}