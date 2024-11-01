using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Controllers
{
    public class LienheController : Controller
    {
        BanHangDBContext db = new BanHangDBContext();
        // GET: Lienhe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Mcontact contact)
        {
            if (ModelState.IsValid)
            {
                contact.Created_at = DateTime.Now;
                contact.Created_by = 1;
                contact.Updated_at = DateTime.Now;
                contact.Updated_by = 1;
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}