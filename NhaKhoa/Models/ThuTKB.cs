using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaKhoa.Models
{
    public class ThuTKB
    {
        public string CurrentUserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<Thu> ThoiKhoaBieus { get; set; }
    }
}