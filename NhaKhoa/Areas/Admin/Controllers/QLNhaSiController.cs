using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using NhaKhoa.Models;
using System.Threading.Tasks;

namespace NhaKhoa.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLNhaSiController : Controller
    {
        private NhaKhoaModel db = new NhaKhoaModel();
        private readonly UserManager<ApplicationUser> _userManager;
        public QLNhaSiController()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        // GET: Admin/QLNhanVien
        public ActionResult Index()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            // Lấy thông tin người dùng đã đăng nhập
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);
            
            // Lấy danh sách người dùng thuộc vai trò "NhaSi"
            var nhanVienUsers = userManager.Users.Where(u => u.Roles.Any(r => r.RoleId == "2")).ToList();
            ViewBag.HinhAnh = user.HinhAnh;
            return View(nhanVienUsers);
        }


        // GET: Admin/QLNhaSi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // GET: Admin/QLNhaSi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/QLNhaSi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.UserName,
                    GioiTinh = model.GioiTinh,
                    DiaChi = model.DiaChi,
                    NgaySinh = model.NgaySinh,
                    NgheNghiep = model.NgheNghiep,
                    NgayTao = model.NgayTao,
                    CCCD = model.CCCD,
                    FullName = model.FullName
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Gán quyền "NhaSi" cho tài khoản người dùng
                    await _userManager.AddToRoleAsync(user.Id, "NhaSi");
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(model);
        }

        // GET: Admin/QLNhaSi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/QLNhaSi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,GioiTinh,DiaChi,Trangthai,Ngaysinh,NgheNghiep,NgayTao,Bangcap,CCCD,FullName")] AspNetUsers aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aspNetUser);
        }

        // GET: Admin/QLNhaSi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUsers aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }

        // POST: Admin/QLNhaSi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AspNetUsers aspNetUser = db.AspNetUsers.Find(id);
            db.AspNetUsers.Remove(aspNetUser);
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
        public ActionResult TKB()
        {
            try
            {
                var thoiKhoaBieu = db.ThoiKhoaBieu.ToList();

                if (thoiKhoaBieu == null || !thoiKhoaBieu.Any())
                {
                    // Xử lý khi không có dữ liệu
                    return View("ErrorView"); // Thay "ErrorView" bằng tên view hiển thị thông báo lỗi
                }

                return View(thoiKhoaBieu);
            }
            catch (Exception)
            {
                // Xử lý exception, log và hiển thị thông báo lỗi
                return View("ErrorView"); // Thay "ErrorView" bằng tên view hiển thị thông báo lỗi
            }
        }
        public ActionResult ThemThoiKhoaBieu()
        {
            ViewBag.ListPhong = new SelectList(db.Phong, "Id_Phong", "TenPhong");
            ViewBag.ListNhaSi = new SelectList(db.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Id == "2")), "Id", "FullName");
            ViewBag.ListKhungGio = new SelectList(db.KhungGio, "Id_khunggio", "TenCa");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemThoiKhoaBieu(ThoiKhoaBieu thoiKhoaBieu)
        {
            if (ModelState.IsValid)
            {
                // Lấy giá trị của trường Thu từ trường NgayLamViec
                thoiKhoaBieu.Thu = LayThuTuNgay(thoiKhoaBieu.NgayLamViec);

                // Thêm mới vào cơ sở dữ liệu và chuyển hướng
                db.ThoiKhoaBieu.Add(thoiKhoaBieu);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            // Nếu ModelState không hợp lệ, hiển thị lại view với thông báo lỗi và danh sách dropdown đã chọn
            ViewBag.ListPhong = new SelectList(db.Phong.Select(p => new { p.Id_Phong, p.TenPhong }), "Id_Phong", "TenPhong");
            ViewBag.ListNhaSi = new SelectList(db.AspNetUsers.Where(u => u.AspNetRoles.Any(r => r.Id == "Id_of_NhaSi_Role")), "Id", "FullName", thoiKhoaBieu.Id_Nhasi);
            ViewBag.ListKhungGio = new SelectList(db.KhungGio, "Id_khunggio", "TenCa", thoiKhoaBieu.Id_khunggio);

            return View(thoiKhoaBieu);
        }
        private string LayThuTuNgay(DateTime? ngayLamViec)
        {
            if (ngayLamViec.HasValue)
            {
                // Lấy thứ từ ngày
                string[] daysOfWeek = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
                return daysOfWeek[(int)ngayLamViec.Value.DayOfWeek];
            }

            // Trường hợp ngày làm việc là null, bạn có thể xử lý hoặc trả về giá trị mặc định
            return "Ngày làm việc không xác định";
        }

    }
}
