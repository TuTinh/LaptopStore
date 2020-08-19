using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Functions;


namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class DonHangController : Controller
    {
        // GET: ADMIN/DonHang
        public ActionResult Index()
        {
            var dh = new DonhangFunction().DonHangs.Where(p => p.DonhangID != null).OrderBy(x => x.Trangthai);
            return View(dh);
        }

        // GET: ADMIN/DonHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADMIN/DonHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN/DonHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/DonHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ADMIN/DonHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/DonHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADMIN/DonHang/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
