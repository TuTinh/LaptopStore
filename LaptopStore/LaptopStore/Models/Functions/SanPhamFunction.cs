using LaptopStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopStore.Models.Functions
{
    public class SanPhamFunction
    {
        private LaptopStoreDB db;
        public SanPhamFunction()
        {
            db = new LaptopStoreDB();
        }
        public IQueryable<SanPham> Sanphams
        {
            get { return db.SanPhams; }
        }
        public IQueryable<SanPham> SPOfNew()
        {
            var spnew = db.SanPhams.OrderByDescending(p => p.SanphamID).Take(6);
            return spnew;
        }
    }
}