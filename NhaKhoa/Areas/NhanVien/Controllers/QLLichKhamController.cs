using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaKhoa.Models;

namespace NhaKhoa.Areas.NhanVien.Controllers
{
    public class QLLichKhamController : Controller
    {
        private NhaKhoaModel db = new NhaKhoaModel();

        // GET: NhanVien/QLLichKham
        public ActionResult Index()
        {
            var phieuDatLich = db.PhieuDatLich.Include(p => p.AspNetUsers).Include(p => p.HinhThucThanhToan).Include(p => p.ThoiKhoaBieu);
            return View(phieuDatLich.ToList());
        }

        // GET: NhanVien/QLLichKham/Details/5
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

        // GET: NhanVien/QLLichKham/Delete/5
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

        // POST: NhanVien/QLLichKham/Delete/5
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
