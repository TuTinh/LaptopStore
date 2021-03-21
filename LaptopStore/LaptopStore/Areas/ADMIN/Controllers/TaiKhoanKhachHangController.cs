using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Functions;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Common;

namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class TaiKhoanKhachHangController : Controller
    {
        // GET: ADMIN/TaiKhoanKhachHang
        public ActionResult Index()
        {
            var tk = new TaikhoanFunction().GetKhachHangs() ;
            return View(tk);
        }

        // GET: ADMIN/TaiKhoanKhachHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADMIN/TaiKhoanKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }
        // POST: ADMIN/TaiKhoanKhachHang/Create
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

        // GET: ADMIN/TaiKhoanKhachHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ADMIN/TaiKhoanKhachHang/Edit/5
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

        // GET: ADMIN/TaiKhoanKhachHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADMIN/TaiKhoanKhachHang/Delete/5
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
        public ActionResult LogoutAd()
        {
            Session[CommonConstant.ADM_SESSION] = null;
            return Redirect("/");
        }
    }
}
