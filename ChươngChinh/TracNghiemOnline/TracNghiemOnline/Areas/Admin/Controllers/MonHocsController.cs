﻿using System;
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
    public class MonHocsController : Controller
    {
        private TracNghiemOnlineDB db = new TracNghiemOnlineDB();

        // GET: Admin/MonHocs
        public ActionResult Index()
        {
            return View(db.MonHocs.ToList());
        }

        // GET: Admin/MonHocs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_Mon,TenMon")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.MonHocs.Add(monHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monHoc);
        }

        // GET: Admin/MonHocs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_Mon,TenMon")] MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monHoc);
        }

        // GET: Admin/MonHocs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonHoc monHoc = db.MonHocs.Find(id);
            if (monHoc == null)
            {
                return HttpNotFound();
            }
            return View(monHoc);
        }

        // POST: Admin/MonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MonHoc monHoc = db.MonHocs.Find(id);
            db.MonHocs.Remove(monHoc);
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
