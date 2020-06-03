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
    public class Cart
    {
        private List<CartItem> lineCollection = new List<CartItem>();

        public void AddItem(SanPham sp, int quantity)
        {
            CartItem line = lineCollection
                .Where(p => p.sanpham.SanphamID == sp.SanphamID)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartItem
                {
                    sanpham = sp,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
                if (line.Quantity <= 0)
                {
                    lineCollection.RemoveAll(l => l.sanpham.SanphamID == sp.SanphamID);
                }
            }
        }

        public void RemoveLine(SanPham sp)
        {
            lineCollection.RemoveAll(l => l.sanpham.SanphamID == sp.SanphamID);
        }

        public double? ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.sanpham.Giabandau * e.Quantity);
        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartItem> Lines
        {
            get { return lineCollection; }
        }

        public int TotalItem()
        {
            var sum = lineCollection.Sum(p => p.Quantity);
            return sum;
        }
    }
}