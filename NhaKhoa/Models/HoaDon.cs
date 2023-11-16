namespace NhaKhoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            VatTuSuDung = new HashSet<VatTuSuDung>();
            VatTuSuDung1 = new HashSet<VatTuSuDung>();
        }

        [Key]
        public int Id_hoadon { get; set; }

        public DateTime? NgayGio { get; set; }

        public double? TongTien { get; set; }

        public int? Id_donthuoc { get; set; }

        public int? id_hinhthuc { get; set; }

        public int? Id_dichvu { get; set; }

        [StringLength(128)]
        public string Id_benhnhan { get; set; }

        [StringLength(128)]
        public string Id_bacsi { get; set; }

        public int? Id_Vattu { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual DonThuoc DonThuoc { get; set; }

        public virtual HinhThucThanhToan HinhThucThanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatTuSuDung> VatTuSuDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VatTuSuDung> VatTuSuDung1 { get; set; }
    }
}
