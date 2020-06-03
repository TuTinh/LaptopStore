using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Functions
{
    public class CartFunction
    {
        private LaptopStoreDB context = null;
        public CartFunction()
        {
            context = new LaptopStoreDB();
        }
        public SanPham ViewDetail(long id)
        {
            return context.SanPhams.Find(id);
        }
    }
}