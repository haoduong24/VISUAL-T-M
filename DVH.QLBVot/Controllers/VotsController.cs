using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DVH.QLBVot.Models;

namespace DVH.QLBVot.Controllers
{
    public class VotsController : Controller
    {
        private QUANLYBANVOTEntities db = new QUANLYBANVOTEntities();

        // GET: Vots
        public ActionResult Index()
        {
            var vots = db.Vots.Include(v => v.NhaCungCap);
            return View(vots.ToList());
        }

        // GET: Vots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vot vot = db.Vots.Find(id);
            if (vot == null)
            {
                return HttpNotFound();
            }
            return View(vot);
        }

        // GET: Vots/Create
        public ActionResult Create()
        {
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap");
            return View();
        }

        // POST: Vots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaVot,TenVot,LoaiVot,Gia,MaNhaCungCap")] Vot vot)
        {
            if (ModelState.IsValid)
            {
                db.Vots.Add(vot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", vot.MaNhaCungCap);
            return View(vot);
        }

        // GET: Vots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vot vot = db.Vots.Find(id);
            if (vot == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", vot.MaNhaCungCap);
            return View(vot);
        }

        // POST: Vots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaVot,TenVot,LoaiVot,Gia,MaNhaCungCap")] Vot vot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNhaCungCap = new SelectList(db.NhaCungCaps, "MaNhaCungCap", "TenNhaCungCap", vot.MaNhaCungCap);
            return View(vot);
        }

        // GET: Vots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vot vot = db.Vots.Find(id);
            if (vot == null)
            {
                return HttpNotFound();
            }
            return View(vot);
        }

        // POST: Vots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vot vot = db.Vots.Find(id);
            db.Vots.Remove(vot);
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
