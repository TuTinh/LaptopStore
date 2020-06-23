using LaptopStore.Models.Common;
using LaptopStore.Models.DAO;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Functions;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopStore.Controllers
{
    public class SanPhamController : Controller
    {
        private LaptopStoreDB db = new LaptopStoreDB();
        // GET: SanPham
        public ActionResult SanphamView(string keyword, int? page)
        {
            int pageNumber = (page ?? 1);
            int itemsPerPage = 6;

            db = new LaptopStoreDB();

            var products = db.SanPhams.ToList();
            var pageSize = products.Count / itemsPerPage;

            var sp = products
                         .Where(p => p.SanphamID != null)
                         .OrderBy(p => p.Tensanpham)
                         .ToList();

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrWhiteSpace(keyword))
            {
                sp = sp.Where(p => !string.IsNullOrEmpty(p.Tensanpham) && p.Tensanpham.ToLower().Contains(keyword.ToLower()))
                    .ToList();
            }
            return View(sp.OrderBy(n => n.SanphamID).ToPagedList(pageNumber, itemsPerPage));
        }
        public ActionResult SPViewDM(int? id)
        {
            db = new LaptopStoreDB();
            DanhMuc dm = db.DanhMucs.Find(id);
            if (dm != null)
            {
                ViewBag.TenDM = dm.Tendanhmuc;
            }
            var sp = db.SanPhams.Where(p => p.DanhmucID == id);
            return View(sp);
        }
        public ActionResult SPViewKG(string keyword, int? page, int? cantren, int? canduoi)
        {
            int pageNumber = (page ?? 1);
            int itemsPerPage = 12;
            int? ct = cantren;
            int? cd = canduoi;
            var db = new SanPhamFunction();

            var products = db.Sanphams.ToList();
            var pageSize = products.Count / itemsPerPage;

            var sp = products
                         .Where(p => p.Giabandau > cd & p.Giabandau <= ct)
                         .OrderBy(p => p.Tensanpham)
                         .ToList();

            if (!string.IsNullOrEmpty(keyword) && !string.IsNullOrWhiteSpace(keyword))
            {
                sp = sp.Where(p => !string.IsNullOrEmpty(p.Tensanpham) && p.Tensanpham.ToLower().Contains(keyword.ToLower()))
                    .ToList();
            }
            return View("SPViewKG", sp.OrderBy(n => n.SanphamID).ToPagedList(pageNumber, itemsPerPage));

        }
        public ActionResult ChitietSP(int id)
        {
            var model = db.SanPhams.Where(x => x.SanphamID == id).FirstOrDefault();
            return View(model);
        }
        public ActionResult Header()
        {
            var dm = new DanhMucFunction().GetDanhMucs();
            return PartialView(dm);
        }
        public ActionResult Footer()
        {
            var dm = new DanhMucFunction().GetDanhMucs();
            return PartialView(dm);
        }
        public ActionResult Danhmuc()
        {
            var dm = new DanhMucFunction().GetDanhMucs();
            return PartialView(dm);
        }
        public ActionResult Khoanggia()
        {
            var dm = new KGFunction().khoangGias();
            return PartialView(dm);
        }
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = (Cart)Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
            }
            return PartialView(list);
        }
        public PartialViewResult SPcungDM(int id)
        {
            var sp = (from a in db.SanPhams
                      where (a.SanphamID == id)
                      select a).SingleOrDefault();
            var model = (from a in db.SanPhams
                         where (a.DanhmucID == sp.DanhmucID && a.SanphamID != sp.SanphamID)
                         select a).OrderByDescending(r => r.SanphamID).Take(7);
            return PartialView(model);
        }
    }
}