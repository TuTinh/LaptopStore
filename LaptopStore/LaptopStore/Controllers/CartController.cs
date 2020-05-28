using LaptopStore.Models.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models.Entities;
using LaptopStore.Models.DAO;
using LaptopStore.Models.Common;
using System.Web.Script.Serialization;

namespace LaptopStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public ActionResult AddItem(int IDSanpham, int Quantity)
        {
            var sanpham = new CartFunction().ViewDetail(IDSanpham);
            var cart = Session[CartSession];
            if (cart != null)
            {

                var list = (List<CartItem>)cart;
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
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.sanpham = sanpham;
                item.Quantity = Quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //gan vao sesion
                Session[CartSession] = list;
            }
            return RedirectToAction("Index","Cart");
        }
        public RedirectToRouteResult XoaKhoiGio(int sanphamID)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                CartItem itemXoa = list.FirstOrDefault(m => m.sanpham.SanphamID == sanphamID);
                if (itemXoa != null)
                {
                    list.Remove(itemXoa);
                }
                Session[CartSession] = list;
            }
            // List<CartItemModel> giohang = Session["CartSession"] as List<CartItemModel>;
            return RedirectToAction("Index");
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }
        /*
        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }*/
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
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
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}