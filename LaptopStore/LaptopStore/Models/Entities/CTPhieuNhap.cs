//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LaptopStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTPhieuNhap
    {
        public int CTphieunhapID { get; set; }
        public Nullable<int> PhieunhapID { get; set; }
        public Nullable<int> SanphamID { get; set; }
        public Nullable<int> Soluongnhap { get; set; }
        public Nullable<long> Dongia { get; set; }
        public Nullable<long> Thanhtien { get; set; }
    
        public virtual PhieuNhap PhieuNhap { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}