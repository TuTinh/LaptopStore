using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.Common;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Functions
{
    public class TaikhoanFunction
    {
        private LaptopStoreDB context;
        public TaikhoanFunction()
        {
            context = new LaptopStoreDB();
        }
        public IQueryable<KhachHang> KhachHangs
        {
            get { return context.KhachHangs; }
        }
        public List<KhachHang> GetKhachHangs()
        {
            return context.KhachHangs.Where(x=>x.PhanquyenID ==2).ToList();
        }
        public int SL_KH()
        {
            return context.KhachHangs.Count(x=>x.PhanquyenID == 2 );
        }
        public int SL_DH()
        {
            return context.DonHangs.Count();
        }
        public int SL_SP()
        {
            return context.SanPhams.Count();
        }
        public int Insert(KhachHang model)
        {
            context.KhachHangs.Add(model);
            context.SaveChanges();
            return model.KhachhangID;
        }
        public int Update(KhachHang model)
        {
            KhachHang dbEntry = context.KhachHangs.Find(model.KhachhangID);
            if (dbEntry == null)
            {
                return 0;
            }
            dbEntry.Username = model.Username;
            dbEntry.Password = model.Password;
            dbEntry.Tenkhachhang = model.Tenkhachhang;
            dbEntry.Phone = model.Phone;
            dbEntry.Mail = model.Mail;
            dbEntry.Diachi = model.Diachi;
            context.SaveChanges();
            return 1;
        }
        public int Delete(KhachHang model)
        {
            KhachHang dbEntry = context.KhachHangs.Find(model.KhachhangID);
            if (dbEntry == null)
            {
                return 0;
            }
            context.KhachHangs.Remove(dbEntry);
            context.SaveChanges();
            return 1;
        }
        public int Login(string userName, string passWord)
        {
            var result = context.KhachHangs.SingleOrDefault(x => x.Username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == Encryptor.MD5Hash(passWord) )
                {
                    if(result.PhanquyenID == 2)
                        return 1;
                    else
                        return 2;
                }
                else return 0;
            }
        }
        public KhachHang FindEntity(int? ID_TK)
        {
            KhachHang dbEntry = context.KhachHangs.Find(ID_TK);
            return dbEntry;
        }
        public KhachHang GetById(string userName)
        {
            return context.KhachHangs.SingleOrDefault(x => x.Username == userName);
        }
        public bool CheckUsername(string username)
        {
            return context.KhachHangs.Count(x => x.Username == username) > 0;
        }
        public bool CheckMail(string mail)
        {
            return context.KhachHangs.Count(x => x.Mail == mail) > 0;
        }
        public int GetByID(string username)
        {
            var KH = context.KhachHangs.SingleOrDefault(x => x.Username == username);
            return KH.KhachhangID;
        }

    }
}