using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWMS.BLL;
using WebWMS.Detail;

namespace WebWMS.Controllers
{
    public class SharedController : Controller
    {
        //
        // GET: /Shared/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetAssist() {
            string ClassCode = Request["ClassCode"] == null ? "" : Request["ClassCode"].ToString();
            List<AssistDetail> list = Assist.GetByClassCode(ClassCode);
            return Content(JsonConvert.SerializeObject(list));
        }

        //资产（目录）
        public ActionResult GetAsset()
        {
            List<AssetDetail> list = Asset.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取资产目录
        public ActionResult GetAssetByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Asset.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //资产类别
        public ActionResult GetCategory() {
            List<CategoryDetail> list = Category.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取资产类别
        public ActionResult GetCategoryByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Category.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //计量单位
        public ActionResult GetMeasure()
        {
            List<MeasureDetail> list = Measure.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取计量单位
        public ActionResult GetMeasureByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Measure.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //存放地址
        public ActionResult GetStorage()
        {
            List<StorageDetail> list = Storage.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取存放位置
        public ActionResult GetStorageByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Storage.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //增加方式
        public ActionResult GetAddMode()
        {
            List<AddModeDetail> list = AddMode.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取增加方式
        public ActionResult GetAddModeByCode() {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = AddMode.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //资产状态
        public ActionResult GetStatus()
        {
            List<StatusDetail> list = Status.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取资产状态
        public ActionResult GetStatusByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Status.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //部门
        public ActionResult GetDepartment()
        {
            List<DepartmentDetail> list = Department.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取部门
        public ActionResult GetDepartmentByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Department.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //按条件查找员工
        public ActionResult GetDepartmentByCondition()
        {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;
            var list = Department.GetByCondition(KeyWord, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(list));
            var obj = new { total = TotalNumber, rows = list };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //员工
        public ActionResult GetEmployer()
        {
            List<EmployerDetail> list = Employer.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据Code获取员工
        public ActionResult GetEmployerByCode()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            var list = Employer.GetByCode(Code);
            return Content(JsonConvert.SerializeObject(list));
        }

        //获取部门下的员工
        public ActionResult GetDepartmentEmployer() {
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            var list = Employer.GetByDepartmentCode(DepartmentCode);
            return Content(JsonConvert.SerializeObject(list));
        }

        //按条件查找员工
        public ActionResult GetEmployerByCondition() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;
            var list = Employer.GetByCondition(KeyWord, DepartmentCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(list));
            var obj = new { total = TotalNumber, rows = list };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public class DepartEmployer
        {
            public string Code { get; set; }
            public string Name { get; set; }
            public string ParentCode { get; set; }
        }
        public ActionResult GetDataForTree() {
            //List<wDepartmentEmployerDetail> list = wDepartmentEmployer.GetAll();
            List<EmployerDetail> le = Employer.GetAll();
            List<DepartmentDetail> ld = Department.GetAll();
            List<DepartEmployer> list = new List<DepartEmployer>();
            foreach (DepartmentDetail d in ld)
            {
                DepartEmployer obj = new DepartEmployer();
                obj.Code = d.Code;
                obj.Name = d.Name;
                obj.ParentCode = d.ParentCode;
                list.Add(obj);
            }
            foreach(EmployerDetail e in le){
                DepartEmployer obj = new DepartEmployer();
                obj.Code = e.Code;
                obj.Name = e.Name;
                obj.ParentCode = e.DepartmentCode;
                list.Add(obj);
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        //根据ID获取资产
        public ActionResult GetInventoryByID() {
            string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            var data = Inventory.GetByID(ID);
            return Content(JsonConvert.SerializeObject(data));
        }

        //资产信息
        public ActionResult GetInventory() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string StatusCode = Request["StatusCode"] == null ? "" : Request["StatusCode"].ToString();
            string CategoryCode = Request["CategoryCode"] == null ? "" : Request["CategoryCode"].ToString();
            string MeasureCode = Request["MeasureCode"] == null ? "" : Request["MeasureCode"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string EmployerCode = Request["EmployerCode"] == null ? "" : Request["EmployerCode"].ToString();
            string StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            string AddModeCode = Request["AddModeCode"] == null ? "" : Request["AddModeCode"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;

            //var data = Inventory.GetByCondition(KeyWord, StatusCode, MeasureCode, CategoryCode, StorageCode, DepartmentCode, EmployerCode, AddModeCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //var obj = new { total = TotalNumber, rows = data };
            //return Json(obj, JsonRequestBehavior.AllowGet);
            List<InventoryDetail> data = Inventory.GetByCondition(KeyWord, StatusCode, MeasureCode, CategoryCode, StorageCode, DepartmentCode, EmployerCode, AddModeCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(data));
            var obj = new { total = TotalNumber, rows = data };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //根据状态（和关键字）查询资产
        public ActionResult GetInventoryByStatus() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string StatusCode = Request["StatusCode"] == null ? "" : Request["StatusCode"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;
            var data = Inventory.GetByKeyWordAndStatus(KeyWord, StatusCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(data));
            var obj = new { total = TotalNumber, rows = data };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetInventoryList() {
            string DepartmentCode = "";
            string OperatorCode = "";
            string Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;
            var data = InventoryList.GetByCondition(DepartmentCode, OperatorCode,Note, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(data));
            var obj = new { total = TotalNumber, rows = data };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //资产增加报表
        public ActionResult GetInventoryForStatistics() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string CategoryCode = Request["CategoryCode"] == null ? "" : Request["CategoryCode"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string AddModeCode = Request["AddModeCode"] == null ? "" : Request["AddModeCode"].ToString();
            DateTime StartDate = DateTime.Now.AddMonths(-1);
            string date = Request["StartTime"] == null ? "" : Request["StartTime"];
            if (date.Length > 0)
            {
                StartDate = Convert.ToDateTime(date.Trim());
            }
            string StartTime = StartDate.ToString("yyyy/M/d HH:mm:ss");
            DateTime EndDate = DateTime.Now;
            string date2 = Request["EndTime"] == null ? "" : Request["EndTime"];
            if (date2.Length > 0)
            {
                EndDate = Convert.ToDateTime(date2.Trim());
            }
            string EndTime = EndDate.ToString("yyyy/M/d HH:mm:ss");
            //string EndTime = EndDate.ToString("yyyy/M/d");
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;
            var data = Inventory.GetForStatistics(KeyWord, CategoryCode, DepartmentCode, AddModeCode, StartTime, EndTime, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(data));
            var obj = new { total = TotalNumber, rows = data };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //获取单个盘点单
        public ActionResult GetCheck()
        {
            int ID = Request["GID"] == null ? 0 : int.Parse(Request["GID"]);

            var data = Check.GetByID(ID);
            return Content(JsonConvert.SerializeObject(data));
        }

        //获取分页盘点单
        public ActionResult GetCheckPaging() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string StatusCode = Request["StatusCode"] == null ? "" : Request["StatusCode"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            DateTime StartDate = DateTime.Now.AddMonths(-1);
            string date = Request["StartDate"] == null ? "" : Request["StartDate"];
            if (date.Length > 0)
            {
                StartDate = Convert.ToDateTime(date.Trim());
                //DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
                //dtFormat.ShortDatePattern = "yyyy-MM-dd";
                //StartDate = Convert.ToDateTime(date, dtFormat);
            }
            DateTime EndDate = DateTime.Now;
            string date2 = Request["EndDate"] == null ? "" : Request["EndDate"];
            if (date2.Length > 0)
            {
                EndDate = Convert.ToDateTime(date2.Trim());
            }
            string StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            string AddModeCode = Request["AddModeCode"] == null ? "" : Request["AddModeCode"].ToString();
            string OperatorCode = Request["OperatorCode"] == null ? "" : Request["OperatorCode"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;

            var data = Check.GetByCondition(KeyWord, StatusCode, DepartmentCode, StartDate, EndDate, OperatorCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            var obj = new { total = TotalNumber, rows = data };
            return Content(JsonConvert.SerializeObject(data));
            //return Json(obj, JsonRequestBehavior.AllowGet);//该方法转换后到前台，DateTime类型的时间显示有问题
        }

        //获取单个盘点单明细
        public ActionResult GetCheckItems()
        {
            int BillID = Request["BillID"] == null ? 0 : int.Parse(Request["BillID"]);
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;

            var data = CheckItems.GetByBillID(BillID, PageIndex, PageSize, out TotalNumber, out TotalPage);
            var obj = new { total = TotalNumber, rows = data };
            return Content(JsonConvert.SerializeObject(obj));
        }

        //按条件查询单个盘点单明细
        public ActionResult GetCheckItemsPaginge()
        {
            int BillID = Request["BillID"] == null ? 0 : int.Parse(Request["BillID"]);
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            //string Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            string Note = "";
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 5 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;

            var data = CheckItems.GetByCondition(BillID, KeyWord, Note, PageIndex, PageSize, out TotalNumber, out TotalPage);
            var obj = new { total = TotalNumber, rows = data };
            return Content(JsonConvert.SerializeObject(obj));
        }
    }
}
