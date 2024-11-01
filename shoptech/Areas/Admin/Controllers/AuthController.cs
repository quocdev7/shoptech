using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Admin/Auth
        public ActionResult Login()
        {
            if (Session["User_Admin"].ToString() != "")
            {
                Response.Redirect("~/Admin");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            BanHangDBContext db = new BanHangDBContext();
            string username = filed["username"];
            string password =filed["password"];
            password = Mystring.ToMD5(Mystring.ToMD5(password));
            //Tên đăng nhập có hay không
            
            int count_username = db.Users
                .Where(m=>m.UserName == username || m.Email == username)
                .Where(m => m.Status == 1 && m.Access == 1)
                .Count();
            if (count_username == 0)
            {
                ViewBag.Error = "<span class ='text-danger'>Tài khoản này không tồn tại!</span>";
            }
            else
            {
                var acount = db.Users
                    .Where(m => m.UserName == username || m.Email == username)
                    .Where(m => m.Status == 1 && m.Access == 1);
                if (acount.Count() == 0)
                {
                    ViewBag.Error = "<span class ='text-danger'>Mật khẩu này không chính xác</span>";
                }
                else
                {
                    var user = acount.First();
                    Session["User_Admin"] = user.UserName;
                    Session["User_Id"] = user.Id;
                    return RedirectToAction("Index", "Dashboard");
                    //Xủ lý login
                }
            }
            //Tên tài khoản với mật khẩu            
                return View();
            
        }
        public ActionResult Logout()
        {
                Session["User_Admin"] = "";
                Session["User_Id"] = "";
            return RedirectToAction("Login","Auth");
        }
    }
}