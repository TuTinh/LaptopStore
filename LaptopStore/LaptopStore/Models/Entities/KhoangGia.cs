namespace LaptopStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhoangGia")]
    public partial class KhoangGia
    {
        public int KhoanggiaID { get; set; }

        public decimal? Giatren { get; set; }

        public decimal? Giaduoi { get; set; }
    }
}
