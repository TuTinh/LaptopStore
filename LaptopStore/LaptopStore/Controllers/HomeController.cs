using LaptopStore.Models.Common;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.DAO;
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
        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart =(Cart) Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
            }
            return PartialView(list);
        }
    }
}