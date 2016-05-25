using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWMS.BLL;
using WebWMS.Detail;

namespace WebWMS.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        #region 页面

        public ActionResult Index()
        {
            return View();
        }

        //资产目录
        public ActionResult zcml() {
            return View();
        }

        //资产目录-增加
        public ActionResult zcml_add()
        {
            return View();
        }

        //资产类别
        public ActionResult zclb() {
            return View();
        }

        //资产类别-增加
        public ActionResult zclb_add()
        {
            return View();
        }

        //资产状态
        public ActionResult zczt()
        {
            return View();
        }

        //资产状态-增加
        public ActionResult zczt_add()
        {
            return View();
        }

        //计量单位
        public ActionResult jldw()
        {
            return View();
        }

        //计量单位-增加
        public ActionResult jldw_add()
        {
            return View();
        }

        //存放位置
        public ActionResult cfwz()
        {
            return View();
        }

        //存放位置-增加
        public ActionResult cfwz_add()
        {
            return View();
        }

        //增加方式
        public ActionResult zjfs()
        {
            return View();
        }

        //增加方式
        public ActionResult zjfs_add()
        {
            return View();
        }

        //员工管理
        public ActionResult yggl()
        {
            return View();
        }
        //新增员工
        public ActionResult yggl_add()
        {
            return View();
        }
        //员工转隶
        public ActionResult yggl_move()
        {
            return View();
        }

        //部门管理
        public ActionResult bmgl()
        {
            return View();
        }
        //新增部门
        public ActionResult bmgl_add()
        {
            return View();
        }

        #endregion

        #region 方法
        //部门删除
        public ActionResult DepartmentDelete() {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Department.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //存放位置删除
        public ActionResult StorageDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Storage.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //计量单位删除
        public ActionResult MeasureDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Measure.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //员工删除
        public ActionResult EmployerDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Employer.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产类型删除
        public ActionResult CategoryDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Category.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产目录删除
        public ActionResult AssetDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Asset.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产状态删除
        public ActionResult StatusDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = Status.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //增加方式删除
        public ActionResult AddModeDelete()
        {
            string StrCode = Request["StrCode"] == null ? "" : Request["StrCode"].ToString();
            int result = 0;
            if (StrCode.Length > 0)
            {
                string[] Codes = StrCode.Split(',');
                foreach (string Code in Codes)
                {
                    result = AddMode.Delete(Code);
                }
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //部门新增或编辑
        public ActionResult DepartmentInsertOrUpdate()
        {
            DepartmentDetail obj = new DepartmentDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.User = Request["User"] == null ? "" : Request["User"].ToString();
            obj.Job = Request["Job"] == null ? "" : Request["Job"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            //obj.ParentCode = Request["ParentCode"] == null ? "" : Request["ParentCode"].ToString();
            if (Request["ParentCode"] == null || Request["ParentCode"] == "")
            {
                obj.ParentCode = "1000";
            }
            else {
                obj.ParentCode = Request["ParentCode"].ToString();
            }
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Department.Update(obj.Code, obj.Name,obj.User, obj.Job,obj.Note);
            }
            else
            {
                result = Department.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //员工新增或编辑
        public ActionResult EmployerInsertOrUpdate()
        {
            EmployerDetail obj = new EmployerDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Job = Request["Job"] == null ? "" : Request["Job"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            obj.DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Employer.Update(obj.Code, obj.Name, obj.Job, obj.Note);
            }
            else
            {
                result = Employer.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //资产目录新增或编辑
        public ActionResult AssetInsertOrUpdate()
        {
            AssetDetail obj = new AssetDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            obj.ChartNumber = Request["ChartNumber"] == null ? "" : Request["ChartNumber"].ToString();
            obj.CategoryCode = Request["CategoryCode"] == null ? "" : Request["CategoryCode"].ToString();
            obj.MeasureCode = Request["MeasureCode"] == null ? "" : Request["MeasureCode"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Asset.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = Asset.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加或更新存放位置
        public ActionResult StorageInsertOrUpdate()
        {
            StorageDetail obj = new StorageDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Storage.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = Storage.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加或更新计量单位
        public ActionResult MeasureInsertOrUpdate()
        {
            MeasureDetail obj = new MeasureDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Measure.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = Measure.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加或更新资产类型
        public ActionResult CategoryInsertOrUpdate()
        {
            CategoryDetail obj = new CategoryDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Category.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = Category.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        //添加或更资产状态
        public ActionResult StatusInsertOrUpdate()
        {
            StatusDetail obj = new StatusDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = Status.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = Status.Insert(obj);
            }
            //JsonResult json = new JsonResult { Data = result };
            //return json;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //添加或更新增加方式
        public ActionResult AddModeInsertOrUpdate()
        {
            AddModeDetail obj = new AddModeDetail();
            obj.Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            obj.Name = Request["Name"] == null ? "" : Request["Name"].ToString();
            obj.Note = Request["Note"] == null ? "" : Request["Note"].ToString();
            int result = -1;
            if (obj.Code.Length > 0)
            {
                result = AddMode.Update(obj.Code, obj.Name, obj.Note);
            }
            else
            {
                result = AddMode.Insert(obj);
            }
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        
        //部门转隶

        //员工转隶
        public ActionResult EmployerMove()
        {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            string DepartmentCode = Request["DepartmentCode"] == null ? "" : Request["DepartmentCode"].ToString();
            int result = Employer.Move(Code,DepartmentCode);
            JsonResult json = new JsonResult { Data = result };
            return json;
        }

        #endregion
    }
}
