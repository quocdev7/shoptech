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
    public class PostsController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View(db.Posts.Where(m => m.Status != 0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Categogys.Where(m => m.Status == 0).ToList());
        }
        

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            var list = db.Posts.ToList();
            ViewBag.list = list;
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mpost mpost)
        {            
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mpost.Title);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "post", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Posts");
                }
                mpost.Slug = slug;
                mpost.CatId = 1;
                mpost.MetaDesc = "metadesc";
                mpost.MetaKey = "metakeyword";
                mpost.Created_at = DateTime.Now;
                mpost.Created_by = int.Parse(Session["User_Id"].ToString());
                mpost.Updated_at = DateTime.Now;
                mpost.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Posts.Add(mpost);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mpost.Id;
                link.Types = "post";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var list = db.Posts.ToList();
            ViewBag.list = list;
            return View(mpost);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.list = db.Posts.ToList();
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mpost mpost)
        {
            if (ModelState.IsValid)
            {
                int id = mpost.Id;
                String slug = Mystring.ToAscii(mpost.Title);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "post", id) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Edit", "Posts");
                }
                mpost.Slug = slug;
                mpost.CatId = 1;
                mpost.MetaDesc = "metadesc";
                mpost.MetaKey = "metakeyword";
                mpost.Created_at = DateTime.Now;
                mpost.Created_by = int.Parse(Session["User_Id"].ToString());
                mpost.Updated_at = DateTime.Now;
                mpost.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mpost).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mpost.Id;
                link.Types = "post";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var list = db.Posts.ToList();
            ViewBag.list = list;
            return View(mpost);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                return HttpNotFound();
            }
            return View(mpost);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            db.Posts.Remove(mpost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                Thongbao.set_flash("Bài viết này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mpost.Status = (mpost.Status == 1) ? 2 : 1;
            mpost.Updated_at = DateTime.Now;
            mpost.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Posts");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                Thongbao.set_flash("Bài viết này không tồn tại", "danger");
                return RedirectToAction("Index");
            }            
            //Bài viết có chứa loại bài viết này
            int count_post = db.Posts.Where(m => m.CatId == id).Count();
            if (count_post != 0)
            {
                Thongbao.set_flash("Bài viết còn chứa loại bài viết này", "danger");
                return RedirectToAction("Index");
            }
            mpost.Status = 0;
            mpost.Updated_at = DateTime.Now;
            mpost.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "Posts");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mpost mpost = db.Posts.Find(id);
            if (mpost == null)
            {
                Thongbao.set_flash("Bài viết này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mpost.Status = 2;
            mpost.Updated_at = DateTime.Now;
            mpost.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mpost).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Posts");
        }
    }
}
