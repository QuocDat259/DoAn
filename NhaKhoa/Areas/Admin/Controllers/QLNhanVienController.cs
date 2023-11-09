using Microsoft.AspNet.Identity;
using NhaKhoa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;


namespace NhaKhoa.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class QLNhanVienController : Controller
    {
        private Nhakhoa db = new Nhakhoa();
        // GET: Admin/QLNhanVien
        // GET: Admin/QLNhanVien
        public ActionResult Index(int? page, string searchString)
        {
            var roleName = "NhanVien";
            var userRole = db.AspNetRoles.SingleOrDefault(r => r.Name == roleName);

            if (userRole != null)
            {
                var users = userRole.AspNetUsers
                    .Where(u => string.IsNullOrEmpty(searchString) || u.FullName.ToLower().Contains(searchString.ToLower()))
                    .ToList();

                int pageSize = 5;
                int pageNumber = page ?? 1;

                var pagedUsers = users.ToPagedList(pageNumber, pageSize);

                ViewBag.SearchString = searchString;

                return View(pagedUsers);
            }

            return View(new List<AspNetUser>());
        }
        [HttpPost]
        public ActionResult TaoTaiKhoanNV()
        {
            return View();
        }
    }
}