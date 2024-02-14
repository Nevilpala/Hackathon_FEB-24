
using API_Consume.Areas.ACC.Models;
using API_Consume.DAL;
using static API_Consume.DAL.ACC_AccountLedgerDALBase;

namespace API_Consume.BAL.ACC_AccountLedger
{
    public class ACC_AccountLedgerBALBase
    {

        #region Method: dbo_PR_ACC_AccountLedger_SelectAll
        public List<dbo_PR_ACC_AccountLedgerByAccountID_Result>? dbo_PR_ACC_AccountLedger_SelectAll(ACC_AccountLedgerModel modelACC_AccountLedger)
        {
            ACC_AccountLedgerDAL dalModel = new ACC_AccountLedgerDAL();
            return dalModel.dbo_PR_ACC_AccountLedgerByAccountID(modelACC_AccountLedger).Result;
        }
        #endregion

        #region Method: dbo_PR_AccountByCompanyID_SelectComboBox
        public List<dbo_PR_AccountByCompanyID_SelectComboBox_Result>? dbo_PR_AccountByCompanyID_SelectComboBox_Result()
        {
            ACC_AccountLedgerDAL dalACC_AccountModel = new ACC_AccountLedgerDAL();
            return dalACC_AccountModel.dbo_PR_AccountByCompanyID_SelectComboBox().Result;
        }
        #endregion
    }
}
