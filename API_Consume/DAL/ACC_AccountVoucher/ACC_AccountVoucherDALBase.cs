using API_Consume.Areas.ACC.Models;
using API_Consume.CF;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace API_Consume.DAL
{
	public abstract class ACC_AccountVoucherDALBase : DALHelper
	{
		#region Method: dbo_PR_ACC_AccountVoucher_SelectAll
		public async Task<List<dbo_PR_ACC_AccountVoucher_SelectAll_Result>?> dbo_PR_ACC_AccountVoucher_SelectAll(ACC_AccountVoucherModel modelACC_AccountVoucher)
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", CV.InstituteCode ?? string.Empty},
					{ "PageOffset", modelACC_AccountVoucher.F_PageOffset.ToString() ?? string.Empty},
					{ "PageSize", modelACC_AccountVoucher.F_PageSize.ToString() ?? string.Empty},
					{ "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
					{ "VoucherNo", modelACC_AccountVoucher.F_VoucherNo ?? string.Empty},
					{ "FromDate",modelACC_AccountVoucher.F_FromDate.ToString() ?? string.Empty},
					{ "ToDate", modelACC_AccountVoucher.F_ToDate.ToString() ?? string.Empty},
					{ "CreditAccountIDAccountName", modelACC_AccountVoucher.F_CreditAccountName ?? string.Empty},
					{ "DebitAccountIDAccountName", modelACC_AccountVoucher.F_DebitAccountName ?? string.Empty},
					{ "AccountDocID", modelACC_AccountVoucher.F_AccountDocID.ToString() ?? string.Empty},
					{ "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
					{ "WarehouseID", modelACC_AccountVoucher.F_WarehouseID.ToString() ?? string.Empty},
					{ "Narration", modelACC_AccountVoucher.F_Narration ?? string.Empty},
					{ "Remarks", modelACC_AccountVoucher.F_Remarks ?? string.Empty},
					{ "UserID", CV.UserID.ToString() ?? string.Empty},
					{ "SecOperationID", modelACC_AccountVoucher.F_SecOperationID.ToString() ?? string.Empty},
				};

				string APIURL = "AccountVoucherSelectPage/CommonAccount/getAccountVoucherSelectPage";
				List<dbo_PR_ACC_AccountVoucher_SelectAll_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_ACC_AccountVoucher_SelectAll_Result>(APIURL, data);
				if (resultList != null)
				{
					DataTable dt = resultList.ToDataTable();
					return ConvertDataTableToEntity<dbo_PR_ACC_AccountVoucher_SelectAll_Result>(dt).ToList();
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

        #region Method: dbo_PR_ACC_AccountVoucher_SelectByPk
        //public async Task<List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>?> dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        //{
        //	try
        //	{
        //		var data = new Dictionary<string, string>()
        //		{
        //			{ "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
        //			{ "AccountVoucherID", AccountVoucherID.ToString() ?? string.Empty},
        //		};

        //		string APIURL = "AccountVoucherSelectPK/CommonAccount/getAccountVoucherSelectPK";
        //		List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>? result = await GetJSONResponseFromAPI<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>(APIURL, data);
        //		return result;
        //	}
        //	catch (Exception ex)
        //	{
        //		var vExceptionHandler = ExceptionHandler(ex);
        //		if (vExceptionHandler.IsToThrowAnyException)
        //			throw vExceptionHandler.ExceptionToThrow;
        //		return null;
        //	}
        //}
        public async Task<ACC_AccountVoucherModel?> dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
                    { "AccountVoucherID", AccountVoucherID.ToString() ?? string.Empty},
                };

                string APIURL = "AccountVoucherSelectPK/CommonAccount/getAccountVoucherSelectPK";
                List<ACC_AccountVoucherModel>? result = await GetJSONResponseFromAPI<ACC_AccountVoucherModel>(APIURL, data);
                if (result[0] == null)
                {

                }
                return result[0];
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

        #region Method: dbo_PR_ACC_AccountVoucher_Insert
        public async Task<bool> dbo_PR_ACC_AccountVoucher_Insert(ACC_AccountVoucherModel modelACC_AccountVoucher)
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", CV.InstituteCode ?? string.Empty},
					{ "AccountDocID", modelACC_AccountVoucher.AccountDocID.ToString() ?? string.Empty},
					{ "VoucherNo", modelACC_AccountVoucher.VoucherNo ?? string.Empty},
					{ "VoucherDate", modelACC_AccountVoucher.VoucherDate.ToString() ?? string.Empty},
					{ "ReferenceNo", modelACC_AccountVoucher.ReferenceNo ?? string.Empty},
					{ "ReferenceDate", modelACC_AccountVoucher.ReferenceDate.ToString() ?? string.Empty},
					{ "Amount", modelACC_AccountVoucher.Amount.ToString() ?? string.Empty},
					{ "Narration", modelACC_AccountVoucher.Narration ?? string.Empty},
					{ "DebitAccountID", modelACC_AccountVoucher.DebitAccountID.ToString() ?? string.Empty},
					{ "CreditAccountID", modelACC_AccountVoucher.CreditAccountID.ToString() ?? string.Empty},
					{ "Remarks", modelACC_AccountVoucher.Remarks ?? string.Empty},
					{ "DocumentID", modelACC_AccountVoucher.DocumentID.ToString() ?? string.Empty},
					{ "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
					{ "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
					{ "BankID", CV.BankID.ToString() ?? string.Empty},
					{ "UserID", CV.UserID.ToString() ?? string.Empty},
					{ "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
					{ "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
				};

				string APIURL = "AccountVoucherInsertSimpleWithAdjustment/CommonAccount/AccountVoucherInsertSimpleWithAdjustment";
				bool result = await GetJSONResponseSuccess(APIURL, data);
				if (result)
					return true;
				else
					return false;
			}
			catch (Exception ex)
			{
				var vExceptionHandler = ExceptionHandler(ex);
				if (vExceptionHandler.IsToThrowAnyException)
					throw vExceptionHandler.ExceptionToThrow;
				return false;
			}
		}
		#endregion SaveIncome

		#region Method: dbo_PR_ACC_AccountVoucher_Update
		public async Task<bool> dbo_PR_ACC_AccountVoucher_Update(ACC_AccountVoucherModel modelACC_AccountVoucher)
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", CV.InstituteCode ?? string.Empty},
					{ "AccountVoucherID", modelACC_AccountVoucher.AccountVoucherID.ToString() ?? string.Empty},
					{ "AccountDocID", modelACC_AccountVoucher.AccountDocID.ToString() ?? string.Empty},
					{ "VoucherNo", modelACC_AccountVoucher.VoucherNo ?? string.Empty},
					{ "VoucherDate", modelACC_AccountVoucher.VoucherDate.ToString() ?? string.Empty},
					{ "ReferenceNo", modelACC_AccountVoucher.ReferenceNo ?? string.Empty},
					{ "ReferenceDate", modelACC_AccountVoucher.ReferenceDate.ToString() ?? string.Empty},
					{ "Amount", modelACC_AccountVoucher.Amount.ToString() ?? string.Empty},
					{ "Narration", modelACC_AccountVoucher.Narration ?? string.Empty},
					{ "DebitAccountID", modelACC_AccountVoucher.DebitAccountID.ToString() ?? string.Empty},
					{ "CreditAccountID", modelACC_AccountVoucher.CreditAccountID.ToString() ?? string.Empty},
					{ "Remarks", modelACC_AccountVoucher.Remarks ?? string.Empty},
					{ "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
					{ "FinYearID", CV.FinYearID.ToString() ?? string.Empty},
					{ "BankID", CV.BankID.ToString() ?? string.Empty},
					{ "UserID", CV.UserID.ToString() ?? string.Empty},
					{ "Created", DateTime.Now.Date.ToString("MM-dd-yyyy") ?? string.Empty},
					{ "Modified", DateTime.Now.Date.ToString("MM-dd-yyyy") ?? string.Empty},
				};
				string APIURL = "AccountVoucherUpdate/CommonAccount/AccountVoucherUpdate";
				bool result = await GetJSONResponseSuccess(APIURL, data);
				if (result)
					return true;
				return false;
			}
			catch (Exception ex)
			{
				var vExceptionHandler = ExceptionHandler(ex);
				if (vExceptionHandler.IsToThrowAnyException)
					throw vExceptionHandler.ExceptionToThrow;
				return false;
			}
		}
		#endregion SaveIncome

		#region Method: dbo_PR_ACC_AccountVoucher_Delete
		public async Task<bool> dbo_PR_ACC_AccountVoucher_Delete(int AccountVoucherID)
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", CV.InstituteCode ?? string.Empty},
					{ "AccountVoucherID", AccountVoucherID.ToString() ?? string.Empty},
					{ "UserID", CV.UserID.ToString() ?? string.Empty},
					{ "DeleteReason", "Testing Delete" ?? string.Empty}
				};

				string APIURL = "AccountVoucherDelete/CommonAccount/AccountVoucherDelete";
				bool result = await GetJSONResponseSuccess(APIURL, data);
				if (result)
					return true;
				return false;
			}
			catch (Exception ex)
			{
				var vExceptionHandler = ExceptionHandler(ex);
				if (vExceptionHandler.IsToThrowAnyException)
					throw vExceptionHandler.ExceptionToThrow;
				return false;
			}
		}
		#endregion DeleteIncome

		#region Method: dbo_PR_AccountDoc_SelectComboBox_Result
		public async Task<List<dbo_PR_AccountDoc_SelectComboBox_Result>?> dbo_PR_AccountDoc_SelectComboBox_Result(string InstituteCode, int CompanyID)
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", InstituteCode},
					{ "CompanyID", CompanyID.ToString()}
				};

				string APIURl = "AccountDocSelectComboBox/CommonAccount/getAccountDocSelectComboBox";
				List<dbo_PR_AccountDoc_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_AccountDoc_SelectComboBox_Result>(APIURl, data);
				
				DataTable dt = result.ToDataTable();

				return ConvertDataTableToEntity<dbo_PR_AccountDoc_SelectComboBox_Result>(dt).ToList();
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

		#region Method: dbo_PR_ACC_Account_SelectComboBox_Result
		public async Task<List<dbo_PR_ACC_Account_SelectComboBox_Result>?> dbo_PR_ACC_Account_SelectComboBox_Result()
		{
			try
			{
				var data = new Dictionary<string, string>()
				{
					{ "InstituteCode", CV.InstituteCode ?? string.Empty },
					{ "CompanyID", CV.CompanyID.ToString() ?? string.Empty },
					{ "prefixText", "___"?? string.Empty},
					{ "UserID", CV.UserID.ToString() ?? string.Empty},
					{ "SecOperationID", "" ?? string.Empty}
				};
				string APIURl = "AccountSelectAutoCompleteByCompanyID/CommonAccount/getAccountSelectAutoCompleteByCompanyID";
				List<dbo_PR_ACC_Account_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_ACC_Account_SelectComboBox_Result>(APIURl, data);
				DataTable dt = result.ToDataTable();

				return ConvertDataTableToEntity<dbo_PR_ACC_Account_SelectComboBox_Result>(dt).ToList();
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


	}

	#region Entity: dbo_PR_ACC_AccountVoucher_SelectAll_Result
	public partial class dbo_PR_ACC_AccountVoucher_SelectAll_Result : DALHelper
	{
		#region Properties
		public int? TotalRecords { get; set; }
		public int AccountVoucherID { get; set; }
        public int? AccDocumentID { get; set; }
		public string? AccountDocName { get; set; }
		public string? VoucherNo { get; set; }
		public DateTime? VoucherDate { get; set; }
		public string? ReferenceNo { get; set; }
		public DateTime? ReferenceDate { get; set; }
		public Decimal? Amount { get; set; }
		public string? Narration { get; set; }
		public int? DebitAccountID { get; set; }
		public string DebitAccountName { get; set; }
		public int? CreditAccountID { get; set; }
		public string CreditAccountName { get; set; }
		public string? Remarks { get; set; }
		public int? CompanyID { get; set; }
		public string? CompanyName { get; set; }
		public int? FinYearID { get; set; }
		public string? FinYearName { get; set; }
		public int? UserID { get; set; }
		public string? UserName { get; set; }
		public string? UserName1 { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
		public DateTime? VerificationDateTime { get; set; }
		public int? VerificationByUserID { get; set; }
		public string? VerificationMessage { get; set; }
		public string? LockMessage { get; set; }
		public bool IsLocked { get; set; }
		public string? RowColor { get; set; }
		public string NevigateURL { get; set; }
		#endregion

		#region Convert Entity to String
		public override String ToString()
		{
			return EntityToString(this);
		}
		#endregion
	}
	#endregion

	#region Entity: dbo_PR_ACC_AccountVoucher_SelectByPK_Result
	public partial class dbo_PR_ACC_AccountVoucher_SelectByPK_Result : DALHelper
	{
		#region Properties
		public int? AccountVoucherID { get; set; }
		public int? AccountDocID { get; set; }
		public string? AccountDocName { get; set; }
		public string? VoucherNo { get; set; }
		public DateTime? VoucherDate { get; set; }
		public string? ReferenceNo { get; set; }
		public DateTime? ReferenceDate { get; set; }
		public decimal? Amount { get; set; }
		public string? Narration { get; set; }
		public int? DebitAccountID { get; set; }
		public int? CreditAccountID { get; set; }
		public string? Remarks { get; set; }
		public int? AccDocumentID { get; set; }
		public int? CompanyID { get; set; }
		public int? UserID { get; set; }
		public int? FinYearID { get; set; }
        public DateTime? Created { get; set; }
		public DateTime? Modified { get; set; }
		public int? BankID { get; set; }
        public DateTime? VerificationDateTime { get; set; }
        public int? VerificationByUserID { get; set; }
		public string? FKVoucherNo { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
		{
			return EntityToString(this);
		}
		#endregion
	}
	#endregion

	#region Entity: dbo_PR_AccountDoc_SelectComboBox_Result
	public partial class dbo_PR_AccountDoc_SelectComboBox_Result : DALHelper
	{
		#region Properties
		public int AccountDocID { get; set; }
		public string AccountDocName { get; set; }
		#endregion

		#region Convert Entity to String
		public override String ToString()
		{
			return EntityToString(this);
		}
		#endregion
	}
	#endregion

	#region Entity: dbo_PR_ACC_Account_SelectComboBox_Result
	public partial class dbo_PR_ACC_Account_SelectComboBox_Result : DALHelper
	{
		#region Properties
		public int AccountID { get; set; }
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
