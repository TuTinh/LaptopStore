using LaptopStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaptopStore.Models.Functions
{
    public class DonHangFunction
    {
        private LaptopStoreDB db;
        public DonHangFunction()
        {
            db = new LaptopStoreDB();
        }
        public IQueryable<DonHang> donHangs
        {
            get { return db.DonHangs; }
        }
        public int Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.DonhangID;
        }
        public int Update(DonHang donHang)
        {
            DonHang dbEntry = db.DonHangs.Find(donHang.DonhangID);
            if (dbEntry == null)
            {
                return 0;
            }
            dbEntry.KhachhangID = donHang.KhachhangID;
            dbEntry.Ngaylap = donHang.Ngaylap;
            dbEntry.Ngaynhanhang = donHang.Ngaynhanhang;
            dbEntry.Diachigiaohang = donHang.Diachigiaohang;
            dbEntry.Phone = donHang.Phone;
            dbEntry.Trangthai = donHang.Trangthai;
            dbEntry.Hotenkhachhang = donHang.Hotenkhachhang;

            db.SaveChanges();
            return 1;
        }
        public int Delete(DonHang donHang)
        {
            DonHang dbEntry = db.DonHangs.Find(donHang.DonhangID);
            if (dbEntry == null)
            {
                return 0;
            }
            db.DonHangs.Remove(dbEntry);
            db.SaveChanges();
            return 1;
        }

        public DonHang FindEntity(int donHangID)
        {
            DonHang dbEntry = db.DonHangs.Find(donHangID);
            return dbEntry;
        }
    }
}