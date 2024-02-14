using API_Consume.Areas.ACC.Models;
using API_Consume.BAL;
using API_Consume.CF;
using API_Consume.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API_Consume.Areas.ACC.Controllers
{
	[CheckAccess]
    [Area("ACC")]
	[Route("[Controller]/[action]")]
	public class ACC_AccountVoucherController : Controller
	{
		#region 10.0 Local Variables
		ACC_AccountVoucherBAL balACC_AccountVoucher = new ACC_AccountVoucherBAL();
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
		public IActionResult _SearchResult(ACC_AccountVoucherModel modelACC_AccountVoucher)
		{
			UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
			ViewBag.UserOperationRights = vUserOperationRightsModel;

			#region 12.2 Set Default Value
			ViewBag.SearchResultHeaderText = CV.SearchResultHeaderText;

			modelACC_AccountVoucher.F_PageNo = modelACC_AccountVoucher.F_PageNo == null ? 1 : modelACC_AccountVoucher.F_PageNo;
			modelACC_AccountVoucher.F_PageSize = modelACC_AccountVoucher.F_PageSize == null ? 25 : modelACC_AccountVoucher.F_PageSize;
			#endregion 12.2 Set Default Value            

			//modelACC_AccountVoucher.F_PageNo = 1;
			//modelACC_AccountVoucher.F_PageSize = 25;

			var vChapterList = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_SelectAll(modelACC_AccountVoucher);

			PagedListPagerModel vPagedListPager = new PagedListPagerModel(vChapterList.First().TotalRecords, Convert.ToInt32(modelACC_AccountVoucher.F_PageNo), Convert.ToInt32(modelACC_AccountVoucher.F_PageSize));
			vPagedListPager.PageInfo = Pagination.GetPageInformation(vPagedListPager);
			vPagedListPager.PageSizeList = Pagination.GetPagedListPageSizes();

			var vModel = new Tuple<ACC_AccountVoucherModel, PagedListPagerModel, List<dbo_PR_ACC_AccountVoucher_SelectAll_Result>>(modelACC_AccountVoucher, vPagedListPager, vChapterList);

			return PartialView("_ACC_AccountVoucherList", vModel);
		}
		#endregion Search Result

		#region ExportExcel
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ExportExcel(ACC_AccountVoucherModel modelACC_AccountVoucher, int TotalRecords)
		{
			UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
			ViewBag.UserOperationRights = vUserOperationRightsModel;

			modelACC_AccountVoucher.F_PageNo = 1;
			modelACC_AccountVoucher.F_PageSize = TotalRecords;
			var vAccountVoucherList = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_SelectAll(modelACC_AccountVoucher);

			DataTable dt = EntityToDataTable.ConvertToDataTable(vAccountVoucherList);

			var contentType = "application/vnmodelACC_AccountVoucher.openxmlformats-officedocument.spreadsheetml.sheet";
			var fileName = "AccountVoucherList.xlsx";

			return File(CommonFunctions.DownloadExcel(dt, "Chapter").ToArray(), contentType, fileName);
		}
		#endregion ExportExcel

		#region _Delete
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult _Delete(int AccountVoucherID)
		{
			bool vReturen = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_Delete(AccountVoucherID);
			return RedirectToAction("Index");
		}
		#endregion

		#endregion List Page Methods

		#region FillLabels
		private void FillLabels(ControllerContext controllerContext)
		{
			var CurrentArea = controllerContext.RouteData.Values["area"].ToString();
			var CurrentController = controllerContext.RouteData.Values["controller"].ToString();
			var CurrentAction = controllerContext.RouteData.Values["action"].ToString();
			ViewBag.lblAccountVoucherName = "Account Voucher";
		}
		#endregion FillLabels

		#region Fill DropDown List
		private void FillDropDownList()
		{
			ViewBag.AccountList = CommonFillMethods.FillDropDownListAccountID();
			ViewBag.AccountDocList = CommonFillMethods.FillDropDownListAccountDocID();
		}
		#endregion

		#region 11.0 Page Load Event - Add/Edit
		public IActionResult AddEdit(int? AccountVoucherID)
		{
			#region 11.2 IsAdd, IsEdit Rights
			UserOperationRightsModel vUserOperationRightsModel = UserOperationRights.CheckForOperation(ControllerContext);
			ViewBag.UserOperationRights = vUserOperationRightsModel;

			if (!vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit)
			{
				return RedirectToAction("Index", "Error", new { Area = "" });
			}
			else if (vUserOperationRightsModel.IsAdd && !vUserOperationRightsModel.IsEdit && AccountVoucherID != null)
			{
				return RedirectToAction("Index", "Error", new { Area = "" });
			}
			else if (!vUserOperationRightsModel.IsAdd && vUserOperationRightsModel.IsEdit && AccountVoucherID == null)
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
			ACC_AccountVoucherModel AccountVoucherModel = new ACC_AccountVoucherModel();
			#endregion 11.4 Set Control Default Value

			if (AccountVoucherID != null || AccountVoucherID > 0)
			{
				ViewBag.Action = "Edit";

				//var d = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID).SingleOrDefault();
				var d = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_SelectByPk(AccountVoucherID);

				//Mapper.Initialize(config => config.CreateMap<API_Consume.DAL.dbo_PR_ACC_AccountVoucher_SelectByPK_Result, ACC_AccountVoucherModel>());
				//var vModel = AutoMapper.Mapper.Map<API_Consume.DAL.dbo_PR_ACC_AccountVoucher_SelectByPK_Result, ACC_AccountVoucherModel>(d);

				return View("ACC_AccountVoucherAddEdit", d);
				//var data = await balACC_AccountVoucher.ACC_AccountVoucher_SelectByPk(AccountVoucherID);
				//return View("ACC_AccountVoucherAddEdit", data);
			}
			ViewBag.Action = "Add";
			return View("ACC_AccountVoucherAddEdit", AccountVoucherModel);
			//ViewBag.Action = "Add";
			//return View("ACC_AccountVoucherAddEdit",null);
		}
		#endregion 11.0 Page Load Event - Add/Edit

		#region 15.0 Save Button Event
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult _Save(ACC_AccountVoucherModel modelACC_AccountVoucher)
		{
			try
			{
				#region Validate Field
				string errorMsg = "";
				if (modelACC_AccountVoucher.AccountDocID == null)
				{
					errorMsg += "<li>Select Account Doc</li>";
				}
				if (modelACC_AccountVoucher.VoucherNo == null)
				{
					errorMsg += "<li>Enter Voucher No</li>";
				}
				if (errorMsg != "")
				{
					TempData["ErrorMessage"] = errorMsg;
					return View("ACC_AccountVoucherAddEdit", modelACC_AccountVoucher);
				}
				#endregion Validate Field

				#region Gather Data
				#endregion Gather Data

				if (modelACC_AccountVoucher.AccountVoucherID == 0)
				{
					bool vReturn = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_Insert(modelACC_AccountVoucher);
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
					bool vReturn = balACC_AccountVoucher.dbo_PR_ACC_AccountVoucher_Update(modelACC_AccountVoucher);
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
				return View("ACC_AccountVoucherAddEdit", modelACC_AccountVoucher);
			}
		}
		#endregion 15.0 Save Button Event

	}
}
