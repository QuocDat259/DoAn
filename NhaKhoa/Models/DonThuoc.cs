namespace NhaKhoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonThuoc")]
    public partial class DonThuoc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonThuoc()
        {
            HoaDon = new HashSet<HoaDon>();
            Thuoc = new HashSet<Thuoc>();
        }

        [Key]
        public int Id_donthuoc { get; set; }

        public string Mota { get; set; }

        public int? Soluong { get; set; }

        public int? Id_thuoc { get; set; }

        public int? Id_Phieudat { get; set; }

        public string Chandoan { get; set; }

        public virtual PhieuDatLich PhieuDatLich { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Thuoc> Thuoc { get; set; }
    }
}
