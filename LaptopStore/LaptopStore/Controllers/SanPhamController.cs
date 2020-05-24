using LaptopStore.Models.Entities;
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
        private LaptopStoreDB db;
        // GET: SanPham
        public ActionResult SanphamView(string keyword, int? page)
        {
            int pageNumber = (page ?? 1);
            int itemsPerPage = 9;

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
    }
}