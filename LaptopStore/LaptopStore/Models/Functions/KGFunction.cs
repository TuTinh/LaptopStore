using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Functions
{
    public class KGFunction
    {
        private LaptopStoreDB context;
        public KGFunction()
        {
            context = new LaptopStoreDB();
        }
        public List<KhoangGia> khoangGias()
        {
            return context.KhoangGias.ToList();
        }
    }
}