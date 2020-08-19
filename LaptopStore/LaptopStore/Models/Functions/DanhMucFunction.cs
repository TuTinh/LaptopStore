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
        public IQueryable<DanhMuc> DANHMUCs
        {
            get { return db.DanhMucs; }
        }
        public List<DanhMuc> GetDanhMucs()
        {
            return db.DanhMucs.ToList();
        }
        public int Insert(DanhMuc model)
        {
            DanhMuc dbEntry = db.DanhMucs.Find(model.DanhmucID);
            if (dbEntry != null)
            {
                return 0;

            }
            db.DanhMucs.Add(model);
            db.SaveChanges();
            return 1;
        }
        public int Update(DanhMuc model)
        {
            DanhMuc dbEntry = db.DanhMucs.Find(model.DanhmucID);
            if (dbEntry == null)
            {
                return 0;
            }
            dbEntry.DanhmucID = model.DanhmucID;
            dbEntry.Tendanhmuc = model.Tendanhmuc;

            db.SaveChanges();
            return 1;
        }
        public int Delete(DanhMuc model)
        {
            DanhMuc dbEntry = db.DanhMucs.Find(model.DanhmucID);
            if (dbEntry == null)
            {
                return 0;
            }
            db.DanhMucs.Remove(dbEntry);
            db.SaveChanges();
            return 1;
        }
        public DanhMuc FindEntity(int ID_DM)
        {
            DanhMuc dbEntry = db.DanhMucs.Find(ID_DM);
            return dbEntry;
        }
    }
}