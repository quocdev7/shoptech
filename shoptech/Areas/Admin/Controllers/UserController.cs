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
    public class UserController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/User
        public ActionResult Index()
        {
            return View(db.Users.Where(m => m.Status != 0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Users.Where(m => m.Status == 0).ToList());
        }

        // GET: Admin/User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // GET: Admin/User/Create
        public ActionResult Create()
        {
            var list = db.Users.ToList();
            ViewBag.list = list;
            return View();
        }

        // POST: Admin/User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Muser muser)
        {
            if (ModelState.IsValid)
            {
                String slug = muser.UserName;
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "user", null) == false)
                {
                    Thongbao.set_flash("Tài khoản này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "User");
                }
                muser.UserName = slug;
                muser.Access = 1;
                muser.Created_at = DateTime.Now;
                muser.Created_by = int.Parse(Session["User_Id"].ToString());
                muser.Updated_at = DateTime.Now;
                muser.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Users.Add(muser);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = muser.Id;
                link.Types = "user";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Users.Where(m => m.Status != 0).ToList();
            return View(muser);
        }

        // GET: Admin/User/Edit/5
        public ActionResult Edit(int? id)
        {
            var list = db.Users.ToList();
            ViewBag.list = list;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // POST: Admin/User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,UserName,Password,Email,Gender,Phone,Img,Access,Created_at,Created_by,Updated_at,Updated_by,Status")] Muser muser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var list = db.Users.ToList();
            ViewBag.list = list;
            return View(muser);
        }

        // GET: Admin/User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                return HttpNotFound();
            }
            return View(muser);
        }

        // POST: Admin/User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Muser muser = db.Users.Find(id);
            db.Users.Remove(muser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                Thongbao.set_flash("User này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            muser.Status = (muser.Status == 1) ? 2 : 1;
            muser.Updated_at = DateTime.Now;
            muser.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "User");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Muser muser = db.Users.Find(id);
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
            muser.Status = 0;
            muser.Updated_at = DateTime.Now;
            muser.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "User");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Muser muser = db.Users.Find(id);
            if (muser == null)
            {
                Thongbao.set_flash("User này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            muser.Status = 2;
            muser.Updated_at = DateTime.Now;
            muser.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(muser).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "User");
        }
    }
}
