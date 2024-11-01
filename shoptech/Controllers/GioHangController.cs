using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Controllers
{
    public class GioHangController : Controller
    {
        BanHangDBContext db = new BanHangDBContext();
        // GET: GioHang
        public ActionResult Index()
        {
            
            int id = int.Parse(Request.QueryString["id"]);
            Mproduct sp = db.Products.Find(id);
            if (sp == null)
            {
                Response.Redirect("Index");
            }
            else
            {
                List<MyCart> giohang = (List<MyCart>)Session["GioHang"];
                if (giohang == null)
                {
                    MyCart mycart = new MyCart();
                    mycart.MaSP = sp.Id;
                    mycart.TenSP = sp.Name;
                    mycart.HinhSP = sp.Img;
                    mycart.GiaSP = sp.Price_sale;
                    mycart.SoLuong = 1;
                    mycart.Tien = sp.Price_sale;
                    giohang.Add(mycart);
                }
                else
                {
                    if (giohang.Exists(m => m.MaSP == id))
                    {
                        MyCart mycart = giohang.Find(m => m.MaSP == id);
                        mycart.SoLuong += 1;
                        mycart.Tien = (mycart.SoLuong + 1) * mycart.GiaSP;
                        giohang.Add(mycart);
                    }
                    else
                    {
                        MyCart mycart = new MyCart();
                        mycart.MaSP = sp.Id;
                        mycart.TenSP = sp.Name;
                        mycart.HinhSP = sp.Img;
                        mycart.GiaSP = sp.Price_sale;
                        mycart.SoLuong = 1;
                        mycart.Tien = sp.Price_sale;
                        giohang.Add(mycart);
                    }
                }
                Session["GioHang"] = giohang;
                Response.Redirect("Index");
            }
            return RedirectToAction("Index");

        }        
    }
}