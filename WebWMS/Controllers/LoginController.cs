using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebWMS.BLL;
using WebWMS.Detail;

namespace LeaRun.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login() {
            string Code = Request["Code"] == null ? "" : Request["Code"].ToString();
            string Password = Request["Password"] == null ? "" : Request["Password"].ToString();
            int result = WebWMS.BLL.User.Login(Code, Password);
            JsonResult json = new JsonResult { Data = result };
            return json;
        }
    }
}
