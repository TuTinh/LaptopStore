using LaptopStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopStore.Controllers
{
    public class LocController : Controller
    {
        // GET: Loc
        private LaptopStoreDB db = new LaptopStoreDB();
        public ActionResult Index(int tu, int den)
        {
            var products = db.SanPhams.ToList();
            var sp = products
                         .Where(p => p.Giabandau >= tu & p.Giabandau <= den)
                         .OrderBy(p => p.Tensanpham)
                         .ToList();
            return View();
        }
    }
}