using LaptopStore.Models.Functions;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Entities;
using LaptopStore.Models.DAO;
using LaptopStore.Models.Common;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System;
namespace LaptopStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string USER_SESSION = "USER_SESSION";
        public ActionResult Index()
        {
            var list = new List<CartItem>();
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TotalItem = cart.TotalItem();
            }
            return View(list);
        }
        public ActionResult AddItem(int IDSanpham, int Quantity)
        {
            var sanpham = new CartFunction().ViewDetail(IDSanpham);
            var cart = (Cart)Session[CartSession];
            if (cart != null)
            {
                cart.AddItem(sanpham, 1);
                /*
                var list = cart.Lines;
                if (list.Exists(x => x.sanpham.SanphamID == IDSanpham))
                {
                    foreach (var item in list)
                    {
                        if (item.sanpham.SanphamID == IDSanpham)
                        {
                            item.Quantity += Quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.sanpham = sanpham;
                    item.Quantity = Quantity;
                    list.Add(item);
                }*/
                Session[CartSession] = cart;
            }
            else
            {
                cart = new Cart();
                cart.AddItem(sanpham, 1);
                /*
                var item = new CartItem();
                item.sanpham = sanpham;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);*/
                //gan vao sesion
                Session[CartSession] = cart;
            }
            return RedirectToAction("Index","Cart");
        }
        public RedirectToRouteResult XoaKhoiGio(int sanphamID)
        {
            var cart =(Cart)Session[CartSession];
            if (cart != null)
            {
                var list = cart.Lines.ToList();
                CartItem itemXoa = list.FirstOrDefault(m => m.sanpham.SanphamID == sanphamID);
                if (itemXoa != null)
                {
                    list.Remove(itemXoa);
                }
                Session[CartSession] = list;
            }
            // List<CartItemModel> giohang = Session["CartSession"] as List<CartItemModel>;
            return RedirectToAction("Index", "Cart");
        }
        private const string CartSession = "CartSession";

        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (Cart)Session[CartSession];

            foreach (var item in sessionCart.Lines)
            {
                var jsonItem = jsonCart.FirstOrDefault(x => x.sanpham.SanphamID == item.sanpham.SanphamID);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public ActionResult Payment(string diachiadd, string mobileadd,  DateTime dateout)
        {
            // A
            var order = new DonHang();
            order.Ngaylap = DateTime.Now;
            order.Diachigiaohang = diachiadd;
            order.Phone = mobileadd;
            order.Trangthai = true;
            DateTime? date = null;
            DateTime temp;
            order.Ngaynhanhang = dateout;

            //if (DateTime.TryParse(dateout, out temp))
            //{
            //    if (temp != null)
            //        date = temp;
            //}

            //if (date != null)
            //    order.Ngaynhanhang = date.Value;


            //nếu login
            if (CommonConstant.USERNAME != null)
            {
                order.KhachhangID = new TaikhoanFunction().GetByID(CommonConstant.USERNAME.username);

                var account = new TaikhoanFunction().FindEntity(order.KhachhangID);
                order.Hotenkhachhang = account.Tenkhachhang;
            }
            try
            {
                var id = new DonhangFunction().Insert(order);
                var cart = (Cart)Session["CartSession"];
                var detailDao = new CTDonhangFunction();
                foreach (var item in cart.Lines)
                {
                    var orderDetail = new CTDonHang();
                    orderDetail.SanphamID = item.sanpham.SanphamID;
                    orderDetail.DonhangID = id;
                    orderDetail.Soluong = item.Quantity;
                    orderDetail.Dongia = (item.sanpham.Giabandau * item.Quantity);
                    detailDao.Insert(orderDetail);
                }
                Session["CartSession"] = null;
            }
            catch (Exception ex)
            {
                //ghi log
                return RedirectToAction("Loi"); // action Loi ở đâu?
            }

            return RedirectToAction("MuaHangThanhCong", "Cart");
        }

        public ActionResult Checkout()
        {
            var cart = (Cart)Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
                ViewBag.TongTien = cart.ComputeTotalValue();
                ViewBag.TotalItem = cart.TotalItem();
            }
            return View(list);
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
            var cart = (Cart)Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = cart.Lines.ToList();
            }
            return PartialView(list);
        }
        public ActionResult MuaHangThanhCong()
        {
            return View();
        }
    }
}