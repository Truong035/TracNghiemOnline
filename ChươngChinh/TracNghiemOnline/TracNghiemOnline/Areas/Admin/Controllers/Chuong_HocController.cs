using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TracNghiemOnline.Modell;

namespace TracNghiemOnline.Areas.Admin.Controllers
{
    public class Chuong_HocController : Controller
    {
        private TracNghiemOnlineDB db = new TracNghiemOnlineDB();

        // GET: Admin/Chuong_Hoc
        public ActionResult Index()
        {
            var chuong_Hoc = db.Chuong_Hoc.Include(c => c.MonHoc);
            return View(chuong_Hoc.ToList());
        }

        // GET: Admin/Chuong_Hoc/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong_Hoc chuong_Hoc = db.Chuong_Hoc.Find(id);
            if (chuong_Hoc == null)
            {
                return HttpNotFound();
            }
            return View(chuong_Hoc);
        }

        // GET: Admin/Chuong_Hoc/Create
        public ActionResult Create()
        {
            ViewBag.Ma_Mon = new SelectList(db.MonHocs, "Ma_Mon", "TenMon");
            return View();
        }

        // POST: Admin/Chuong_Hoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_Chuong,TenChuong,Ma_Mon")] Chuong_Hoc chuong_Hoc)
        {
            if (ModelState.IsValid)
            {
                db.Chuong_Hoc.Add(chuong_Hoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_Mon = new SelectList(db.MonHocs, "Ma_Mon", "TenMon", chuong_Hoc.Ma_Mon);
            return View(chuong_Hoc);
        }

        // GET: Admin/Chuong_Hoc/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong_Hoc chuong_Hoc = db.Chuong_Hoc.Find(id);
            if (chuong_Hoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_Mon = new SelectList(db.MonHocs, "Ma_Mon", "TenMon", chuong_Hoc.Ma_Mon);
            return View(chuong_Hoc);
        }

        // POST: Admin/Chuong_Hoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_Chuong,TenChuong,Ma_Mon")] Chuong_Hoc chuong_Hoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuong_Hoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_Mon = new SelectList(db.MonHocs, "Ma_Mon", "TenMon", chuong_Hoc.Ma_Mon);
            return View(chuong_Hoc);
        }

        // GET: Admin/Chuong_Hoc/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chuong_Hoc chuong_Hoc = db.Chuong_Hoc.Find(id);
            if (chuong_Hoc == null)
            {
                return HttpNotFound();
            }
            return View(chuong_Hoc);
        }

        // POST: Admin/Chuong_Hoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Chuong_Hoc chuong_Hoc = db.Chuong_Hoc.Find(id);
            db.Chuong_Hoc.Remove(chuong_Hoc);
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
