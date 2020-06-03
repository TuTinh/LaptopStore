using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Functions
{
    public class CTDonhangFunction
    {
        private LaptopStoreDB db;
        public CTDonhangFunction()
        {
            db = new LaptopStoreDB();
        }
        public IQueryable<CTDonHang> CTDonHangs
        {
            get { return db.CTDonHangs; }
        }
        public int Insert(CTDonHang model)
        {
            CTDonHang dbEntry = db.CTDonHangs.Find(model.CTDonhangID);
            if (dbEntry != null)
            {
                return 0;

            }
            db.CTDonHangs.Add(model);
            db.SaveChanges();
            return 1;
        }
        public CTDonHang FindEntity(int ID_CTDH)
        {
            CTDonHang dbEntry = db.CTDonHangs.Find(ID_CTDH);
            return dbEntry;
        }
    }
}