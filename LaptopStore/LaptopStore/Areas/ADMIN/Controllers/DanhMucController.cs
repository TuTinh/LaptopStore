using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Functions;
using LaptopStore.Models.Entities;

namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: ADMIN/DanhMuc
        public ActionResult Index()
        {
            var dm = new DanhMucFunction().GetDanhMucs();
            return View(dm);
        }

        // GET: ADMIN/DanhMuc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ADMIN/DanhMuc/Create
        public ActionResult Create()
        {  
            return View();
        }

        // POST: ADMIN/DanhMuc/Create
        [HttpPost]
        public ActionResult Create(DanhMuc model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new DanhMucFunction().Insert(model);
                if (result == 0)
                {
                    return View();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/DanhMuc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ADMIN/DanhMuc/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DanhMuc model)
        {
            try
            {
                // TODO: Add update logic here
                model.DanhmucID = id;
                var result = new DanhMucFunction().Update(model);
                //if (result == null)
                //{
                //    return View();
                //}
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/DanhMuc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ADMIN/DanhMuc/Delete/5
        
        public RedirectToRouteResult XoaDM(int id, DanhMuc model)
        {
            model.DanhmucID = id;
            var result = new DanhMucFunction().Delete(model);

            return RedirectToAction("Index");
        }
    }
}
