using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Functions
{
    public class DonhangFunction
    {
        private LaptopStoreDB db;
        public DonhangFunction()
        {
            db = new LaptopStoreDB();
        }
        public IQueryable<DonHang> DonHangs
        {
            get { return db.DonHangs; }
        }
        public int Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.DonhangID;
        }
        public DonHang FindEntity(int ID_DH)
        {
            DonHang dbEntry = db.DonHangs.Find(ID_DH);
            return dbEntry;
        }
    }
}