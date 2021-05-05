using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Functions;
using System.IO;


namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: ADMIN/SanPham
        public ActionResult Index()
        {
            var sp = new SanPhamFunction().GetSanPhams();
            return View(sp);
        }

        // GET: ADMIN/SanPham/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: ADMIN/SanPham/Create
        public ActionResult Create()
        {
            var dao = new DanhMucFunction().DANHMUCs.Where(p => p.Tendanhmuc != null);
            ViewBag.DanhmucID = new SelectList(dao, "DanhmucID", "Tendanhmuc", null);
            return View();
        }

        // POST: ADMIN/SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham model, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add insert logic here
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/laptop"), fileName);
                    file.SaveAs(path);
                    //     ModelState.Clear();
                    // TODO: Add insert logic here
                    model.Imagelink = fileName;
                    SanPhamFunction _sanphamF = new SanPhamFunction();
                    _sanphamF.Insert(model);
                    // Upload File đẩy về Server
                }
                return RedirectToAction("Index");
                }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/SanPham/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new SanPhamFunction().FindEntity(id);
            var dao = new DanhMucFunction().DANHMUCs;
            ViewBag.DanhmucID = new SelectList(dao, "DanhmucID", "Tendanhmuc", model.DanhmucID);
            ViewBag.Tendanhmuc = model.DanhMuc.Tendanhmuc;
            var test = new SelectList(dao, "DanhmucID", "Tendanhmuc", model.DanhmucID);
            return View(model);
        }

        // POST: ADMIN/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SanPham model, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/images/laptop"), fileName);
                    file.SaveAs(path);
                    //     ModelState.Clear();
                    // TODO: Add insert logic here
                    model.Imagelink = fileName;
                    SanPhamFunction _sanphamF = new SanPhamFunction();
                    _sanphamF.Update(model);
                    // Upload File đẩy về Server
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ADMIN/SanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }
        // POST: ADMIN/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SanPham model)
        {
            try
            {
                // TODO: Add delete logic here
                model.SanphamID = id;
                var result = new SanPhamFunction().Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public RedirectToRouteResult XoaSP(int id, SanPham model)
        {
            model.SanphamID = id;
            var result = new SanPhamFunction().Delete(model);

            return RedirectToAction("Index");
        }
    }
}
