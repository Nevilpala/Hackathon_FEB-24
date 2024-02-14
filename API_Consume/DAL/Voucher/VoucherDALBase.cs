
using API_Consume.Areas.ACC.Models;
using API_Consume.Areas.Voucher.Models;
using API_Consume.CF;
using System.Data;

namespace API_Consume.DAL
{
    public abstract class VoucherDALBase : DALHelper
    {
        #region Method: dbo_PR_Voucher_SelectAll
        public async Task<List<dbo_PR_Voucher_SelectAll_Result>?> dbo_PR_Voucher_SelectAll(VoucherModel modelVoucher)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "PageOffset", modelVoucher.F_PageOffset.ToString() ?? string.Empty},
                    { "PageSize", modelVoucher.F_PageSize.ToString() ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "VoucherName", modelVoucher.F_VoucherName ?? string.Empty},
                    { "VoucherCode",modelVoucher.F_VoucherCode ?? string.Empty},
                    //{ "VoucherCode","02"},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "SecOperationID", modelVoucher.F_SecOperationID.ToString() ?? string.Empty},
                };

                string APIURL = "VoucherSelectPage/CommonAccount/getVoucherSelectPage";
                List<dbo_PR_Voucher_SelectAll_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_Voucher_SelectAll_Result>(APIURL, data);
                if (resultList != null)
                {
                    DataTable dt = resultList.ToDataTable();
                    return ConvertDataTableToEntity<dbo_PR_Voucher_SelectAll_Result>(dt).ToList();
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
        #region Method: dbo_PR_Voucher_Delete
        public async Task<bool> dbo_PR_Voucher_Delete(int VoucherID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "VoucherID", VoucherID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty}
                };

                string APIURL = "VoucherDelete/CommonAccount/VoucherDelete";
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


        #region Method: dbo_PR_Voucher_Insert
        public async Task<bool> dbo_PR_Voucher_Insert(VoucherModel modelVoucher)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "VoucherName", modelVoucher.VoucherName ?? string.Empty},
                    { "VoucherCode",modelVoucher.VoucherCode ?? string.Empty},
                    { "PrintLine1",modelVoucher.PrintLine1 ?? string.Empty},
                    { "PrintLine2",modelVoucher.PrintLine2 ?? string.Empty},
                    { "PrintLine3",modelVoucher.PrintLine3 ?? string.Empty},
                    { "PrintLine4",modelVoucher.PrintLine4 ?? string.Empty},
                    { "Remarks",modelVoucher.Remarks ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                    { "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty}
                };

                string APIURL = "CFGVoucherInsert/CommonAccount/CFGVoucherInsert";
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
        #endregion SaveInsert
        #region Method: dbo_PR_Voucher_SelectByPk

        public async Task<VoucherModel?> dbo_PR_Voucher_SelectByPk(int? VoucherID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty},
                    { "VoucherID", VoucherID.ToString() ?? string.Empty},
                };

                string APIURL = "VoucherSelectView/CommonAccount/getVoucherSelectView";
                List<VoucherModel>? result = await GetJSONResponseFromAPI<VoucherModel>(APIURL, data);
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

        #region Method: dbo_PR_Voucher_Update
        public async Task<bool> dbo_PR_Voucher_Update(VoucherModel modelVoucher)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "VoucherID", modelVoucher.VoucherID.ToString() ?? string.Empty},
                    { "VoucherName", modelVoucher.VoucherName ?? string.Empty},
                    { "VoucherCode",modelVoucher.VoucherCode ?? string.Empty},
                    { "PrintLine1",modelVoucher.PrintLine1 ?? string.Empty},
                    { "PrintLine2",modelVoucher.PrintLine2 ?? string.Empty},
                    { "PrintLine3",modelVoucher.PrintLine3 ?? string.Empty},
                    { "PrintLine4",modelVoucher.PrintLine4 ?? string.Empty},
                    { "Remarks",modelVoucher.Remarks ?? string.Empty},
                    { "CompanyID", CV.CompanyID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "Created", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty},
                    { "Modified", DateTime.Now.Date.ToString("yyyy-MM-dd") ?? string.Empty}
                };
                string APIURL = "CFGVoucherUpdate/CommonAccount/CFGVoucherUpdate";
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

    }


    #region Entity: dbo_PR_Voucher_SelectAll_Result
    public partial class dbo_PR_Voucher_SelectAll_Result : DALHelper
    {
        #region Properties
        public int? VoucherID { get; set; }
        public string? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public string? PrintLine1 { get; set; }
        public string? PrintLine2 { get; set; }
        public string? PrintLine3 { get; set; }
        public string? PrintLine4 { get; set; }
        public string? Remarks { get; set; }
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public int? TotalRecords { get; set; }


        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_Voucher_SelectByPK_Result
    public partial class dbo_PR_Voucher_SelectByPK_Result : DALHelper
    {
        #region Properties
        public int? VoucherID { get; set; }
        public int? VoucherName { get; set; }
        public string? VoucherCode { get; set; }
        public string? PrintLine1 { get; set; }
        public string? PrintLine2 { get; set; }
        public string? PrintLine3 { get; set; }
        public string? PrintLine4 { get; set; }
        public string? Remarks { get; set; }
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public int? UserID { get; set; }
        public string? UserName { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

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
