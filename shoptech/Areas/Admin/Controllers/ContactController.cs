using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Library;
using shopdodadung.Models;

namespace shopdodadung.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Contact
        public ActionResult Index()
        {
            return View(db.Contacts.Where(m => m.Status != 0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Contacts.Where(m => m.Status == 0).ToList());
        }

        // GET: Admin/Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contacts.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // GET: Admin/Contact/Create
        public ActionResult Create()
        {
            var list = db.Topics.ToList();
            ViewBag.list = list;
            return View();
        }

        // POST: Admin/Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mcontact mcontact)
        {            
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mcontact.Email);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "contact", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Contact");
                }
                mcontact.Email = slug;
                mcontact.Created_at = DateTime.Now;
                mcontact.Created_by = int.Parse(Session["User_Id"].ToString());
                mcontact.Updated_at = DateTime.Now;
                mcontact.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Contacts.Add(mcontact);
                db.SaveChanges();               
                return RedirectToAction("Index");
            }
            var list = db.Contacts.ToList();
            ViewBag.list = list;
            return View(mcontact);
        }

        // GET: Admin/Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            var list = db.Topics.ToList();
            ViewBag.list = list;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contacts.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // POST: Admin/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mcontact mcontact)
        {
            if (ModelState.IsValid)
            {
                int id = mcontact.Id;
                String slug = Mystring.ToAscii(mcontact.Email);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "contact", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Contact");
                }
                mcontact.Email = slug;
                mcontact.Created_at = DateTime.Now;
                mcontact.Created_by = int.Parse(Session["User_Id"].ToString());
                mcontact.Updated_at = DateTime.Now;
                mcontact.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mcontact).State = EntityState.Modified;
                db.SaveChanges();                
                return RedirectToAction("Index");
            }
            var list = db.Topics.ToList();
            ViewBag.list = list;
            return View(mcontact);
        }

        // GET: Admin/Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcontact mcontact = db.Contacts.Find(id);
            if (mcontact == null)
            {
                return HttpNotFound();
            }
            return View(mcontact);
        }

        // POST: Admin/Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mcontact mcontact = db.Contacts.Find(id);
            db.Contacts.Remove(mcontact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mcontact mcontact = db.Contacts.Find(id);
            if (mcontact == null)
            {
                Thongbao.set_flash("Liên hệ này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mcontact.Status = (mcontact.Status == 1) ? 2 : 1;
            mcontact.Updated_at = DateTime.Now;
            mcontact.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Contact");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mcontact mcontact = db.Contacts.Find(id);
            //if (mtopic == null)
            //{
            //    Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
            //    return RedirectToAction("Index");
            //}
            ////Mẫu tin có cấp con
            //int count_child = db.Topics.Where(m => m.ParentId == id).Count();
            //if (count_child != 0)
            //{
            //    Thongbao.set_flash("Loại sản phẩm này có chứa cấp con", "danger");
            //    return RedirectToAction("Index");
            //}
            ////Sản phẩm có chứa loại sản phẩm này
            //int count_product = db.Products.Where(m => m.CatId == id).Count();
            //if (count_product != 0)
            //{
            //    Thongbao.set_flash("sản phẩm còn chứa loại này", "danger");
            //    return RedirectToAction("Index");
            //}
            mcontact.Status = 0;
            mcontact.Updated_at = DateTime.Now;
            mcontact.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "Contact");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mcontact mcontact = db.Contacts.Find(id);
            if (mcontact == null)
            {
                Thongbao.set_flash("Liên hệ này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mcontact.Status = 2;
            mcontact.Updated_at = DateTime.Now;
            mcontact.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mcontact).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Contact");
        }
    }
}
