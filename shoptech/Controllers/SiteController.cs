using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopdodadung.Models;

namespace shopdodadung.Controllers
{
    public class SiteController : Controller
    {
        BanHangDBContext db = new BanHangDBContext();
        // GET: Site
        public ActionResult Index(String Slug = "")
        {
            if (Slug == "")
            {
                return this.Home();
            }
            else
            {
                var row_link = db.Links.Where(m => m.Slug == Slug);
                if(row_link.Count()!=0)
                {
                    var link = row_link.First();
                    String types = link.Types;
                    switch (types)
                    {
                        case "category": { return this.ProductCategory(Slug); break; }
                        case "topic": { return this.PostTopic(Slug); break; }
                        case "page": { return this.PostPage(Slug); break; }
                        default: { return this.Erorr404(Slug); break; }
                    }
                }
                else
                {
                    int count_product = db.Products.Where(m => m.Slug == Slug).Count();
                    if(count_product!=0)
                    {
                        return this.ProductDetail(Slug);
                    }
                    else
                    {
                        int count_post = db.Posts.Where(m => m.Slug == Slug).Count();
                        if (count_post != 0)
                        {
                            return this.PostDetail(Slug);
                        }
                    }
                    return this.Erorr404(Slug);
                }                
            }
        }
        public ActionResult Home()
        {
            var listcat = db.Categogys
                .Where(m => m.ParentId == 0 && m.Status == 1).ToList();
            return View("Home",listcat);
        }
        public ActionResult Khac(String Slug)
        {
            return View("Index");
        }
        public ActionResult ProductHome(int catid)
        {
            List<int> listcatid = db.Categogys.Where(m => m.ParentId == catid)
                .Select(m => m.Id).ToList();
            listcatid.Add(catid);
            //Lấy
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .Take(4)
                .OrderByDescending(m => m.Created_at)
                .ToList();
            return View("_ProductHome", list);
        }
        public ActionResult Product()
        {
            var list = db.Products.Where(m => m.Status == 1)
                .OrderByDescending(m => m.Created_at)
                .ToList();
            return View("Product",list);
        }
        public ActionResult ProductCategory(String Slug)
        {
            var item = db.Categogys
                .Where(m => m.Slug == Slug)
                .First();
            ViewBag.Title = item.Name;
            List<int> listcatid = db.Categogys.Where(m => m.ParentId == item.Id)
                .Select(m => m.Id).ToList();
            listcatid.Add(item.Id);
            //lấy
            var list = db.Products
                .Where(m => m.Status == 1 && listcatid.Contains(m.CatId))
                .OrderByDescending(m => m.Created_at)
                .ToList();
            return View("ProductCategory",list);
        }
        public ActionResult ProductDetail(String Slug)
        {
            var product = db.Products
                .Where(m => m.Slug == Slug && m.Status == 1)
                .First();
            return View("ProductDetail",product);
        }
        public ActionResult Post()
        {

            return View("Post");
        }
        public ActionResult PostTopic(String Slug)
        {
            return View("PostTopic");
        }
        public ActionResult PostPage(String Slug)
        {
            var item = db.Posts
                .Where(m => m.Slug == Slug && m.Type == "page")
                .First();
            return View("PostPage",item);
        }
        public ActionResult PostDetail(String Slug)
        {
            var item = db.Posts
                .Where(m => m.Slug == Slug && m.Type == "page")
                .First();
            return View("PostDetail",item);
        }
        public ActionResult Erorr404(String Slug)
        {
            return View("Erorr404");
        }
    }
}