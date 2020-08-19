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
        public List<SanPham> GetSanPhams()
        {
            return db.SanPhams.ToList();
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
        public SanPham FindEntity(int ID_SP)
        {
            SanPham dbEntry = db.SanPhams.Find(ID_SP);
            return dbEntry;
        }
        //public SanPamTheoGia(int tu, int toi)
        //{
        //    List<SanPham> spTem = db.SanPhams\
        //}
        public int Insert(SanPham model)
        {
            SanPham dbEntry = db.SanPhams.Find(model.SanphamID);
            if (dbEntry != null)
            {
                return -1;

            }
            db.SanPhams.Add(model);
            db.SaveChanges();
            return model.SanphamID;
        }
        public int Update(SanPham model)
        {
            SanPham dbEntry = db.SanPhams.Find(model.SanphamID);
            if (dbEntry == null)
            {
                return -1;
            }
            dbEntry.SanphamID = model.SanphamID;
            dbEntry.DanhmucID = model.DanhmucID;
            dbEntry.Tensanpham = model.Tensanpham;
            dbEntry.Giabandau = model.Giabandau;
            dbEntry.Trongluong = model.Trongluong;
            dbEntry.Mausac = model.Mausac;
            dbEntry.Imagelink = model.Imagelink;
            dbEntry.Memory = model.Memory;
            dbEntry.Hedieuhanh = model.Hedieuhanh;
            dbEntry.VGA = model.VGA;
            dbEntry.CPUZ = model.CPUZ;
            dbEntry.Battery = model.Battery;
            dbEntry.Phukiendikem = model.Phukiendikem;
            dbEntry.Chedobaohanh = model.Chedobaohanh;

            db.SaveChanges();
            return model.SanphamID;
        }
        public int Delete(SanPham model)
        {
            SanPham dbEntry = db.SanPhams.Find(model.SanphamID);
            if (dbEntry != null)
            {
                db.SanPhams.Remove(dbEntry);
                db.SaveChanges();
            }
            return model.SanphamID;
        }
    }
}