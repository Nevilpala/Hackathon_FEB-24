using API_Consume.Areas.ACC_Company.Models;
using API_Consume.Areas.ACC_Company.Models;
using API_Consume.Areas.ACC_Company.Models;
using API_Consume.BAL.ACC_Company;
using API_Consume.CF;
using API_Consume.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Consume.Areas.ACC_Company.Controllers
{

    [CheckAccess]
    [Area("ACC_Company")]
    [Route("[Controller]/[action]")]
    public class ACC_CompanyController : Controller
    {
        #region 10.0 Local Variables

        ACC_CompanyBAL balACC_Company = new ACC_CompanyBAL();
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
        public IActionResult _SearchResult(ACC_CompanyModel modelACC_Company)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            #region 12.2 Set Default Value
            ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

            modelACC_Company.F_PageNo = modelACC_Company.F_PageNo == null ? 1 : modelACC_Company.F_PageNo;
            modelACC_Company.F_PageSize = modelACC_Company.F_PageSize == null ? 25 : modelACC_Company.F_PageSize;
            #endregion 12.2 Set Default Value            


            var vChapterList = balACC_Company.dbo_PR_ACC_Company_SelectAll(modelACC_Company);

            PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.Count, Convert.ToInt32(modelACC_Company.F_PageNo), Convert.ToInt32(modelACC_Company.F_PageSize));
            vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
            vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

            var vModel = new Tuple<ACC_CompanyModel, PagedListPagerModel, List<dbo_PR_ACC_Company_SelectAll_Result>>(modelACC_Company, vPagedListPager, vChapterList);

            return PartialView("_ACC_CompanyList", vModel);
        }
        #endregion Search Result
        #region _Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Delete(int CompanyID)
        {
            bool vReturen = balACC_Company.dbo_PR_ACC_Company_Delete(CompanyID);
            return RedirectToAction("Index");
        }
        #endregion

        #region ExportExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ExportExcel(ACC_CompanyModel modelACC_Company, int TotalRecords)
        {
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            modelACC_Company.F_PageNo = 1;
            modelACC_Company.F_PageSize = TotalRecords;
            var vAccountACC_CompanyList = balACC_Company.dbo_PR_ACC_Company_SelectAll(modelACC_Company);

            DataTable dt = EntityToDataTable.ConvertToDataTable(vAccountACC_CompanyList);

            var contentType = "application/vnmodelACC_Company.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = "AccountACC_CompanyList.xlsx";

            return File(CommonFunctions.DownloadExcel(dt, "Chapter").ToArray(), contentType, fileName);
        }
		#endregion ExportExcel

		#endregion List Page Methods

		#region FillLabels
		private void FillLabels(ControllerContext controllerContext)
		{
			var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
			var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
			var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
			ViewBag.lblAccountACC_CompanyName = "ACC_Company";
		}
		#endregion FillLabels

		#region Fill DropDown List
		private void FillDropDownList()
		{
			ViewBag.StateList = CommonFillMethods.FillDropDownListStateName();
			ViewBag.CityList = CommonFillMethods.FillDropDownListCityName();
			ViewBag.AccountList = CommonFillMethods.FillDropDownListAccountID();
        }
		#endregion
		#region 11.0 Page Load Event - Add/Edit

		public IActionResult AddEdit(int? CompanyID)
        {
            #region 11.2 IsAdd, IsEdit Rights
            UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
            ViewBag.UserOperationRights = vUserOperationRightsModel;

            if (!vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit && CompanyID != null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            else if (!vUserOperationRightsModel.IsAdd && vUserOperationRightsModel.IsEdit && CompanyID == null)
            {
                return RedirectToAction("Index", "Error", new { Area = "" });
            }
            #endregion 11.2 IsAdd, IsEdit Rights    

            #region 11.2 Fill Lables
            FillLabels(ControllerContext);
			#endregion 11.2 Fill Lables     

			#region 11.3 Dropdown List Fill Section
			FillDropDownList();
			#endregion 11.3 Dropdown List Fill Section

			#region 11.4 Set Control Default Value
			ACC_CompanyModel voucherModel = new ACC_CompanyModel();
            #endregion 11.4 Set Control Default Value

            if (CompanyID != null || CompanyID > 0)
            {
                ViewBag.Action = "Edit";

                //var d = balACC_Company.dbo_PR_ACC_Company_SelectByPk(CompanyID).SingleOrDefault();
                var d = balACC_Company.dbo_PR_ACC_Company_SelectByPk(CompanyID);

                //Mapper.Initialize(config => config.CreateMap<API_Consume.DAL.dbo_PR_ACC_Company_SelectByPK_Result, ACC_CompanyModel>());
                //var vModel = AutoMapper.Mapper.Map<API_Consume.DAL.dbo_PR_ACC_Company_SelectByPK_Result, ACC_CompanyModel>(d);

                return View("ACC_CompanyAddEdit", d);
                //var data = await balACC_Company.ACC_Company_SelectByPk(CompanyID);
                //return View("ACC_CompanyAddEdit", data);
            }
            ViewBag.Action = "Add";
            return View("ACC_CompanyAddEdit", voucherModel);
            //ViewBag.Action = "Add";
            //return View("ACC_CompanyAddEdit",null);
        }
        #endregion 11.0 Page Load Event - Add/Edit

        #region 15.0 Save Button Event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult _Save(ACC_CompanyModel modelACC_Company)
        {
            try
            {
                #region Validate Field
                string errorMsg = "";
                if (string.IsNullOrEmpty(modelACC_Company.CompanyName))
                {
                    errorMsg += "<li>Enter ACC_Company Name</li>";
                } 
                if (errorMsg != "")
                {
                    TempData["ErrorMessage"] = errorMsg;
                    return View("ACC_CompanyAddEdit", modelACC_Company);
                }
                #endregion Validate Field

                #region Gather Data
                #endregion Gather Data

                if (modelACC_Company.CompanyID == 0)
                {
                    bool vReturn = balACC_Company.dbo_PR_ACC_Company_Insert(modelACC_Company);
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
                    bool vReturn = balACC_Company.dbo_PR_ACC_Company_Update(modelACC_Company);
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
                if (modelACC_Company.CompanyID == 0)
                {
                    ViewBag.Action = "Add";
                }
                else
                {
                    ViewBag.Action = "Edit";

                }
                TempData["ErrorMessage"] = ex.Message;
                return View("ACC_CompanyAddEdit", modelACC_Company);
            }
        }
        #endregion 15.0 Save Button Event
    }
}
