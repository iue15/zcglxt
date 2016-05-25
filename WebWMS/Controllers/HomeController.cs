//using LeaRun.DataAccess;
//using LeaRun.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using WebWMS.BLL;
using WebWMS.Detail;

namespace WebWMS.Controllers
{
    public class HomeController : Controller
    {
        //public Base_ModuleBll base_modulebll = new Base_ModuleBll();

        #region 后台首页-手风琴菜单
        /// <summary>
        /// 手风琴UI
        /// </summary>
        /// <returns></returns>
        public ActionResult AccordionIndex()
        {
            /*IManageUser imanageuser = new IManageUser();
            imanageuser.UserId = "System";
            imanageuser.Account = "System";
            imanageuser.UserName = "System";
            imanageuser.Gender = "超级管理员";
            imanageuser.Code = "System";
            imanageuser.LogTime = DateTime.Now;
            imanageuser.CompanyId = "系统";
            imanageuser.DepartmentId = "系统";
            imanageuser.IsSystem = true;
            ManageProvider.Provider.AddCurrent(imanageuser);
            //对在线人数全局变量进行加1处理
            //HttpContext rq = System.Web.HttpContext.Current;
            //rq.Application["OnLineCount"] = (int)rq.Application["OnLineCount"] + 1;
            ViewBag.Account = ManageProvider.Provider.Current().Account + "（" + ManageProvider.Provider.Current().UserName + "）";*/
            return View();
        }
        /// <summary>
        /// 手风琴-欢迎首页
        /// </summary>
        /// <returns></returns>
        public ActionResult AccordionPage()
        {
            return View();
        }
        /// <summary>
        /// 加载手风琴菜单
        /// </summary>
        /// <returns></returns>
        public ActionResult LoadAccordionMenu()
        {
            //List<Base_Module> list = base_modulebll.GetList().FindAll(t => t.Enabled == 1);
            List<MenuDetail> list = Menu.GetAllEnabled();
            //return Content(list.ToJson().Replace("&nbsp;", ""));
            return Content(JsonConvert.SerializeObject(list));//Serialize JSON
        }
        #endregion

        //修改密码
        public ActionResult xgmm()
        {
            return View();
        }

        public ActionResult GetAllInventory() {
            //string keyWord = HttpContext.Request("KeyWord");
            List<InventoryDetail> list = Inventory.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }

        /*public ActionResult GetByCondition()
        {
            //int UserID = (int)Session["UserID"];
            //string Pname = Request.QueryString["pname"].ToString();
            //string Pname2 = Request["pname"].ToString();
            int ton,top;
            List<InventoryDetail> list = Inventory.GetByCondition("", "", "", "", "", "", "", "", 2, 5, out ton, out top);
            return Content(JsonConvert.SerializeObject(list));
        }*/

        //修改密码
        public ActionResult ChangePassword() {
            string Code = "admin";//需要Session
            string OldPassword = Request["OldPassword"] == null ? "" : Request["OldPassword"].ToString();
            string NewPassword = Request["NewPassword"] == null ? "" : Request["NewPassword"].ToString();
            int result = WebWMS.BLL.User.ChangePassword(Code, OldPassword, NewPassword);
            JsonResult json = new JsonResult { Data = result };
            return json;
        }
    }
}
