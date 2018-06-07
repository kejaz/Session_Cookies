using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session_Cookies.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public string SaveForm(FormCollection frm)
        {
            string data = "";
            data += " User ID: " +  frm["txtUserId"].ToUpper();
            data += ", User Name: " + frm["txtUserName"].ToUpper();
            data += ", Phone: " + frm["txtPhone"].ToUpper();
            data += ", Address: " + frm["txtAddress"].ToUpper();
            return data;
        }
    }
}