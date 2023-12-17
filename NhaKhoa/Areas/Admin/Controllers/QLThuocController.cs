using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaKhoa.Models;

namespace NhaKhoa.Areas.Admin.Controllers
{
    public class QLThuocController : Controller
    {
        private NhaKhoaModel db = new NhaKhoaModel();

        // GET: Admin/QLTuoc
        public ActionResult Index()
        {
            var thuocList = db.Thuoc.ToList().Select(thuoc => new Thuoc
            {
                Id_thuoc = thuoc.Id_thuoc,
                Tenthuoc = thuoc.Tenthuoc,
                Mota = thuoc.Mota,
                Gia = thuoc.Gia,
                NgaySX = thuoc.NgaySX.HasValue ? thuoc.NgaySX.Value.Date : (DateTime?)null,
                HanSD = thuoc.HanSD.HasValue ? thuoc.HanSD.Value.Date : (DateTime?)null,
                Soluong = thuoc.Soluong,
                Thanhphan = thuoc.Thanhphan
            }).ToList();

            return View(thuocList);
        }

        // GET: Admin/QLTuoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // GET: Admin/QLTuoc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLTuoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_thuoc,Tenthuoc,Mota,Gia,NgaySX,HanSD,Soluong,Thanhphan")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Thuoc.Add(thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thuoc);
        }

        // GET: Admin/QLTuoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Admin/QLTuoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_thuoc,Tenthuoc,Mota,Gia,NgaySX,HanSD,Soluong,Thanhphan")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thuoc);
        }

        // GET: Admin/QLTuoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuoc thuoc = db.Thuoc.Find(id);
            if (thuoc == null)
            {
                return HttpNotFound();
            }
            return View(thuoc);
        }

        // POST: Admin/QLTuoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thuoc thuoc = db.Thuoc.Find(id);
            db.Thuoc.Remove(thuoc);
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
