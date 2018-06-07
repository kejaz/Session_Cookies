using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session_Cookies.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string name="";
                if (Request.QueryString["ProductName"] != null)
                {
                    name = Request.QueryString["ProductName"].ToUpper();
                }
                    string apppath = Request.PhysicalPath;
                    string requettype = Request.RequestType;
                    string url = Request.Url.ToString();
                    string browser = Request.Browser.Browser;

                    ViewBag.ProductName = name;
                    ViewBag.AppPath = apppath;
                    ViewBag.RequetType = requettype;
                    ViewBag.Url = url;
                    ViewBag.Browser = browser;

                    Response.Write("Kashif Ejaz Ahmed");
                    //Response.Cookies.Add()


                    
                return View();
            }
        }
    }
}