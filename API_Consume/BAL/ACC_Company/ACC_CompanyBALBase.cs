using API_Consume.Areas.ACC.Models;
using API_Consume.Areas.ACC_Company.Models;
using API_Consume.DAL;

namespace API_Consume.BAL.ACC_Company
{
    public class ACC_CompanyBALBase
    {

        #region Method: dbo_PR_ACC_Company_SelectAll
        public List<dbo_PR_ACC_Company_SelectAll_Result>? dbo_PR_ACC_Company_SelectAll(ACC_CompanyModel modelACC_Company)
        {
            ACC_CompanyDAL dalACC_AccountModel = new ACC_CompanyDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Company_SelectAll(modelACC_Company).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Company_SelectByPk
 
        public ACC_CompanyModel? dbo_PR_ACC_Company_SelectByPk(int? CompanyID)
        {
            ACC_CompanyDAL dalACC_AccountModel = new ACC_CompanyDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Company_SelectByPk(CompanyID).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Company_Insert
        public bool dbo_PR_ACC_Company_Insert(ACC_CompanyModel modelACC_Company)
        {
            ACC_CompanyDAL dalACC_AccountModel = new ACC_CompanyDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Company_Insert(modelACC_Company).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Company_Update
        public bool dbo_PR_ACC_Company_Update(ACC_CompanyModel modelACC_Company)
        {
            ACC_CompanyDAL dalACC_AccountModel = new ACC_CompanyDAL();
            return dalACC_AccountModel.dbo_PR_ACC_Company_Update(modelACC_Company).Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Company_Delete
        public bool dbo_PR_ACC_Company_Delete(int CompanyID)
        {
            ACC_CompanyDAL dalACC_CompanyModel = new ACC_CompanyDAL();
            return dalACC_CompanyModel.dbo_PR_ACC_Company_Delete(CompanyID).Result;
        }
        #endregion

        #region Method: dbo_PR_State_SelectComboBox
        public List<dbo_PR_State_SelectComboBox_Result>? dbo_PR_State_SelectComboBox_Result()
        {
            ACC_CompanyDAL dalACC_CompanyModel = new ACC_CompanyDAL();
            return dalACC_CompanyModel.dbo_PR_State_SelectComboBox_Result().Result;
        }
        #endregion

        #region Method: dbo_PR_ACC_Account_SelectComboBox
        public List<dbo_PR_City_SelectComboBox_Result>? dbo_PR_City_SelectComboBox_Result(int? StateID)
        {
            ACC_CompanyDAL dalACC_CompanyModel = new ACC_CompanyDAL();
            return dalACC_CompanyModel.dbo_PR_City_SelectByStateIDComboBox_Result(StateID).Result;
        }
        #endregion
    }
}
