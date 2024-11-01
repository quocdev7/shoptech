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
    public class OrderdetailController : Controller
    {
        private BanHangDBContext db = new BanHangDBContext();

        // GET: Admin/Orderdetail
        public ActionResult Index()
        {
            return View(db.Orderdetails.ToList());
        }

        // GET: Admin/Orderdetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morderdetail morderdetail = db.Orderdetails.Find(id);
            if (morderdetail == null)
            {
                return HttpNotFound();
            }
            return View(morderdetail);
        }

        // GET: Admin/Orderdetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Orderdetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderId,ProductId,Price,Quantity,Amount")] Morderdetail morderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Orderdetails.Add(morderdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(morderdetail);
        }

        // GET: Admin/Orderdetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morderdetail morderdetail = db.Orderdetails.Find(id);
            if (morderdetail == null)
            {
                return HttpNotFound();
            }
            return View(morderdetail);
        }

        // POST: Admin/Orderdetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,ProductId,Price,Quantity,Amount")] Morderdetail morderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(morderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(morderdetail);
        }

        // GET: Admin/Orderdetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Morderdetail morderdetail = db.Orderdetails.Find(id);
            if (morderdetail == null)
            {
                return HttpNotFound();
            }
            return View(morderdetail);
        }

        // POST: Admin/Orderdetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Morderdetail morderdetail = db.Orderdetails.Find(id);
            db.Orderdetails.Remove(morderdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
