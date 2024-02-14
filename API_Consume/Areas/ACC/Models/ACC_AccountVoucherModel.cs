using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace API_Consume.Areas.ACC.Models
{
	public class ACC_AccountVoucherModel
	{
        // ModelName: LOC_CityModel

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        [Display(Name = "Account Doc", Prompt = "Select Account Doc")]
        public int? F_AccountDocID { get; set; }
        [Display(Name = "From", Prompt = "Select From Date")]
        public DateTime? F_FromDate { get; set; } = null;
        [Display(Name = "To", Prompt = "Select To Date")]
        public DateTime? F_ToDate { get; set; } = null;
        [Display(Name = "Voucher No.", Prompt = "Enter Voucher No.")]
        public string? F_VoucherNo { get; set; }
        [Display(Name = "Debit Account", Prompt = "Enter Debit Account")]
        public string? F_DebitAccountName { get; set; }
        [Display(Name = "Credit Account", Prompt = "Enter Credit Account")]
        public string? F_CreditAccountName { get; set; }
        [Display(Name = "Narration", Prompt = "Enter Narration")]
        public string? F_Narration { get; set; }
        [Display(Name = "Remarks", Prompt = "Enter Remarks")]
        public string? F_Remarks { get; set; }
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
        public int AccountVoucherID { get; set; }

		[Display(Name = "Account Doc", Prompt = "Select Account Doc")]
        public int? AccountDocID { get; set; }
		[Display(Name = "Account Document", Prompt = "Select Account Doc")]
		public int? DocumentID { get; set; } = 2;
		public string? AccountDocName { get; set; }
		[Display(Name = "Voucher No.", Prompt = "Enter Voucher No.")]
		public string? VoucherNo { get; set; }

		[Display(Name = "Voucher Date", Prompt = "Enter Voucher Date")]
		public DateTime? VoucherDate { get; set; } = null;

		[Display(Name = "Reference No.", Prompt = "Enter Reference No.")]
		public string? ReferenceNo { get; set; }

		[Display(Name = "Reference Date", Prompt = "Enter Reference Date")]
		public DateTime? ReferenceDate { get; set; } = null;

		[Display(Name = "Amount", Prompt = "Enter Amount")]
		public decimal? Amount { get; set; }

		[Display(Name = "Narration", Prompt = "Enter Narration")]
		public string? Narration { get; set; }
		public int? DebitAccountID { get; set; }
		public string? DebitAccountName { get; set; }
		public int? CreditAccountID { get; set; }
		public string? CreditAccountName { get; set; }
		[Display(Name = "Remarks", Prompt = "Enter Remarks")]
		public string? Remarks { get; set; }
		public string? CompanyName { get; set; }
		public string? UserName { get; set; }
		public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
		public int? WarehouseID { get; set; }
		public int? SecOperationID { get; set; }
	}
    public class ACC_AccountVoucherModelList
    {
        public List<ACC_AccountVoucherModel> vACC_AccountVoucherModelList { get; set; }
    }
}
