﻿using System;
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
    [Authorize(Roles = "Admin")]
    public class DoanThuBanThuocController : Controller
    {
        private NhaKhoaModel db = new NhaKhoaModel();

        // GET: Admin/DoanThuBanThuoc
        public ActionResult Index()
        {
            var donThuoc = db.DonThuoc.Include(d => d.PhieuDatLich);
            return View(donThuoc.ToList());
        }

        // GET: Admin/DoanThuBanThuoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThuoc donThuoc = db.DonThuoc.Find(id);
            if (donThuoc == null)
            {
                return HttpNotFound();
            }
            return View(donThuoc);
        }

        // GET: Admin/DoanThuBanThuoc/Create
        public ActionResult Create()
        {
            ViewBag.Id_phieudat = new SelectList(db.PhieuDatLich, "Id_Phieudat", "IdNhaSi");
            return View();
        }

        // POST: Admin/DoanThuBanThuoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_donthuoc,Mota,Soluong,Id_thuoc,Id_phieudat,Chandoan")] DonThuoc donThuoc)
        {
            if (ModelState.IsValid)
            {
                db.DonThuoc.Add(donThuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_phieudat = new SelectList(db.PhieuDatLich, "Id_Phieudat", "IdNhaSi", donThuoc.Id_phieudat);
            return View(donThuoc);
        }

        // GET: Admin/DoanThuBanThuoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThuoc donThuoc = db.DonThuoc.Find(id);
            if (donThuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_phieudat = new SelectList(db.PhieuDatLich, "Id_Phieudat", "IdNhaSi", donThuoc.Id_phieudat);
            return View(donThuoc);
        }

        // POST: Admin/DoanThuBanThuoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_donthuoc,Mota,Soluong,Id_thuoc,Id_phieudat,Chandoan")] DonThuoc donThuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donThuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_phieudat = new SelectList(db.PhieuDatLich, "Id_Phieudat", "IdNhaSi", donThuoc.Id_phieudat);
            return View(donThuoc);
        }

        // GET: Admin/DoanThuBanThuoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonThuoc donThuoc = db.DonThuoc.Find(id);
            if (donThuoc == null)
            {
                return HttpNotFound();
            }
            return View(donThuoc);
        }

        // POST: Admin/DoanThuBanThuoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonThuoc donThuoc = db.DonThuoc.Find(id);
            db.DonThuoc.Remove(donThuoc);
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
