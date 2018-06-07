using Session_Cookies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Session_Cookies.Controllers
{
    public class LoginController : Controller
    {
        public static List<User> usersList = new List<Models.User>() {
            new Models.User(){ UserId="01",Name = "John",Password="01"},
            new Models.User(){ UserId="02",Name = "Chris",Password="02"},
            new Models.User(){ UserId="03",Name = "Adam",Password="03"}
        };
        // GET: Login
        public ActionResult Index()
        {
            Session_Cookies.Models.Login obj = new Session_Cookies.Models.Login();
            if (HttpContext.Request.Cookies["Id"] != null)
            {
                obj.UserId = HttpContext.Request.Cookies["Id"].Value;
                obj.Password = HttpContext.Request.Cookies["Password"].Value;
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Authentication(Session_Cookies.Models.Login login)
        {
            
            if (ModelState.IsValid)
            {
                User loginUser = usersList.Where(u => u.UserId == login.UserId && u.Password == login.Password).SingleOrDefault();
                if (loginUser != null)
                {
                    //Creation of session
                    Session["User"] = loginUser;
                    if (login.IsRemember)
                    {
                        HttpCookie cookieId = new HttpCookie("Id");
                        cookieId.Value = login.UserId;
                        cookieId.Expires = DateTime.Now.AddMinutes(2);
                        HttpContext.Response.Cookies.Add(cookieId);

                        HttpCookie cookiePassword = new HttpCookie("Password");
                        cookiePassword.Value = login.Password;
                        cookiePassword.Expires = DateTime.Now.AddMinutes(2);
                        HttpContext.Response.Cookies.Add(cookiePassword);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Index", login);
                }
            }
            else
            {
                return View("Index",login);
            }
        }
        public ActionResult Logout()
        {
            Session["User"] = null;
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}