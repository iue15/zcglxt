using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebWMS.BLL;
using WebWMS.Detail;

namespace WebWMS.Controllers
{
    public class ManageController : Controller
    {
        //
        // GET: /Manage/
        #region 页面

        public ActionResult Index()
        {
            return View();
        }

        //资产增加
        public ActionResult zczj()
        {
            return View();
        }

        //资产领用
        public ActionResult zcly()
        {
            return View();
        }

        //资产调拨
        public ActionResult zcdb()
        {
            return View();
        }

        //资产盘点
        public ActionResult zcpd()
        {
            return View();
        }
        //资产盘点-新增
        public ActionResult zcpd_add()
        {
            return View();
        }

        //资产盘点-新增-选择资产
        public ActionResult zcpd_select()
        {
            return View();
        }

        //资产盘点-盘点
        public ActionResult zcpd_check()
        {
            return View();
        }

        //资产报废
        public ActionResult zcbf()
        {
            return View();
        }

        //资产报废重用
        public ActionResult zcbfcy()
        {
            return View();
        }

        //标签打印
        public ActionResult bqdy()
        {
            return View();
        }

        //资产管理
        public ActionResult zcgl() {
            return View();
        }
        //资产管理-新增
        public ActionResult zcgl_add()
        {
            return View();
        }

        //资产管理-编辑
        public ActionResult zcgl_edit() {
            return View();
        }

        //资产流水
        public ActionResult zcls()
        {
            return View();
        }

        #endregion

        #region 方法
        
        //盘点单状态
        public ActionResult GetCheckStatus()
        {
            List<CheckDetail> list = Check.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        //获取资产目录
        public ActionResult GetAsset() {
            string KeyWord = Request["KeyWord"] == null ? "" : Request["KeyWord"].ToString();
            string MeasureCode = Request["MeasureCode"] == null ? "" : Request["MeasureCode"].ToString();
            string CategoryCode = Request["CategoryCode"] == null ? "" : Request["CategoryCode"].ToString();
            int PageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int PageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int TotalNumber=0, TotalPage=0;

            var data = Asset.GetByCondition(KeyWord, MeasureCode, CategoryCode, PageIndex, PageSize, out TotalNumber, out TotalPage);
            //return Content(JsonConvert.SerializeObject(data));
            var obj = new { total = TotalNumber, rows = data };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        //资产增加
        public ActionResult InventoryInsert() {
            //UserDetail u = Session["user"] as UserDetail;
            //string UserCode = u.Code;
            //或
            //string UserCode = Session["UserCode"].ToString() ;
            decimal decQuantity = Request["Quantity"] == null ? 0 : decimal.Parse(Request["Quantity"]);
            int Quantity = Convert.ToInt32(decQuantity);
            int result = 0, success = 0, error = 0;
            string message;
            if (Quantity > 0)
            {
                for (int i = 0; i < Quantity; i++)
                {
                    InventoryDetail obj = new InventoryDetail();
                    obj.ID = Guid.NewGuid().ToString();//唯一标识码
                    obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
                    obj.MeasureCode = Request["MeasureCode"] == null ? "" : Request["MeasureCode"].ToString();
                    obj.ChartNumber = Request["ChartNumber"] == null ? "" : Request["ChartNumber"].ToString();
                    obj.CategoryCode = Request["CategoryCode"] == null ? "" : Request["CategoryCode"].ToString();
                    //obj.Quantity = Request["Quantity"] == null ? 1 : decimal.Parse(Request["Quantity"]);
                    obj.Quantity = 1;
                    obj.LimitYear = Request["LimitYear"] == null ? 10 : decimal.Parse(Request["LimitYear"]);
                    obj.OriginalValue = Request["OriginalValue"] == null ? 0 : decimal.Parse(Request["OriginalValue"]);
                    obj.StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
                    obj.AddModeCode = Request["AddModeCode"] == null ? "" : Request["AddModeCode"].ToString();
                    obj.AddTime = DateTime.Now.ToString();//DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    obj.OperatorCode = "admin";//u.Code==null?"admin":u.Code;
                    obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();

                    result = Inventory.Insert(obj);
                    if (result > 0)
                    {
                        success++;
                    }
                    else
                    {
                        error++;
                    }
                }
            }
            else {
                message = "数值填写不正确！";
            }

            if (error < 1)
            {
                message = "全部添加成功！";
            }
            else {
                message = "添加成功:"+success+"条，失败:"+error+"条";
            }
            //JsonResult json = new JsonResult();
            //json.Data = new { result=result,message=""};
            JsonResult json = new JsonResult { Data = message };
            return json;
        }

        //资产编辑
        public ActionResult InventoryUpdate() {
            string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string ChartNumber = Request["ChartNumber"] == null ? "" : Request["ChartNumber"].ToString();
            decimal Quantity = Request["Quantity"] == null ? 1 : decimal.Parse(Request["Quantity"]);
            decimal LimitYear = Request["LimitYear"] == null ? 10 : decimal.Parse(Request["LimitYear"]);
            decimal OriginalValue = Request["OriginalValue"] == null ? 0 : decimal.Parse(Request["OriginalValue"]);
            string StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            string AddModeCode = Request["AddModeCode"] == null ? "" : Request["AddModeCode"].ToString();
            string Note = Request["Note"] == null ? "" : Request["Note"].ToString();

            int result = Inventory.Update(ID, ChartNumber, Quantity, LimitYear, OriginalValue, StorageCode, AddModeCode, Note);
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产领用
        public ActionResult InventoryAllocate() {
            /*string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string DepartmentCode = Request["DepartmentName"] == null ? "" : Request["DepartmentName"].ToString();
            string UserCode = Request["UserName"] == null ? "" : Request["UserName"].ToString();//就是这样的，需注意哟
            string StorageCode;
            if (Request["StorageCode"] == null || Request["StorageCode"] == "")
            {
                StorageCode = Request["StorageName"] == null ? "" : Request["StorageName"].ToString();
            }
            else { 
                StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString(); 
            }
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "1001001";//需要Session
            int result=0;
            try{
                result = Inventory.Allocate(ID,DepartmentCode,UserCode,StorageCode,AddTime,OperatorCode);
            }catch(System.Exception e){
                Response.Write(e.StackTrace);
            }*/
            string StrID = Request["StrID"] == null ? "" : Request["StrID"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string UserCode = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            string StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "admin";//需要Session
            int result = 0;
            if (StrID.Length > 0)
            {
                string[] IDs = StrID.Split(',');
                foreach (string ID in IDs)
                {
                    result = Inventory.Allocate(ID, DepartmentCode, UserCode, StorageCode, AddTime, OperatorCode);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产调拨
        public ActionResult InventoryAllot()
        {
            /*string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string DepartmentCode;
            if (Request["DepartmentCode"] == null || Request["DepartmentCode"] == "")
            {
                DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            }
            else
            {
                DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            }
            string UserCode = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            if (Request["UserCode"] == null || Request["UserCode"] == "")
            {
                UserCode = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            }
            else
            {
                UserCode = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            }
            string StorageCode;
            if (Request["StorageCode"] == null || Request["StorageCode"] == "")
            {
                StorageCode = Request["StorageName"] == null ? "" : Request["StorageName"].ToString();
            }
            else
            {
                StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            }
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "1001001";//需要Session
            int result = 0;
            try
            {
                result = Inventory.Allot(ID, DepartmentCode, UserCode, StorageCode, AddTime, OperatorCode);
            }catch(System.Exception e){
                Response.Write(e.StackTrace);
            }*/
            string StrID = Request["StrID"] == null ? "" : Request["StrID"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string UserCode = Request["UserCode"] == null ? "" : Request["UserCode"].ToString();
            string StorageCode = Request["StorageCode"] == null ? "" : Request["StorageCode"].ToString();
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "admin";//需要Session
            int result = 0;
            if (StrID.Length > 0)
            {
                string[] IDs = StrID.Split(',');
                foreach (string ID in IDs)
                {
                    result = Inventory.Allot(ID, DepartmentCode, UserCode, StorageCode, AddTime, OperatorCode);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产报废

        public ActionResult InventoryScrap()
        {
            string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "admin";//需要Session
            int result = 0;
            try
            {
                result = Inventory.Scrap(ID, DepartmentCode, OperatorCode, AddTime);
            }
            catch (System.Exception e)
            {
                Response.Write(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产报废重用
        public ActionResult InventoryReuse()
        {
            string ID = Request["ID"] == null ? "" : Request["ID"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            string AddTime = DateTime.Now.ToString();
            string OperatorCode = "admin";//需要Session
            int result = 0;
            try
            {
                result = Inventory.Reuse(ID, DepartmentCode, OperatorCode, AddTime);
            }
            catch (System.Exception e)
            {
                Response.Write(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加或更新盘点单
        public ActionResult CheckInsertOrUpdate() {
            CheckDetail obj = new CheckDetail();
            obj.ID = Request["ID"] == null ? -1 : int.Parse(Request["ID"]);
            obj.TaskName = Request["TaskName"]==null?"":Request["TaskName"].ToString();
            obj.Mode = "正常盘点";
            obj.DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            obj.StartDate = DateTime.Now;
            obj.EndDate = DateTime.Now.AddMonths(1);
            string date = Request["EndDate"] == null ? "" : Request["EndDate"];
            if (date.Length > 0)
            {
                obj.EndDate = Convert.ToDateTime(date.Trim());
            }
            obj.OperatorCode = Request["OperatorCode"] == null ? "1001001" : Request["OperatorCode"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();

            int result = -1;
            if (obj.ID == 0)
            {
                result = Check.Insert(obj);
            }
            else if (obj.ID > 0)
            {
                try
                {
                    result = Check.Update(obj.ID, obj.TaskName, obj.Mode, obj.StartDate, obj.EndDate, obj.OperatorCode, obj.Note);
                }
                catch (Exception e)//NullReferenceException
                {
                    //throw (e);
                    Console.WriteLine(e.StackTrace);
                }
            }

            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //删除盘点单
        public ActionResult CheckDelete() {
            int ID = Request["ID"] == null ? -1 : int.Parse(Request["ID"]);
            int result = 0;
            try
            {
                result = Check.Delete(ID);
            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //盘点完成
        public ActionResult CompleteCheck()
        {
            int ID = Request["ID"] == null ? -1 : int.Parse(Request["ID"]);
            int result = 0;
            try
            {
                result = Check.Complete(ID);
            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加盘点明细
        public ActionResult CheckItemsInsert() {
            CheckItemsDetail obj = new CheckItemsDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.BarCode = Request["BarCode"] == null ? "" : Request["BarCode"].ToString();
            obj.DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            obj.InventoryQuantity = Request["InventoryQuantity"] == null ? 1 : decimal.Parse(Request["InventoryQuantity"]);
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            obj.BillID = Request["BillID"] == null ? 0 : int.Parse(Request["BillID"]);

            int result = CheckItems.Insert(obj);
            //Message msg = new Message();
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //删除未盘点的盘点单明细
        public ActionResult CheckItemsDelete() {
            int ID = Request["ID"] == null ? 0 : int.Parse(Request["ID"]);
            int result = 0;
            try { 
                result = CheckItems.Delete(ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //盘点
        public ActionResult DoCheck() {
            int ID = Request["ID"] == null ? 0 : int.Parse(Request["ID"]);
            DateTime CheckTime = DateTime.Now;
            string CheckUser = "李四";//需要Session
            decimal ActualQuantity = Request["ActualQuantity"] == null ? 0 : decimal.Parse(Request["ActualQuantity"]);
            int result = 0;
            try
            {
                result = CheckItems.Check(ID, CheckTime, CheckUser, ActualQuantity);
            }catch(Exception e){
                Console.WriteLine(e.StackTrace);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //一键盘点
        public ActionResult OneKeyCheck() {
            int ID = Request["ID"] == null ? 0 : int.Parse(Request["ID"]);
            int BillID = Request["BillID"] == null ? 0 : int.Parse(Request["BillID"]);
            DateTime CheckTime = DateTime.Now;
            string CheckUser = "李四";//需要Session
            decimal ActualQuantity = Request["ActualQuantity"] == null ? 0 : decimal.Parse(Request["ActualQuantity"]);
            int result = 0;
            try
            {
                result = CheckItems.OneKeyCheck(ID, BillID, CheckTime, CheckUser, ActualQuantity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
                JsonResult json = new JsonResult { Data = result };
            
            return json;
        }
        
        #endregion
    }
}
