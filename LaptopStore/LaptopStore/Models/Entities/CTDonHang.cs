namespace LaptopStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDonHang")]
    public partial class CTDonHang
    {
        public int CTDonhangID { get; set; }

        public int? SanphamID { get; set; }

        public int? DonhangID { get; set; }

        public int? Soluong { get; set; }

        public double? Dongia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
