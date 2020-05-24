using LaptopStore.Models.Entities;
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
    }
}