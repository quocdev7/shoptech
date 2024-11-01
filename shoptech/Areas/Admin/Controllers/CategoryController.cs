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
    public class CategoryController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categogys.Where(m=>m.Status !=0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Categogys.Where(m => m.Status == 0).ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcategogy mcategogy = db.Categogys.Find(id);
            if (mcategogy == null)
            {
                return HttpNotFound();
            }
            return View(mcategogy);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.list = db.Categogys.Where(m => m.Status != 0).ToList();
            return View();
        }

        // POST: Admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mcategogy mcategogy)
        {
            var list = db.Categogys.ToList();
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mcategogy.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "category", null) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Create", "Category");
                }
                mcategogy.Slug = slug;
                mcategogy.Created_at = DateTime.Now;
                mcategogy.Created_by = int.Parse(Session["User_Id"].ToString());
                mcategogy.Updated_at = DateTime.Now;
                mcategogy.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Categogys.Add(mcategogy);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mcategogy.Id;
                link.Types = "category";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Categogys.Where(m => m.Status != 0).ToList();
            return View(mcategogy);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.list = db.Categogys.ToList();
            Mcategogy mcategogy = db.Categogys.Find(id);
            if (mcategogy == null)
            {
                return HttpNotFound();
            }
            return View(mcategogy);
        }

        // POST: Admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Mcategogy mcategogy)
        {
            if (ModelState.IsValid)
            {
                int id = mcategogy.Id;
                String slug = Mystring.ToAscii(mcategogy.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "category", id) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Edit", "Category");
                }
                mcategogy.Slug = slug;
                mcategogy.Created_at = DateTime.Now;
                mcategogy.Created_by = int.Parse(Session["User_Id"].ToString());
                mcategogy.Updated_at = DateTime.Now;
                mcategogy.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mcategogy).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = db.Links.Where(m => m.TableId == id && m.Types == "category").First();
                link.Slug = slug;
                db.Entry(link).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Categogys.ToList();
            return View(mcategogy);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mcategogy mcategogy = db.Categogys.Find(id);
            if (mcategogy == null)
            {
                return HttpNotFound();
            }
            return View(mcategogy);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mcategogy mcategogy = db.Categogys.Find(id);
            db.Categogys.Remove(mcategogy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mcategogy mcategogy = db.Categogys.Find(id);
            if (mcategogy == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mcategogy.Status = (mcategogy.Status == 1) ? 2 : 1;
            mcategogy.Updated_at = DateTime.Now;
            mcategogy.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mcategogy).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Category");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mcategogy mcategogy = db.Categogys.Find(id);
            if (mcategogy == null)
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
            mcategogy.Status = 0;
            mcategogy.Updated_at = DateTime.Now;
            mcategogy.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mcategogy).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
                return RedirectToAction("Index", "Category");
            }
            //Khôi phục
            public ActionResult Retrash(int id)
            {
                Mcategogy mcategogy = db.Categogys.Find(id);
                if (mcategogy == null)
                {
                    Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                    return RedirectToAction("Index");
                }
                mcategogy.Status = 2;
                mcategogy.Updated_at = DateTime.Now;
                mcategogy.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mcategogy).State = EntityState.Modified;
                db.SaveChanges();
                Thongbao.set_flash("Khôi phục thành công", "success");
                return RedirectToAction("Trash", "Category");
            }
    }
}
