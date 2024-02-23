
using System.ComponentModel.DataAnnotations;

namespace API_Consume.Areas.ACC_Company.Models
{
    public class ACC_CompanyModel
    {
        /*******************************************************************
        *	FILTER FORM
         *******************************************************************/
        [Display(Name = "Company Name", Prompt = "Enter Company Name")]
        public string? F_CompanyName { get; set; }
        public int? F_WarehouseID { get; set; }
        public int? F_SecOperationID { get; set; }
        [Display(Name = "F_PageNo")]
        public int? F_PageNo { get; set; }

        [Display(Name = "F_PageSize")]
        public int? F_PageSize { get; set; }

        [Required, Display(Name = "No. of Rows")]
        public int F_NoOfRows { get; set; }
        public int F_PageOffset { get; set; } = 0;


        /*******************************************************************
        *	ADDEDIT FORM
         *******************************************************************/

         
        public int PageOffset { get; set; } = 0;

        public int? PageSize { get; set; } = 50;
        public int CompanyID { get; set; }

        [Required, Display(Name = "Company Name", Prompt = "Enter Company Name")]
        public string? CompanyName { get; set; }

        [Display(Name = "Company Code", Prompt = "Enter Company Code")]
        public string? CompanyCode { get; set; }

        [Display(Name = "Address", Prompt = "Enter Address")]
        public string? Address { get; set; }

        [Display(Name = "State")]
        public int? StateID { get; set; } = null;
        public string? StateName { get; set; }

        [Display(Name = "City")]
        public int? CityID { get; set; } = null;
        public string? CityName { get; set; }


        [Display(Name = "PinCode", Prompt = "Enter PinCode")]
        public string? Pincode { get; set; }

        [Display(Name = "PhoneNo", Prompt = "Enter Phone No")]
        public string? PhoneNo { get; set; }

        [Display(Name = "MobileNo", Prompt = "Enter Mobile No")]
        public string? MobileNo { get; set; }

        [Display(Name = "FaxNo", Prompt = "Enter Fax No")]
        public string? FaxNo { get; set; }

        [Display(Name = "Email", Prompt = "Enter Email ")]
        public string? Email { get; set; }


        [Display(Name = "Website", Prompt = "Enter Website ")]
        public string? Website { get; set; }

        [Display(Name = "Responsible Person Name", Prompt = "Enter Responsible Person Name ")]
        public string? ResponsiblePersonName { get; set; }

        [Display(Name = "Responsible Person Designation", Prompt = "Enter Responsible Person Designation ")]
        public string? ResponsiblePersonDesignation { get; set; }

        [Display(Name = "Responsible Person Name", Prompt = "Enter Responsible Person Name ")]
        public string? ResponsiblePersonPhoneNo { get; set; }

        [Display(Name = "ST No", Prompt = "Enter ST No ")]
        public string? STNo { get; set; }

        [Display(Name = "ST Date", Prompt = "Enter ST Date ")]
        public DateTime? STDate { get; set; } = null;

        [Display(Name = "PAN No", Prompt = "Enter PAN No")]
        public string? PANNo { get; set; }

        [Display(Name = "PAN Date", Prompt = "Enter PAN Date ")]
        public DateTime? PANDate { get; set; } = null;

        [Display(Name = "TAN No", Prompt = "Enter TAN No ")]
        public string? TANNo { get; set; }

        [Display(Name = "TAN Date", Prompt = "Enter TAN Date ")]
        public DateTime? TANDate { get; set; } = null;

        [Display(Name = "VAT No", Prompt = "Enter VAT No ")]
        public string? VATNo { get; set; }

        [Display(Name = "VAT Date", Prompt = "Enter VAT Date ")]
        public DateTime? VATDate { get; set; } = null;

        [Display(Name = "Import Export Code", Prompt = "Enter Import Export Code ")]
        public string? ImportExportCode { get; set; }

        [Display(Name = "Import Export Date", Prompt = "Enter Import Export Date ")]
        public DateTime? ImportExportDate { get; set; } = null;

        [Display(Name = "CST No", Prompt = "Enter CST No ")]
        public string? CSTNo { get; set; }

        [Display(Name = "CST Date", Prompt = "Enter CST Date ")]
        public DateTime? CSTDate { get; set; } = null;

        [Display(Name = "Opening Balance Journal", Prompt = "Select OpeningBalanceJournal ")]
        public int? OpeningBalanceJournalID { get; set; }

        [Display(Name = "PrintHeader 1", Prompt = "Enter PrintHeader 1 ")]
        public string? PrintHeader1 { get; set; }

        [Display(Name = "PrintHeader 2", Prompt = "Enter PrintHeader 2 ")]
        public string? PrintHeader2 { get; set; }

        [Display(Name = "TermsCondition 1", Prompt = "Enter Terms Condition 1 ")]
        public string? TermsCondition1 { get; set; }

        [Display(Name = "TermsCondition 2", Prompt = "Enter Terms Condition 2 ")]
        public string? TermsCondition2 { get; set; }


        [Display(Name = "TermsCondition 3", Prompt = "Enter Terms Condition 3 ")]
        public string? TermsCondition3 { get; set; }

        [Display(Name = "TermsCondition 4", Prompt = "Enter Terms Condition 4 ")]
        public string? TermsCondition4 { get; set; }

        [Display(Name = "TermsCondition 5", Prompt = "Enter Terms Condition 5 ")]
        public string? TermsCondition5 { get; set; }

        [Display(Name = "Opening Date", Prompt = "Enter Opening Date ")]
        public DateTime? OpeningDate { get; set; } = null;


        [Display(Name = "Logo", Prompt = "Enter Responsible Person Name ")]
        public string? LogoPath { get; set; }

         
        public int? ModifiedCount { get; set; }


        public DateTime Modified { get; set; } = DateTime.Now.AddDays(-1).Date;

        public DateTime Created { get; set; } = DateTime.Now.AddDays(-1).Date;

    }
    public class ACC_CompanyModelList
    {
        public List<ACC_CompanyModel> vACC_CompanyModelList { get; set; }
    }
}
