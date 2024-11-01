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
    public class MenuController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Menu
        public ActionResult Index()
        {
            ViewBag.ListCat = db.Categogys.Where(m => m.Status == 1).ToList();
            ViewBag.ListTopic = db.Topics.Where(m => m.Status == 1).ToList();
            ViewBag.ListPage = db.Posts.Where(m => m.Status == 1 && m.Type == "page").ToList();
            return View(db.Menus.Where(m => m.Status != 0).ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection dulieu)
        {
            //Xử lý thêm menu từ bảng Category
            if (!string.IsNullOrEmpty(dulieu["THEMCATEGORY"]))
            {
                if (!string.IsNullOrEmpty(dulieu["itemCat"]))
                {
                    var itemcat = dulieu["itemCat"];
                    var arrcat = itemcat.Split(',');
                    int dem = 0;
                    foreach (var rcat in arrcat)
                    {
                        //lấy id truy vấn mẫu tin Category
                        int id = int.Parse(rcat);
                        Mcategogy mcategogy = db.Categogys.Find(id);
                        //lấy thông tin và lưu menu
                        Mmenu mmenu = new Mmenu();
                        mmenu.Name = mcategogy.Name;
                        mmenu.Link = mcategogy.Slug;
                        mmenu.Type = "category";
                        mmenu.TableId = id;
                        mmenu.Orders = 1;
                        mmenu.Position = dulieu["position"];
                        mmenu.ParentId = 0;
                        mmenu.Status = 2;
                        mmenu.Created_at = DateTime.Now;
                        mmenu.Created_by = int.Parse(Session["User_Id"].ToString());
                        mmenu.Updated_at = DateTime.Now;
                        mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
                        db.Menus.Add(mmenu);
                        db.SaveChanges();
                        dem++;
                    }
                    Thongbao.set_flash("Đã thêm thành công" + dem + "Menu", "success");
                }
                else
                {
                    Thongbao.set_flash("Chưa chọn loại sản phẩm", "danger");
                }
            }

            //Kết thúc

            //Xử lý thêm menu từ bảng Topic
            if (!string.IsNullOrEmpty(dulieu["THEMTOPIC"]))
            {
                if (!string.IsNullOrEmpty(dulieu["itemTop"]))
                {
                    var itemtopic = dulieu["itemTop"];
                    var arrtopic = itemtopic.Split(',');
                    int dem = 0;
                    foreach (var rtop in arrtopic)
                    {
                        //lấy id truy vấn mẫu tin Topic
                        int id = int.Parse(rtop);
                        Mtopic mtopic = db.Topics.Find(id);
                        //lấy thông tin và lưu menu
                        Mmenu mmenu = new Mmenu();
                        mmenu.Name = mtopic.Name;
                        mmenu.Link = mtopic.Slug;
                        mmenu.Type = "topic";
                        mmenu.TableId = id;
                        mmenu.Orders = 1;
                        mmenu.Position = dulieu["position"];
                        mmenu.ParentId = 0;
                        mmenu.Status = 2;
                        mmenu.Created_at = DateTime.Now;
                        mmenu.Created_by = int.Parse(Session["User_Id"].ToString());
                        mmenu.Updated_at = DateTime.Now;
                        mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
                        db.Menus.Add(mmenu);
                        db.SaveChanges();
                        dem++;
                    }
                    Thongbao.set_flash("Đã thêm thành công" + dem + "Menu", "success");
                }
                else
                {
                    Thongbao.set_flash("Chưa chọn loại sản phẩm", "danger");
                }
            }

            //Kết thúc

            //Xử lý thêm menu từ bảng type=page
            if (!string.IsNullOrEmpty(dulieu["THEMPAGE"]))
            {
                if (!string.IsNullOrEmpty(dulieu["itemPage"]))
                {
                    var itempage = dulieu["itemPage"];
                    var arrpage = itempage.Split(',');
                    int dem = 0;
                    foreach (var rpa in arrpage)
                    {
                        //lấy id truy vấn mẫu tin Topic
                        int id = int.Parse(rpa);
                        Mpost mpost = db.Posts.Find(id);
                        //lấy thông tin và lưu menu
                        Mmenu mmenu = new Mmenu();
                        mmenu.Name = mpost.Title;
                        mmenu.Link = mpost.Slug;
                        mmenu.Type = "page";
                        mmenu.TableId = id;
                        mmenu.Orders = 1;
                        mmenu.Position = dulieu["position"];
                        mmenu.ParentId = 0;
                        mmenu.Status = 2;
                        mmenu.Created_at = DateTime.Now;
                        mmenu.Created_by = int.Parse(Session["User_Id"].ToString());
                        mmenu.Updated_at = DateTime.Now;
                        mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
                        db.Menus.Add(mmenu);
                        db.SaveChanges();
                        dem++;
                    }
                    Thongbao.set_flash("Đã thêm thành công" + dem + "Menu", "success");
                }
                else
                {
                    Thongbao.set_flash("Chưa chọn loại sản phẩm", "danger");
                }
            }

            //Kết thúc

            //Xử lý thêm menu từ bảng custom
            if (!string.IsNullOrEmpty(dulieu["THEMCUSTOM"]))
            {
                if (!string.IsNullOrEmpty(dulieu["name"]) && !string.IsNullOrEmpty(dulieu["link"]))
                {
                    Mmenu mmenu = new Mmenu();
                    mmenu.Name = dulieu["name"];
                    mmenu.Link = dulieu["link"];
                    mmenu.Type = "custom";
                    mmenu.Orders = 1;
                    mmenu.Position = dulieu["position"];
                    mmenu.ParentId = 0;
                    mmenu.Status = 2;
                    mmenu.Created_at = DateTime.Now;
                    mmenu.Created_by = int.Parse(Session["User_Id"].ToString());
                    mmenu.Updated_at = DateTime.Now;
                    mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
                    db.Menus.Add(mmenu);
                    db.SaveChanges();
                }
                else
                {
                    Thongbao.set_flash("Tên menu và liên kết không đề trống!", "success");
                }
            }

            //Kết thúc
            ViewBag.ListCat = db.Categogys.Where(m => m.Status == 1).ToList();
            ViewBag.ListTopic = db.Topics.Where(m => m.Status == 1).ToList();
            ViewBag.ListPage = db.Posts.Where(m => m.Status == 1 && m.Type == "page").ToList();
            return View(db.Menus.Where(m => m.Status != 0).ToList());

        }
        public ActionResult Trash()
        {
            return View(db.Menus.Where(m => m.Status == 0).ToList());
        }

        // GET: Admin/Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }



        // GET: Admin/Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.list = db.Menus.ToList();
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }

        // POST: Admin/Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mmenu mmenu)
        {
            if (ModelState.IsValid)
            {
                int id = mmenu.Id;
                String slug = Mystring.ToAscii(mmenu.Name);
                ValidationSlug valislug = new ValidationSlug();
                if (valislug.check_slug(slug, "menu", id) == false)
                {
                    Thongbao.set_flash("Slug này đã tồn tại!", "danger");
                    return RedirectToAction("Edit", "Menu");
                }
                mmenu.Link = slug;
                mmenu.TableId = 1;
                mmenu.Created_at = DateTime.Now;
                mmenu.Created_by = int.Parse(Session["User_Id"].ToString());
                mmenu.Updated_at = DateTime.Now;
                mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
                db.Entry(mmenu).State = EntityState.Modified;
                db.SaveChanges();
                Mlink link = new Mlink();
                link.Slug = slug;
                link.TableId = mmenu.Id;
                link.Types = "product";
                db.Links.Add(link);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.list = db.Menus.ToList();
            return View(mmenu);
        }

        // GET: Admin/Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                return HttpNotFound();
            }
            return View(mmenu);
        }

        // POST: Admin/Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            db.Menus.Remove(mmenu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xủ lý thay đổi trạng thái
        public ActionResult Status(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mmenu.Status = (mmenu.Status == 1) ? 2 : 1;
            mmenu.Updated_at = DateTime.Now;
            mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Thay đổi trạng thái thành công", "success");
            return RedirectToAction("Index", "Menu");
        }
        //Xủ lý xóa mẫu tin về rác Status =0
        public ActionResult Deltrash(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
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
            mmenu.Status = 0;
            mmenu.Updated_at = DateTime.Now;
            mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Xóa vào thùng rác thành công", "success");
            return RedirectToAction("Index", "Menu");
        }
        //Khôi phục
        public ActionResult Retrash(int id)
        {
            Mmenu mmenu = db.Menus.Find(id);
            if (mmenu == null)
            {
                Thongbao.set_flash("Loại sản phẩm này không tồn tại", "danger");
                return RedirectToAction("Index");
            }
            mmenu.Status = 2;
            mmenu.Updated_at = DateTime.Now;
            mmenu.Updated_by = int.Parse(Session["User_Id"].ToString());
            db.Entry(mmenu).State = EntityState.Modified;
            db.SaveChanges();
            Thongbao.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("Trash", "Menu");
        }

    }
}
