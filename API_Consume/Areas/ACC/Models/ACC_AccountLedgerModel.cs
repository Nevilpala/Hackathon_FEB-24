using System.ComponentModel.DataAnnotations;

namespace API_Consume.Areas.ACC.Models
{
    public class ACC_AccountLedgerModel
    {

        /*******************************************************************
         *	FILTERS
         *******************************************************************/
        [Required,Display(Name = "Account Name", Prompt = "Select Account Name")] 
        public int? F_AccountID { get; set; } 

        [Required, Display(Name = "From Date", Prompt = "Select From Date")] 
        public DateTime? F_FromDate { get; set; }

        [Required, Display(Name = "To Date", Prompt = "Select To Date")]
        public DateTime? F_ToDate { get; set; } 

        
        public int? F_WarehouseID { get; set; }
        public int? F_SecOperationID { get; set; }
        [Display(Name = "F_PageNo")]
        public int? F_PageNo { get; set; }

        [Display(Name = "F_PageSize")]
        public int? F_PageSize { get; set; }

        [Required, Display(Name = "No. of Rows")]
        public int F_NoOfRows { get; set; }
        public int F_PageOffset { get; set; } = 0;

    }
    public class ACC_AccountLedgerModelList
    {
        public List<ACC_AccountLedgerModel> vACC_AccountLedgerModelList { get; set; }
    }
}
