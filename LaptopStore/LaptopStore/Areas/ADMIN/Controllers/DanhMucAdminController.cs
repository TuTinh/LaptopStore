using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Functions;
using LaptopStore.Models.Entities;
using OfficeOpenXml;

namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class DanhMucAdminController : Controller
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
            var model = new DanhMucFunction().FindEntity(id);
            return View(model);
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
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
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
        [HttpPost]
        public ActionResult DownloadExcel()
        {
            var collection = new DanhMucFunction().GetDanhMucs();
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");
            Sheet.Cells["A1"].Value = "Mã danh mục";
            Sheet.Cells["B1"].Value = "Tên danh mục";
            int row = 2;
            foreach (var item in collection)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.DanhmucID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Tendanhmuc;
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
            return RedirectToAction("Index");
        }
    }
}
