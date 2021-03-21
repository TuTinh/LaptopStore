using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Functions;
using OfficeOpenXml;

namespace LaptopStore.Areas.ADMIN.Controllers
{
    public class ThongKeSPTheoTGController : Controller
    {
        // GET: ADMIN/ThongKeSPTheoTG
        public ActionResult Index(int i)
        {
            var model = new SanPhamFunction().GetSPTK(0, 2020);
            if (i == 1)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(1, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(2, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(3, 2020));
            }
            if (i == 2)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(5, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(6, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(4, 2020));
            }
            if (i == 3)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(7, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(8, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(9, 2020));
            }
            if (i == 4)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(12, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(10, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(11, 2020));
            }
            return View(model);
        }
        [ChildActionOnly]
        public PartialViewResult Header()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult DownloadExcel(int i)
        {
            var model = new SanPhamFunction().GetSPTK(0, 2020);
            if (i == 1)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(1, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(2, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(3, 2020));
            }
            if (i == 2)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(5, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(6, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(4, 2020));
            }
            if (i == 3)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(7, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(8, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(9, 2020));
            }
            if (i == 4)
            {
                model.AddRange(new SanPhamFunction().GetSPTK(12, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(10, 2020));
                model.AddRange(new SanPhamFunction().GetSPTK(11, 2020));
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage Ep = new ExcelPackage();
            ExcelWorksheet Sheet = Ep.Workbook.Worksheets.Add("Report");

            Sheet.Cells["A1"].Value = "Mã sản phẩm";
            Sheet.Cells["B1"].Value = "Tên danh mục";
            Sheet.Cells["C1"].Value = "Tên sản phẩm";
            Sheet.Cells["D1"].Value = "Giá sản phẩm";
            Sheet.Cells["E1"].Value = "Họ tên khách hàng";
            Sheet.Cells["F1"].Value = "Địa chỉ giao hàng";
            Sheet.Cells["G1"].Value = "Số lượng đã bán";

            int row = 2;
            foreach (var item in model)
            {
                Sheet.Cells[string.Format("A{0}", row)].Value = item.SanphamID;
                Sheet.Cells[string.Format("B{0}", row)].Value = item.Tendanhmuc;
                Sheet.Cells[string.Format("C{0}", row)].Value = item.Tensanpham;
                Sheet.Cells[string.Format("D{0}", row)].Value = item.Giabandau;
                Sheet.Cells[string.Format("E{0}", row)].Value = item.Hotenkhachhang;
                Sheet.Cells[string.Format("F{0}", row)].Value = item.Diachigiaohang;
                Sheet.Cells[string.Format("G{0}", row)].Value = item.Soluong;
                row++;
            }
            Sheet.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "Report.xlsx");
            Response.BinaryWrite(Ep.GetAsByteArray());
            Response.End();
            return RedirectToAction("/");
        }
    }
}