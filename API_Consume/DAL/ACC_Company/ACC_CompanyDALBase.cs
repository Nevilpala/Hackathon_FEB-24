using API_Consume.Areas.ACC.Models;
using API_Consume.Areas.ACC_Company.Models;
using API_Consume.CF;
using System.Data;

namespace API_Consume.DAL
{
    public abstract class ACC_CompanyDALBase : DALHelper
    {
        #region Method: dbo_PR_ACC_Company_SelectAll
        public async Task<List<dbo_PR_ACC_Company_SelectAll_Result>?> dbo_PR_ACC_Company_SelectAll(ACC_CompanyModel modelACC_Company)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "PageOffset", modelACC_Company.F_PageOffset.ToString() ?? string.Empty},
                    { "PageSize", modelACC_Company.F_PageSize.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "CompanyName", modelACC_Company.F_CompanyName ?? string.Empty},
                    { "SecOperationID", modelACC_Company.F_SecOperationID.ToString() ?? string.Empty}
                };

                string APIURL = "CompanySelectPage/CommonAccount/getCompanySelectPage";
                List<dbo_PR_ACC_Company_SelectAll_Result>? resultList = await GetJSONResponseFromAPI<dbo_PR_ACC_Company_SelectAll_Result>(APIURL, data);
                if (resultList != null)
                {
                    DataTable dt = resultList.ToDataTable();
                    return ConvertDataTableToEntity<dbo_PR_ACC_Company_SelectAll_Result>(dt).ToList();
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

        #region Method: dbo_PR_ACC_Company_SelectByPk

        public async Task<ACC_CompanyModel?> dbo_PR_ACC_Company_SelectByPk(int? CompanyID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "CompanyID", CompanyID.ToString() ?? string.Empty},
                };

                string APIURL = "CompanySelectView/CommonAccount/getCompanySelectView";
                List<ACC_CompanyModel>? result = await GetJSONResponseFromAPI<ACC_CompanyModel>(APIURL, data);
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

        #region Method: dbo_PR_ACC_Company_Insert
        public async Task<bool> dbo_PR_ACC_Company_Insert(ACC_CompanyModel modelACC_Company)
        {
            try
            {

                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty }, 
                    { "CompanyName", modelACC_Company.CompanyName ?? string.Empty },
                    { "CompanyCode", modelACC_Company.CompanyCode ?? string.Empty },
                    { "Address", modelACC_Company.Address ?? string.Empty },
                    { "CityID", modelACC_Company.CityID.ToString() ?? string.Empty },
                    { "CityName", modelACC_Company.CityName ?? string.Empty },
                    { "StateName", modelACC_Company.StateName ?? string.Empty },
                    { "StateID", modelACC_Company.StateID.ToString() ?? string.Empty },
                    { "Pincode", modelACC_Company.Pincode ?? string.Empty },
                    { "PhoneNo", modelACC_Company.PhoneNo ?? string.Empty },
                    { "MobileNo", modelACC_Company.MobileNo ?? string.Empty },
                    { "FaxNo", modelACC_Company.FaxNo ?? " "},
                    { "Email", modelACC_Company.Email ?? string.Empty },
                    { "Website", modelACC_Company.Website ?? " "  },
                    { "ResponsiblePersonName", modelACC_Company.ResponsiblePersonName ??" " },
                    { "ResponsiblePersonDesignation", modelACC_Company.ResponsiblePersonDesignation ?? " "},
                    { "ResponsiblePersonPhoneNo", modelACC_Company.ResponsiblePersonPhoneNo ?? " " },
                    { "STNo", modelACC_Company.STNo ?? " " },
                    { "STDate", modelACC_Company.STDate!=null ? Convert.ToDateTime(modelACC_Company.STDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "PANNo", modelACC_Company.PANNo ?? string.Empty },
                    { "PANDate", modelACC_Company.PANDate!=null ? Convert.ToDateTime(modelACC_Company.PANDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "TANNo", modelACC_Company.TANNo ?? string.Empty },
                    { "TANDate", modelACC_Company.TANDate!=null ? Convert.ToDateTime(modelACC_Company.TANDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "VATNo", modelACC_Company.VATNo ?? string.Empty },
                    { "VATDate", modelACC_Company.VATDate!=null ? Convert.ToDateTime(modelACC_Company.VATDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "ImportExportCode", modelACC_Company.ImportExportCode ??" " },
                    { "ImportExportDate", modelACC_Company.ImportExportDate!=null ? Convert.ToDateTime(modelACC_Company.ImportExportDate).ToString("yyyy-MM-dd") :string.Empty },
                    { "PrintHeader1", modelACC_Company.PrintHeader1 ?? " " },
                    { "PrintHeader2", modelACC_Company.PrintHeader2 ?? " " },
                    { "TermsCondition1", modelACC_Company.TermsCondition1 ?? " " },
                    { "TermsCondition2", modelACC_Company.TermsCondition2 ?? " " },
                    { "TermsCondition3", modelACC_Company.TermsCondition3 ?? " " },
                    { "TermsCondition4", modelACC_Company.TermsCondition4 ?? " " },
                    { "TermsCondition5", modelACC_Company.TermsCondition5 ?? " " },
                    { "OpeningBalanceJournalID", modelACC_Company.OpeningBalanceJournalID.ToString() ?? string.Empty },
                    { "UserID", CV.UserID.ToString() ?? string.Empty },
                    { "Modified", DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd") ?? string.Empty },
                    { "ModifiedCount", modelACC_Company.ModifiedCount.ToString() ?? string.Empty },
                    { "Created",DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd") ?? string.Empty },
                    { "CSTNo", modelACC_Company.CSTNo ?? string.Empty },
                    { "CSTDate", modelACC_Company.CSTDate!=null ? Convert.ToDateTime(modelACC_Company.CSTDate).ToString("yyyy-MM-dd") :string.Empty },
                    { "OpeningDate", modelACC_Company.OpeningDate!=null ? Convert.ToDateTime(modelACC_Company.OpeningDate).ToString("yyyy-MM-dd") :string.Empty },
                    { "LogoPath", modelACC_Company.LogoPath ?? string.Empty },
                    { "VoucherNo", string.Empty } 
                };

                string APIURL = "CompanyInsert/CommonAccount/CompanyInsert";
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

        #region Method: dbo_PR_ACC_Company_Update
        public async Task<bool> dbo_PR_ACC_Company_Update(ACC_CompanyModel modelACC_Company)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode.ToString() ?? string.Empty },
                    { "CompanyID", modelACC_Company.CompanyID.ToString() ?? string.Empty },
                    { "CompanyName", modelACC_Company.CompanyName ?? string.Empty },
                    { "CompanyCode", modelACC_Company.CompanyCode ?? string.Empty },
                    { "Address", modelACC_Company.Address ?? string.Empty },
                    { "CityID", modelACC_Company.CityID.ToString() ?? string.Empty },
                    { "StateID", modelACC_Company.StateID.ToString() ?? string.Empty },
                    { "CityName", modelACC_Company.CityName ?? string.Empty },
                    { "StateName", modelACC_Company.StateName ?? string.Empty },
                    { "Pincode", modelACC_Company.Pincode ?? string.Empty },
                    { "PhoneNo", modelACC_Company.PhoneNo ?? string.Empty },
                    { "MobileNo", modelACC_Company.MobileNo ?? string.Empty },
                    { "FaxNo", modelACC_Company.FaxNo ?? " "},
                    { "Email", modelACC_Company.Email ?? string.Empty },
                    { "Website", modelACC_Company.Website ?? " "  },
                    { "ResponsiblePersonName", modelACC_Company.ResponsiblePersonName ??" " },
                    { "ResponsiblePersonDesignation", modelACC_Company.ResponsiblePersonDesignation ?? " "},
                    { "ResponsiblePersonPhoneNo", modelACC_Company.ResponsiblePersonPhoneNo ?? " " },
                    { "STNo", modelACC_Company.STNo ?? " " },
                    { "STDate", modelACC_Company.STDate!=null ? Convert.ToDateTime(modelACC_Company.STDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "PANNo", modelACC_Company.PANNo ?? string.Empty },
                    { "PANDate", modelACC_Company.PANDate!=null ? Convert.ToDateTime(modelACC_Company.PANDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "TANNo", modelACC_Company.TANNo ?? string.Empty },
                    { "TANDate", modelACC_Company.TANDate!=null ? Convert.ToDateTime(modelACC_Company.TANDate).ToString("yyyy-MM-dd") : string.Empty },
                    { "VATNo", modelACC_Company.VATNo ?? string.Empty },
                    { "VATDate", modelACC_Company.VATDate!=null ? Convert.ToDateTime(modelACC_Company.VATDate).ToString("yyyy-MM-dd") : string.Empty }, 
                    { "ImportExportCode", modelACC_Company.ImportExportCode ??" " },
                    { "ImportExportDate", modelACC_Company.ImportExportDate!=null ? Convert.ToDateTime(modelACC_Company.ImportExportDate).ToString("yyyy-MM-dd") :string.Empty }, 
                    { "PrintHeader1", modelACC_Company.PrintHeader1 ?? " " },
                    { "PrintHeader2", modelACC_Company.PrintHeader2 ?? " " },
                    { "TermsCondition1", modelACC_Company.TermsCondition1 ?? " " },
                    { "TermsCondition2", modelACC_Company.TermsCondition2 ?? " " },
                    { "TermsCondition3", modelACC_Company.TermsCondition3 ?? " " },
                    { "TermsCondition4", modelACC_Company.TermsCondition4 ?? " " },
                    { "TermsCondition5", modelACC_Company.TermsCondition5 ?? " " },
                    { "OpeningBalanceJournalID", modelACC_Company.OpeningBalanceJournalID.ToString() ?? string.Empty },
                    { "UserID", CV.UserID.ToString() ?? string.Empty },
                    { "Modified", DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd") ?? string.Empty },
                    { "ModifiedCount", modelACC_Company.ModifiedCount.ToString() ?? string.Empty },
                    { "Created",DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd") ?? string.Empty },
                    { "CSTNo", modelACC_Company.CSTNo ?? string.Empty }, 
                    { "CSTDate", modelACC_Company.CSTDate!=null ? Convert.ToDateTime(modelACC_Company.CSTDate).ToString("yyyy-MM-dd") :string.Empty },
                    { "OpeningDate", modelACC_Company.OpeningDate!=null ? Convert.ToDateTime(modelACC_Company.OpeningDate).ToString("yyyy-MM-dd") :string.Empty },
                    { "LogoPath", modelACC_Company.LogoPath ?? string.Empty },
                    { "VoucherNo", string.Empty }

                };
                string APIURL = "CompanyUpdate/CommonAccount/CompanyUpdate";
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

        #region Method: dbo_PR_ACC_Company_Delete
        public async Task<bool> dbo_PR_ACC_Company_Delete(int CompanyID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode ?? string.Empty},
                    { "CompanyID", CompanyID.ToString() ?? string.Empty},
                    { "UserID", CV.UserID.ToString() ?? string.Empty},
                    { "SecOperationID", "1"},

                    { "DeleteReason", "Testing Delete" ?? string.Empty}
                };

                string APIURL = "CompanyDelete/CommonAccount/CompanyDelete";
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

        #region Method: dbo_PR_State_SelectComboBox_Result
        public async Task<List<dbo_PR_State_SelectComboBox_Result>?> dbo_PR_State_SelectComboBox_Result()
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode??string.Empty},
                    { "UserID", CV.UserID.ToString()??string.Empty},
                    { "SecOperationID", "1"},
                };

                string APIURl = "StateSelectComboBox/CommonAccount/getStateSelectComboBox";
                List<dbo_PR_State_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_State_SelectComboBox_Result>(APIURl, data);

                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_State_SelectComboBox_Result>(dt).ToList();
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

        #region Method: dbo_PR_State_SelectComboBox_Result
        public async Task<List<dbo_PR_City_SelectComboBox_Result>?> dbo_PR_City_SelectByStateIDComboBox_Result(int? StateID)
        {
            try
            {
                var data = new Dictionary<string, string>()
                {
                    { "InstituteCode", CV.InstituteCode??string.Empty},
                    { "UserID", CV.UserID.ToString()??string.Empty},
                    { "StateID", StateID.ToString()??string.Empty},
                    { "SecOperationID", "1"},
                };
                string APIURl = "";

                if (StateID == null)
                {
                    APIURl = "getCitySelectComboBox/CommonAccount/getCitySelectComboBox";
                }
                else
                {
                    APIURl = "CitySelectComboBoxByStateID/CommonAccount/getCitySelectComboBoxByStateID";
                }


                List<dbo_PR_City_SelectComboBox_Result>? result = await GetJSONResponseFromAPI<dbo_PR_City_SelectComboBox_Result>(APIURl, data);

                DataTable dt = result.ToDataTable();

                return ConvertDataTableToEntity<dbo_PR_City_SelectComboBox_Result>(dt).ToList();
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

    #region Entity: dbo_PR_ACC_Company_SelectAll_Result
    public partial class dbo_PR_ACC_Company_SelectAll_Result : DALHelper
    {
        #region Properties 
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public string? CityName { get; set; }

        public int? CityID { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_ACC_Company_SelectByPK_Result
    public partial class dbo_PR_ACC_Company_SelectByPK_Result : DALHelper
    {
        #region Properties
        public int? CompanyID { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyCode { get; set; }
        public string? CityName { get; set; }
        public int? CityID { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_State_SelectComboBox_Result
    public partial class dbo_PR_State_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public int StateID { get; set; }
        public string StateName { get; set; }
        #endregion

        #region Convert Entity to String
        public override String ToString()
        {
            return EntityToString(this);
        }
        #endregion
    }
    #endregion

    #region Entity: dbo_PR_City_SelectComboBox_Result
    public partial class dbo_PR_City_SelectComboBox_Result : DALHelper
    {
        #region Properties
        public int CityID { get; set; }
        public string CityName { get; set; }
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
