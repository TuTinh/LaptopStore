namespace LaptopStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CTDonHangs = new HashSet<CTDonHang>();
        }

        public int DonhangID { get; set; }

        public int? KhachhangID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaylap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaynhanhang { get; set; }

        [StringLength(50)]
        public string Diachigiaohang { get; set; }

        [StringLength(11)]
        public string Phone { get; set; }

        public bool? Trangthai { get; set; }

        [StringLength(50)]
        public string Hotenkhachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
