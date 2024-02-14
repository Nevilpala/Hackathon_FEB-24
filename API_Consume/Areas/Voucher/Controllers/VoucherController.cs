
using API_Consume.Areas.ACC.Models;
using API_Consume.Areas.Voucher.Models;
using API_Consume.BAL.Voucher;
using API_Consume.CF;
using API_Consume.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Consume.Areas.Voucher.Controllers
{
    [CheckAccess]
    [Area("Voucher")]
    [Route("[Controller]/[action]")]
    public class VoucherController : Controller
    {
        #region 10.0 Local Variables

        VoucherBAL balVoucher = new VoucherBAL();
        #endregion 10.0 Local Variables

        #region Constructor
        #endregion Constructor

        #region 11 Index - List Page 

        #region 11.0 Page Load Event - Index - List Page 
        public IActionResult Index()
        {
            return View();
        }
        #endregion
        #region Search Result
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _SearchResult(VoucherModel modelVoucher)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            #region 12.2 Set Default Value
            ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

            modelVoucher.F_PageNo = modelVoucher.F_PageNo == null ? 1 : modelVoucher.F_PageNo;
            modelVoucher.F_PageSize = modelVoucher.F_PageSize == null ? 25 : modelVoucher.F_PageSize;
            #endregion 12.2 Set Default Value            

           
            var vChapterList = balVoucher.dbo_PR_Voucher_SelectAll(modelVoucher);

            PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.Count, Convert.ToInt32(modelVoucher.F_PageNo), Convert.ToInt32(modelVoucher.F_PageSize));
            vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
            vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

            var vModel = new Tuple<VoucherModel, PagedListPagerModel, List<dbo_PR_Voucher_SelectAll_Result>>(modelVoucher, vPagedListPager, vChapterList);

            return PartialView("_VoucherList", vModel);
        }
        #endregion Search Result
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int VoucherID)
        {
            bool vReturen = balVoucher.dbo_PR_Voucher_Delete(VoucherID);
            return RedirectToAction("Index");
        }
        #endregion

        #region ExportExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportExcel(VoucherModel modelVoucher, int TotalRecords)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            modelVoucher.F_PageNo = 1;
            modelVoucher.F_PageSize = TotalRecords;
            var vAccountVoucherList = balVoucher.dbo_PR_Voucher_SelectAll(modelVoucher);

            DataTable dt = EntityToDataTable.ConvertToDataTable(vAccountVoucherList);

            var contentType = "application/vnmodelVoucher.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "AccountVoucherList.xlsx";

            return File(CommonFunctions.DownloadExcel(dt, "Chapter").ToArray(), contentType, fileName);
        }
        #endregion ExportExcel

        #endregion List Page Methods

        #region 11.0 Page Load Event - Add/Edit

        #region FillLabels
        private void FillLabels(ControllerContext controllerContext)
        {
            var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
            var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
            var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
            ViewBag.lblAccountVoucherName = "Voucher";
        }
        #endregion FillLabels
        public IActionResult AddEdit(int? VoucherID)
        {
            #region 11.2 IsAdd, IsEdit Rights
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            if (!vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit && VoucherID != null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (!vUserOperationRightsModel.IsAdd && vUserOperationRightsModel.IsEdit && VoucherID == null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            #endregion 11.2 IsAdd, IsEdit Rights    

            #region 11.2 Fill Lables
            FillLabels(ControllerContext);
            #endregion 11.2 Fill Lables    

            #region 11.4 Set Control Default Value
            VoucherModel voucherModel = new VoucherModel();
            #endregion 11.4 Set Control Default Value

            if (VoucherID != null || VoucherID > 0)
            {
                ViewBag.Action = "Edit";

                //var d = balVoucher.dbo_PR_Voucher_SelectByPk(VoucherID).SingleOrDefault();
                var d = balVoucher.dbo_PR_Voucher_SelectByPk(VoucherID);

                //Mapper.Initialize(config => config.CreateMap<API_Consume.DAL.dbo_PR_Voucher_SelectByPK_Result, VoucherModel>());
                //var vModel = AutoMapper.Mapper.Map<API_Consume.DAL.dbo_PR_Voucher_SelectByPK_Result, VoucherModel>(d);

                return View("VoucherAddEdit", d);
                //var data = await balVoucher.Voucher_SelectByPk(VoucherID);
                //return View("VoucherAddEdit", data);
            }
            ViewBag.Action = "Add";
            return View("VoucherAddEdit", voucherModel);
            //ViewBag.Action = "Add";
            //return View("VoucherAddEdit",null);
        }
        #endregion 11.0 Page Load Event - Add/Edit

        #region 15.0 Save Button Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(VoucherModel modelVoucher)
        {
            try
            {
                #region Validate Field
                string errorMsg = "";
                if (string.IsNullOrEmpty(modelVoucher.VoucherName))
                {
                    errorMsg += "<li>Enter Voucher Name</li>";
                }
                if (string.IsNullOrEmpty(modelVoucher.VoucherCode))
                {
                    errorMsg += "<li>Enter Voucher Code</li>";
                }
                if (errorMsg != "")
                {
                    TempData["ErrorMessage"] = errorMsg;
                    return View("VoucherAddEdit", modelVoucher);
                }
                #endregion Validate Field

                #region Gather Data
                #endregion Gather Data

                if (modelVoucher.VoucherID == 0)
                {
                    bool vReturn = balVoucher.dbo_PR_Voucher_Insert(modelVoucher);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Inserted Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }
                else
                {
                    bool vReturn = balVoucher.dbo_PR_Voucher_Update(modelVoucher);
                    if (vReturn)
                    {
                        TempData["SuccessMessage"] = "Record Updated Successfully..!";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Some Error Has Occured..!";
                    }
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("VoucherAddEdit", modelVoucher);
            }
        }
        #endregion 15.0 Save Button Event
    }
}
