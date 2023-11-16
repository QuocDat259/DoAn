namespace NhaKhoa.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuDatLich")]
    public partial class PhieuDatLich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuDatLich()
        {
            LichKham = new HashSet<LichKham>();
            PhiKham = new HashSet<PhiKham>();
        }

        [Key]
        public int Id_Phieudat { get; set; }

        public DateTime? NgayKham { get; set; }

        public double? Gia { get; set; }

        public int? Id_hinhthuc { get; set; }

        [StringLength(128)]
        public string IdNhaSi { get; set; }

        [StringLength(128)]
        public string IdBenhNhan { get; set; }

        public int? Id_kTKB { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichKham> LichKham { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhiKham> PhiKham { get; set; }
    }
}
