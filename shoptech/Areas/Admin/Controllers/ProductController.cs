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
    public class ProductController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Product
        public ActionResult Index()
        {
            return View(db.Products.Where(m => m.Status != 0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Products.Where(m => m.Status == 0).ToList());
        }
        public String CategoryName(int catid)
        {
            var row = db.Categogys.Find(catid);
            if (row == null)
            {
                return "Không cha";
            }
            return row.Name;
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            var list = db.Products.ToList();
            ViewBag.list = list;
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mproduct mproduct)
        {
            var list = db.Products.ToList();
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mproduct.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "product", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Product");
                }
                mproduct.Slug = slug;
                mproduct.Detail = mproduct.Name;
                mproduct.Created_at = DateTime.Now;
                mproduct.Created_by = int.Parse(Session["User_Id"].ToString());
                mproduct.Updated_at = DateTime.Now;
                mproduct.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Products.Add(mproduct);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mproduct.Id;
                link.Types = "product";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Products.Where(m => m.Status != 0).ToList();
            return View(mproduct);
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mproduct mproduct)
        {
            if (ModelState.IsValid)
            {
                int id = mproduct.Id;
                String slug = Mystring.ToAscii(mproduct.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "product", id) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Edit", "Product");
                }
                mproduct.Slug = slug;
                mproduct.Detail = mproduct.Name;
                mproduct.Created_at = DateTime.Now;
                mproduct.Created_by = int.Parse(Session["User_Id"].ToString());
                mproduct.Updated_at = DateTime.Now;
                mproduct.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mproduct).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mproduct.Id;
                link.Types = "product";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Products.ToList();
            return View(mproduct);
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                return HttpNotFound();
            }
            return View(mproduct);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            db.Products.Remove(mproduct);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mproduct.Status = (mproduct.Status == 1) ? 2 : 1;
            mproduct.Updated_at = DateTime.Now;
            mproduct.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Product");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            //Mẫu tin có cấp con
            int count_child = db.Categogys.Where(m => m.ParentId == id).Count();
            if (count_child != 0)
            {
                Thongbao.set_flash("Loại sản phẩm này có chứa cấp con", "danger");
                return RedirectToAction("Index");
            }
            //Sản phẩm có chứa loại sản phẩm này
            int count_product = db.Products.Where(m => m.CatId == id).Count();
            if (count_product != 0)
            {
                Thongbao.set_flash("sản phẩm còn chứa loại này", "danger");
                return RedirectToAction("Index");
            }
            mproduct.Status = 0;
            mproduct.Updated_at = DateTime.Now;
            mproduct.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "Product");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mproduct mproduct = db.Products.Find(id);
            if (mproduct == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mproduct.Status = 2;
            mproduct.Updated_at = DateTime.Now;
            mproduct.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mproduct).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Product");
        }
    }
}
