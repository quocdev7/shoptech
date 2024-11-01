using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Controllers
{
    public class ModuleController : Controller
    {
        BanHangDBContext db = new BanHangDBContext();
        // GET: Module
        public ActionResult MainMenu()
        {
            var list = db.Menus
                .Where(m => m.ParentId == 0 && m.Status == 1)
                .Where(m => m.Position == "MainMenu")
                .OrderBy(m => m.Orders).ToList();
            return View("_MainMenu", list);
        }
        public ActionResult SubMainMenu(int parentid)
        {
            ViewBag.menuitem = db.Menus.Find(parentid);
            var list = db.Menus
                .Where(m => m.ParentId == parentid && m.Status == 1)
                .Where(m => m.Position == "MainMenu")
                .OrderBy(m => m.Orders);
            if (list.Count() != 0)
            {
                return View("_SubMainMenu1", list);
            }
            else
            {
                return View("_SubMainMenu2");
            }
        }
        public ActionResult SlideShow()
        {
            var list = db.Sliders
                .Where(m => m.Status == 1 && m.Position == "slidershow")
                .OrderByDescending(m => m.Orders).ToList();
            return View("_SlideShow", list);
        }
        public ActionResult ListCategory()
        {
            var list = db.Categogys
                .Where(m => m.Status == 1 && m.ParentId == 0)
                .OrderBy(m => m.Orders).ToList();
            return View("_ListCategory", list);
        }
        public ActionResult SubListCategory(int parentid)
        {
            ViewBag.menuitem = db.Categogys.Find(parentid);
            var list = db.Categogys
                .Where(m => m.Status == 1 && m.ParentId == parentid)
                .OrderBy(m => m.Orders).ToList();
            return View("_SubListCategory", list);
        }
    }
}