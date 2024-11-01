using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;
using shopdodadung.Library;

namespace shopdodadung.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Topic
        public ActionResult Index()
        {
            return View(db.Topics.Where(m=>m.Status!=0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Topics.Where(m => m.Status == 0).ToList());
        }

        // GET: Admin/Topic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // GET: Admin/Topic/Create
        public ActionResult Create()
        {
            var list = db.Topics.ToList();
            ViewBag.list = list;
            return View();
        }

        // POST: Admin/Topic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mtopic mtopic)
        {
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mtopic.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "topic", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Topic");
                }
                mtopic.Slug = slug;
                mtopic.Created_at = DateTime.Now;
                mtopic.Created_by = int.Parse(Session["User_Id"].ToString());
                mtopic.Updated_at = DateTime.Now;
                mtopic.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Topics.Add(mtopic);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mtopic.Id;
                link.Types = "topic";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
            var list = db.Topics.ToList();
            ViewBag.list = list;
            return View(mtopic);
        }

        // GET: Admin/Topic/Edit/5
        public ActionResult Edit(int? id)
        {
            var list = db.Topics.ToList();
            ViewBag.list = list;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // POST: Admin/Topic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mtopic mtopic)
        {
            if (ModelState.IsValid)
            {
                int id = mtopic.Id;
                String slug = Mystring.ToAscii(mtopic.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "topic", id) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Edit", "Topic");
                }
                mtopic.Slug = slug;
                mtopic.Created_at = DateTime.Now;
                mtopic.Created_by = int.Parse(Session["User_Id"].ToString());
                mtopic.Updated_at = DateTime.Now;
                mtopic.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mtopic).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = db.Links.Where(m => m.TableId == id && m.Types == "topic").First();
                link.Slug = slug;
                db.Entry(link).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }   
            var list = db.Topics.ToList();
            ViewBag.list = list;
            return View(mtopic);
        }

        // GET: Admin/Topic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                return HttpNotFound();
            }
            return View(mtopic);
        }

        // POST: Admin/Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            db.Topics.Remove(mtopic);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mtopic.Status = (mtopic.Status == 1) ? 2 : 1;
            mtopic.Updated_at = DateTime.Now;
            mtopic.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Topic");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
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
            mtopic.Status = 0;
            mtopic.Updated_at = DateTime.Now;
            mtopic.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index","Topic");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mtopic mtopic = db.Topics.Find(id);
            if (mtopic == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mtopic.Status = 2;
            mtopic.Updated_at = DateTime.Now;
            mtopic.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mtopic).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Topic");
        }

    }
}
