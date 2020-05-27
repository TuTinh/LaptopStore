using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.DAO
{
    public class CartItem
    {
        public SanPham sanpham { get; set; }
        public int Quantity { set; get; }
    }
}