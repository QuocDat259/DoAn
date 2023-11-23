using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaKhoa.Models
{
    public class ThoiKhoaBieuViewModel
    {
        public List<Thu> DanhSachThu { get; set; }
        public List<ThoiKhoaBieu> DanhSachThoiKhoaBieu { get; set; }
    }
}