using API_Consume.Areas.ACC.Models;
using API_Consume.CF;
using System.Data;

namespace API_Consume.DAL
{
    public abstract class ACC_AccountLedgerDALBase : DALHelper
    {
        #region Method: dbo_PR_ACC_AccountLedgerByAccountID
        public async Task<List<dbo_PR_ACC_AccountLedgerByAccountID_Result>?> dbo_PR_ACC_AccountLedgerByAccountID(ACC_AccountLedgerModel modelACC_AccountLedger)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "FromDate",Convert.ToDateTime(modelACC_AccountLedger.F_FromDate).ToString("yyyy-MM-dd")},
                    { "ToDate", Convert.ToDateTime(modelACC_AccountLedger.F_ToDate).ToString("yyyy-MM-dd")},
                    { "AccountID", modelACC_AccountLedger.F_AccountID.ToString() ?? string.Empty},
                    { "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "SecOperationID",   string.Empty}
                };

                string APIURL = "SelectLedgerByAccountID/CommonAccount/getSelectLedgerByAccountID";
                List<dbo_PR_ACC_AccountLedgerByAccountID_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_ACC_AccountLedgerByAccountID_Result>(APIURL, data);
                if (resultList != null)
                {
                    DataTable dt = resultList.ToDataTable();
                    return ConvertDataTableToEntity<dbo_PR_ACC_AccountLedgerByAccountID_Result>(dt).ToList();
                }
                return null;
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Method: dbo_PR_AccountNameByCompanyID_SelectComboBox_Result
        public async Task<List<dbo_PR_AccountByCompanyID_SelectComboBox_Result>?> dbo_PR_AccountByCompanyID_SelectComboBox()
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString()??string.Empty},
                    { "prefixText","___" },
                    { "SecOperationID",string.Empty}
                };

                string APIURl = "AccountSelectAutoCompleteByCompanyID/CommonAccount/getAccountSelectAutoCompleteByCompanyID";
                List<dbo_PR_AccountByCompanyID_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_AccountByCompanyID_SelectComboBox_Result>(APIURl, data);

                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_AccountByCompanyID_SelectComboBox_Result>(dt).ToList();
            }
            catch (Exception ex)
            {
                var vExceptionHandler = ExceptionHandler(ex);
                if (vExceptionHandler.IsToThrowAnyException)
                    throw vExceptionHandler.ExceptionToThrow;
                return null;
            }
        }
        #endregion

        #region Entity: dbo_PR_ACC_AccountLedgerByAccountID_Result
        public partial class dbo_PR_ACC_AccountLedgerByAccountID_Result : DALHelper
        {
            #region Properties
            public int JournalID { get; set; }

            public int? AccountID { get; set; }

            public string? VoucherNo { get; set; }

            public DateTime? VoucherDate { get; set; } = null;

            public string? ReferenceNo { get; set; }

            public DateTime? ReferenceDate { get; set; } = null;


            public string? Narration { get; set; }
            public decimal? DebitAmount { get; set; } = 0;
            public decimal? CreditAmount { get; set; } = 0;
            public decimal? Balance { get; set; }
            public string? BalanceOn { get; set; }
            public string? AccountNameCSV { get; set; }

            public int? JournalTranID { get; set; }

            public bool? IsOB { get; set; }

            public DateTime? PrintedDate { get; set; } = null;
            public int? WarehouseID { get; set; }
            public int? SecOperationID { get; set; }
            #endregion

            #region Convert Entity to String
            public override String ToString()
            {
                return EntityToString(this);
            }
            #endregion
        }
        #endregion

        #region Entity: dbo_PR_AccountByCompanyID_SelectComboBox_Result
        public partial class dbo_PR_AccountByCompanyID_SelectComboBox_Result : DALHelper
        {
            #region Properties
            public int AccountDocID { get; set; }
            public string AccountName { get; set; }
            #endregion

            #region Convert Entity to String
            public override String ToString()
            {
                return EntityToString(this);
            }
            #endregion
        }
        #endregion

    }
}
