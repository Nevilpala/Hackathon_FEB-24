using API_Consume.Areas.ACC.Models;
using API_Consume.BAL;
using API_Consume.BAL.ACC_AccountLedger;
using API_Consume.CF;
using API_Consume.DAL;
using Microsoft.AspNetCore.Mvc;
using static API_Consume.DAL.ACC_AccountLedgerDALBase;

namespace API_Consume.Areas.ACC.Controllers
{
    [CheckAccess]
    [Area("ACC")]
    [Route("[Controller]/[action]")]
    public class ACC_AccountLedgerController : Controller
    {
        #region 10.0 Local Variables
        ACC_AccountLedgerBAL balACC_AccountLedger = new ACC_AccountLedgerBAL();
        #endregion 10.0 Local Variables

        #region Constructor
        #endregion Constructor

        #region List Page Methods

        #region 11.0 Page Load Event - Index - List Page 
        public IActionResult Index()
        {
            FillDropDownList();
            return View();
        }
        #endregion

        #region Search Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(ACC_AccountLedgerModel modelACC_AccountLedger)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            #region 12.2 Set Default Value
            ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

            modelACC_AccountLedger.F_PageNo = modelACC_AccountLedger.F_PageNo == null ? 1 : modelACC_AccountLedger.F_PageNo;
            modelACC_AccountLedger.F_PageSize = modelACC_AccountLedger.F_PageSize == null ? 25 : modelACC_AccountLedger.F_PageSize;
            #endregion 12.2 Set Default Value            

            //modelACC_AccountLedger.F_PageNo = 1;
            modelACC_AccountLedger.F_PageSize = 25;

            var vChapterList = balACC_AccountLedger.dbo_PR_ACC_AccountLedger_SelectAll(modelACC_AccountLedger);

            //PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.First().TotalRecords, Convert.ToInt32(modelACC_AccountLedger.F_PageNo), Convert.ToInt32(modelACC_AccountLedger.F_PageSize));
            PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.Count, 1, Convert.ToInt32(modelACC_AccountLedger.F_PageSize));
            vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
            vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

            var vModel = new Tuple<ACC_AccountLedgerModel, PagedListPagerModel, List<dbo_PR_ACC_AccountLedgerByAccountID_Result>>(modelACC_AccountLedger, vPagedListPager, vChapterList);

            return PartialView("_ACC_AccountLedgerList", vModel);
        }
        #endregion Search Result

        #endregion - List Page Methods

        #region FillLabels
        private void FillLabels(ControllerContext controllerContext)
        {
            var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
            var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
            var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
            ViewBag.lblAccountVoucherName = "Account Ledger";
        }
        #endregion FillLabels

        #region Fill DropDown List
        private void FillDropDownList()
        {
            ViewBag.AccountList = CommonFillMethods.FillDropDownListAccountID(); 
        }
        #endregion



    }
}
