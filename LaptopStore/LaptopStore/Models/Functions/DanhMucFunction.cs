using LaptopStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopStore.Models.Functions
{
    public class DanhMucFunction
    {
        private LaptopStoreDB db;
        public DanhMucFunction()
        {
            db = new LaptopStoreDB();
        }
        public List<DanhMuc> GetDanhMucs()
        {
            return db.DanhMucs.ToList();
        }
    }
}