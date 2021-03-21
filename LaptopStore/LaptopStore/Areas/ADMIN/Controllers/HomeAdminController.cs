using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Functions;
namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: ADMIN/Home
        public ActionResult Index()
        {
            ViewBag.SLKH = new TaikhoanFunction().SL_KH();
            ViewBag.SLSP = new TaikhoanFunction().SL_SP();
            ViewBag.SLDH = new TaikhoanFunction().SL_DH();
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }
    }
}