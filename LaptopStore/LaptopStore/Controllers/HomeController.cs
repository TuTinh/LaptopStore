using LaptopStore.Models.Entities;
using LaptopStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopStore.Controllers
{
    public class HomeController : Controller
    {
        private LaptopStoreDB db;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult SPOfNew()
{
            var sp = new SanPhamFunction().SPOfNew();
            return PartialView("SPOfNew", sp);
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
    }
}