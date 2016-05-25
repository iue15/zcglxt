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
    public class SystemController : Controller
    {
        //
        // GET: /System/
        #region 页面

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult xgmm() {
            return View();
        }

        #endregion

        #region 方法

        public ActionResult GetCategory() {
            List<CategoryDetail> list = Category.GetAll();
            return Content(JsonConvert.SerializeObject(list));
        }


        //修改密码
        public ActionResult ModifyPassword() {
            ///UserDetail u = Session["user"] as UserDetail;
            ///string UserCode = u.Code;
            //或
            ///string UserCode = Session["UserCode"].ToString() ;//Session["UserCode"] = "UserCode";
            //string UserCode = "admin";
            //String NewPassword = Request["NewPassword"].ToString();
            int ds = 1;
            //ds = User.ModifyPassword(UserCode, NewPassword);
            JsonResult json = new JsonResult{ Data = ds };
            return json;
        }
        #endregion
    }
}
