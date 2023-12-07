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
    public class DoanhThuLichKhamController : Controller
    {
        private NhaKhoaModel db = new NhaKhoaModel();

        // GET: Admin/DoanhThuLichKham
        public ActionResult Index()
        {
            var phieuDatLich = db.PhieuDatLich.Include(p => p.AspNetUsers).Include(p => p.HinhThucThanhToan).Include(p => p.ThoiKhoaBieu);
            return View(phieuDatLich.ToList());
        }

        // GET: Admin/DoanhThuLichKham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatLich phieuDatLich = db.PhieuDatLich.Find(id);
            if (phieuDatLich == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatLich);
        }

        // GET: Admin/DoanhThuLichKham/Create
        public ActionResult Create()
        {
            ViewBag.IdBenhNhan = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Id_hinhthuc = new SelectList(db.HinhThucThanhToan, "Id_hinhthuc", "TenHinhThuc");
            ViewBag.Id_TKB = new SelectList(db.ThoiKhoaBieu, "Id_TKB", "Id_Nhasi");
            return View();
        }

        // POST: Admin/DoanhThuLichKham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Phieudat,NgayKham,Gia,Id_hinhthuc,IdNhaSi,IdBenhNhan,Id_TKB,STT,TrangThai,TrangThaiThanhToan")] PhieuDatLich phieuDatLich)
        {
            if (ModelState.IsValid)
            {
                db.PhieuDatLich.Add(phieuDatLich);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBenhNhan = new SelectList(db.AspNetUsers, "Id", "Email", phieuDatLich.IdBenhNhan);
            ViewBag.Id_hinhthuc = new SelectList(db.HinhThucThanhToan, "Id_hinhthuc", "TenHinhThuc", phieuDatLich.Id_hinhthuc);
            ViewBag.Id_TKB = new SelectList(db.ThoiKhoaBieu, "Id_TKB", "Id_Nhasi", phieuDatLich.Id_TKB);
            return View(phieuDatLich);
        }

        // GET: Admin/DoanhThuLichKham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatLich phieuDatLich = db.PhieuDatLich.Find(id);
            if (phieuDatLich == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBenhNhan = new SelectList(db.AspNetUsers, "Id", "Email", phieuDatLich.IdBenhNhan);
            ViewBag.Id_hinhthuc = new SelectList(db.HinhThucThanhToan, "Id_hinhthuc", "TenHinhThuc", phieuDatLich.Id_hinhthuc);
            ViewBag.Id_TKB = new SelectList(db.ThoiKhoaBieu, "Id_TKB", "Id_Nhasi", phieuDatLich.Id_TKB);
            return View(phieuDatLich);
        }

        // POST: Admin/DoanhThuLichKham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Phieudat,NgayKham,Gia,Id_hinhthuc,IdNhaSi,IdBenhNhan,Id_TKB,STT,TrangThai,TrangThaiThanhToan")] PhieuDatLich phieuDatLich)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuDatLich).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBenhNhan = new SelectList(db.AspNetUsers, "Id", "Email", phieuDatLich.IdBenhNhan);
            ViewBag.Id_hinhthuc = new SelectList(db.HinhThucThanhToan, "Id_hinhthuc", "TenHinhThuc", phieuDatLich.Id_hinhthuc);
            ViewBag.Id_TKB = new SelectList(db.ThoiKhoaBieu, "Id_TKB", "Id_Nhasi", phieuDatLich.Id_TKB);
            return View(phieuDatLich);
        }

        // GET: Admin/DoanhThuLichKham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuDatLich phieuDatLich = db.PhieuDatLich.Find(id);
            if (phieuDatLich == null)
            {
                return HttpNotFound();
            }
            return View(phieuDatLich);
        }

        // POST: Admin/DoanhThuLichKham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuDatLich phieuDatLich = db.PhieuDatLich.Find(id);
            db.PhieuDatLich.Remove(phieuDatLich);
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
