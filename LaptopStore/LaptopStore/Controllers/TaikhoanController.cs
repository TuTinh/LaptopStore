using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopStore.Models;
using LaptopStore.Models.Entities;
using LaptopStore.Models.Common;
using LaptopStore.Models.Functions;
using LaptopStore.Models.DAO;
namespace LaptopStore.Controllers
{
    public class TaikhoanController : Controller
    {
        // GET: Taikhoan
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var KT = new TaikhoanFunction();
                if (KT.CheckUsername(model.username))
                {
                    ModelState.AddModelError("", "Tài khoản đã tồn tại");
                }
                else if (KT.CheckMail(model.mail))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new KhachHang();
                    user.Username = model.username;
                    user.Password = Encryptor.MD5Hash(model.password);
                    user.Tenkhachhang = model.tentk;
                    user.Phone = model.phone;
                    user.Diachi = model.diachi;
                    user.Mail = model.mail;
                    var result = KT.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng kí thành công !!!";
                        model = new CreateModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng kí không thành công");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var KT = new TaikhoanFunction();
                var result = KT.Login(model.username, model.password);
                if (result == 1)
                {
                    var user = KT.GetById(model.username);
                    var usersession = new LoginModel();
                    usersession.username = user.Username;
                    usersession.password = user.Password;
                    Session.Add(CommonConstant.USER_SESSION, usersession);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
            }
            return View(model);
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
        // [HttpPost]
        /*public ActionResult Create(TAIKHOAN model)
        {
            try
            {
                // TODO: Add insert logic here
                var result = new TaikhoanFunction().Insert(model);
                if (result == 0)
                {
                    return View();
                }
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }*/
    }
}