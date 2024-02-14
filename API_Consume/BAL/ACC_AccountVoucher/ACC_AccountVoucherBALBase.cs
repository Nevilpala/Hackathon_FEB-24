using API_Consume.Areas.ACC.Models;
using API_Consume.DAL;

namespace API_Consume.BAL
{
    public class ACC_AccountVoucherBALBase
    {
		#region Method: dbo_PR_ACC_AccountVoucher_SelectAll
		public List<dbo_PR_ACC_AccountVoucher_SelectAll_Result>? dbo_PR_ACC_AccountVoucher_SelectAll(ACC_AccountVoucherModel modelACC_AccountVoucher)
        {
            ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_SelectAll(modelACC_AccountVoucher).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountVoucher_SelectByPk
        //public List<dbo_PR_ACC_AccountVoucher_SelectByPK_Result>? dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        //      {
        //          ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
        //          return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID).Result;
        //      }
        public ACC_AccountVoucherModel? dbo_PR_ACC_AccountVoucher_SelectByPk(int? AccountVoucherID)
        {
            ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_AccountVoucher_Insert
        public bool dbo_PR_ACC_AccountVoucher_Insert(ACC_AccountVoucherModel modelACC_AccountVoucher)
        {
            ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_Insert(modelACC_AccountVoucher).Result;
        }
		#endregion

		#region Method: dbo_PR_ACC_AccountVoucher_Update
		public bool dbo_PR_ACC_AccountVoucher_Update(ACC_AccountVoucherModel modelACC_AccountVoucher)
        {
            ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_Update(modelACC_AccountVoucher).Result;
        }
		#endregion

		#region Method: dbo_PR_ACC_AccountVoucher_Delete
		public bool dbo_PR_ACC_AccountVoucher_Delete(int AccountVoucherID)
        {
            ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
            return dalACC_AccountModel.dbo_PR_ACC_AccountVoucher_Delete(AccountVoucherID).Result;
        }
		#endregion

		#region Method: dbo_PR_ACC_AccountDoc_SelectComboBox
		public List<dbo_PR_AccountDoc_SelectComboBox_Result>? dbo_PR_ACC_AccountDoc_SelectComboBox(string InstituteCode, int CompanyID)
		{
			ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
			return dalACC_AccountModel.dbo_PR_AccountDoc_SelectComboBox_Result(InstituteCode, CompanyID).Result;
		}
		#endregion

		#region Method: dbo_PR_ACC_Account_SelectComboBox
		public List<dbo_PR_ACC_Account_SelectComboBox_Result>? dbo_PR_ACC_Account_SelectComboBox()
		{
			ACC_AccountVoucherDAL dalACC_AccountModel = new ACC_AccountVoucherDAL();
			return dalACC_AccountModel.dbo_PR_ACC_Account_SelectComboBox_Result().Result;
		}
		#endregion
	}
}
