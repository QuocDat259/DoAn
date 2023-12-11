using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaKhoa.Models
{
    public class LapDonThuocViewModel
    {
        public DonThuoc DonThuoc { get; set; }
        public List<ThuocCheckBox> Thuocs { get; set; }
    }
}