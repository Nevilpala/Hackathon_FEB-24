using API_Consume.Areas.ACC.Models;
using API_Consume.Areas.Voucher.Models;
using API_Consume.DAL;
using API_Consume.DAL.Voucher;

namespace API_Consume.BAL.Voucher
{
    public class VoucherBALBase
    {

        #region Method: dbo_PR_Voucher_SelectAll
        public List<dbo_PR_Voucher_SelectAll_Result>? dbo_PR_Voucher_SelectAll(VoucherModel modelVoucher)
        {
            VoucherDAL dalModel = new VoucherDAL();
            return dalModel.dbo_PR_Voucher_SelectAll(modelVoucher).Result;
        }
        #endregion

        #region Method: dbo_PR_Voucher_Delete
        public bool dbo_PR_Voucher_Delete(int VoucherID)
        {
            VoucherDAL dalModel = new VoucherDAL();
            return dalModel.dbo_PR_Voucher_Delete(VoucherID).Result;
        }
        #endregion

        #region Method: dbo_PR_Voucher_Insert
        public bool dbo_PR_Voucher_Insert(VoucherModel modelVoucher)
        {
            VoucherDAL dalModel = new VoucherDAL();
            return dalModel.dbo_PR_Voucher_Insert(modelVoucher).Result;
        }
        #endregion

        #region Method: dbo_PR_Voucher_Update
        public bool dbo_PR_Voucher_Update(VoucherModel modelVoucher)
        {
            VoucherDAL dalModel = new VoucherDAL();
            return dalModel.dbo_PR_Voucher_Update(modelVoucher).Result;
        }
        #endregion

        #region Method: dbo_PR_Voucher_SelectByPk
      
        public VoucherModel? dbo_PR_Voucher_SelectByPk(int? VoucherID)
        {
            VoucherDAL dalModel = new VoucherDAL();
            return dalModel.dbo_PR_Voucher_SelectByPk(VoucherID).Result;
        }
        #endregion

    }
}
