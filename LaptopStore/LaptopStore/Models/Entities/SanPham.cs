namespace LaptopStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTDonHangs = new HashSet<CTDonHang>();
        }

        public int SanphamID { get; set; }

        public int? DanhmucID { get; set; }

        [StringLength(50)]
        public string Tensanpham { get; set; }

        public double? Giabandau { get; set; }

        public double? Trongluong { get; set; }

        [StringLength(50)]
        public string Mausac { get; set; }

        [StringLength(200)]
        public string Imagelink { get; set; }

        [StringLength(200)]
        public string Memory { get; set; }

        [StringLength(200)]
        public string Hedieuhanh { get; set; }

        [StringLength(200)]
        public string VGA { get; set; }

        [StringLength(200)]
        public string CPUZ { get; set; }

        [StringLength(200)]
        public string Battery { get; set; }

        [StringLength(200)]
        public string Phukiendikem { get; set; }

        [StringLength(50)]
        public string Chedobaohanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }
    }
}
