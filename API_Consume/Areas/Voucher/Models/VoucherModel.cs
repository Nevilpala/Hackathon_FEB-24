using API_Consume.Areas.ACC.Models;
using System.ComponentModel.DataAnnotations;

namespace API_Consume.Areas.Voucher.Models
{
    public class VoucherModel
    {
        /*******************************************************************
        *	FILTERS
        *******************************************************************/

        
        [Display(Name = "Voucher Name", Prompt = "Enter Voucher Name")]
        public string? F_VoucherName { get; set; }

        [Display(Name = "Voucher Code", Prompt = "Enter Voucher Code")]
        public string? F_VoucherCode { get; set; } = string.Empty;
           
        [Display(Name = "Remarks", Prompt = "Enter Remarks")]
        public string? F_Remarks { get; set; } 
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
        public int VoucherID { get; set; }

		[Required]

        [Display(Name = "Voucher Name", Prompt = "Enter Voucher Name")]
        public string? VoucherName { get; set; }

        [Required]

        [Display(Name = "Voucher Code", Prompt = "Enter Voucher Code")]
        public string? VoucherCode { get; set; }
           
        [Display(Name = "Remarks", Prompt = "Enter Remarks")]
        public string? Remarks { get; set; }
        public string? CompanyName { get; set; }
        public string? UserName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; } 
        public int? SecOperationID { get; set; }

        public string? PrintLine1 { get; set; }
        public string? PrintLine2 { get; set; }
        public string? PrintLine3 { get; set; }
        public string? PrintLine4 { get; set; }



    }

    public class VoucherModelList
    {
        public List<VoucherModel> vVoucherModelList { get; set; }
    }
} 
