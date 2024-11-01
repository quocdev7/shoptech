using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Slider
        public ActionResult Index()
        {
            return View(db.Sliders.Where(m => m.Status != 0).ToList());
        }
        public ActionResult Trash()
        {
            return View(db.Sliders.Where(m => m.Status == 0).ToList());
        }


        // GET: Admin/Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            ViewBag.list = db.Sliders.Where(m => m.Status != 0).ToList();
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mslider mslider)
        {
            var list = db.Sliders.ToList();
            ViewBag.list = list;
            if (ModelState.IsValid)
            {
                String slug = Mystring.ToAscii(mslider.Name);
                mslider.Link = slug;
                mslider.Created_at = DateTime.Now;
                mslider.Created_by = int.Parse(Session["User_Id"].ToString());
                mslider.Updated_at = DateTime.Now;
                mslider.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Sliders.Add(mslider);
                db.SaveChanges();
                //Lưu vào link
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mslider.Id;
                link.Types = "slishow";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Sliders.Where(m => m.Status != 0).ToList();
            return View(mslider);
        }

        // GET: Admin/Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.list = db.Sliders.ToList();
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mslider mslider)
        {
            if (ModelState.IsValid)
            {
                int id = mslider.Id;
                String slug = Mystring.ToAscii(mslider.Name);
                mslider.Link = slug;
                mslider.Created_at = DateTime.Now;
                mslider.Created_by = int.Parse(Session["User_Id"].ToString());
                mslider.Updated_at = DateTime.Now;
                mslider.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mslider).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mslider.Id;
                link.Types = "slider";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Sliders.ToList();
            return View(mslider);
        }

        // GET: Admin/Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            db.Sliders.Remove(mslider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mslider.Status = (mslider.Status == 1) ? 2 : 1;
            mslider.Updated_at = DateTime.Now;
            mslider.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Slider");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);

            mslider.Status = 0;
            mslider.Updated_at = DateTime.Now;
            mslider.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "Slider");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mslider.Status = 2;
            mslider.Updated_at = DateTime.Now;
            mslider.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Slider");
        }
    }
}
