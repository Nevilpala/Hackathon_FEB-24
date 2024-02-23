using API_Consume.BAL;
using API_Consume.BAL.ACC_AccountLedger;
using API_Consume.BAL.ACC_Company;
using API_Consume.DAL;
using static API_Consume.DAL.ACC_AccountLedgerDALBase;

namespace API_Consume.CF
{
    public class CommonFillMethods
    {
        public static List<dbo_PR_AccountDoc_SelectComboBox_Result>? FillDropDownListAccountDocID()
        {
            ACC_AccountVoucherBAL balACC_AccountVoucher = new ACC_AccountVoucherBAL();
            return balACC_AccountVoucher.dbo_PR_ACC_AccountDoc_SelectComboBox(CV.InstituteCode, CV.CompanyID);
        }

		public static List<dbo_PR_ACC_Account_SelectComboBox_Result>? FillDropDownListAccountID()
		{
			ACC_AccountVoucherBAL balACC_AccountVoucher = new ACC_AccountVoucherBAL();
			return balACC_AccountVoucher.dbo_PR_ACC_Account_SelectComboBox();
		}

        public static List<dbo_PR_AccountByCompanyID_SelectComboBox_Result>? FillDropDownListAccountName()
		{
			ACC_AccountLedgerBAL balACC_AccountLedger = new ACC_AccountLedgerBAL();
			return balACC_AccountLedger.dbo_PR_AccountByCompanyID_SelectComboBox_Result();
		}

		public static List<dbo_PR_State_SelectComboBox_Result>? FillDropDownListStateName()
		{
			ACC_CompanyBAL balACC_Company = new ACC_CompanyBAL();
			return balACC_Company.dbo_PR_State_SelectComboBox_Result();
		}

		public static List<dbo_PR_City_SelectComboBox_Result>? FillDropDownListCityName(int? StateID =null)
		{
			ACC_CompanyBAL balACC_Company = new ACC_CompanyBAL();
			return balACC_Company.dbo_PR_City_SelectComboBox_Result(StateID);
		}
	}
}
