using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaptopStore.Models.DAO;
using LaptopStore.Models.Entities;
namespace LaptopStore.Models.Common
{
    public class CommonConstant
    {
        public static string USER_SESSION = "USER_SESSION";
        public static string ADM_SESSION = "AD_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CartSession = "CartSession";
        public static LoginModel USERNAME;
        public static LoginModel ADMIN;
        public static string CurrentCulture { set; get; }
        public static KhachHang UserName
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = HttpContext.Current.Session[USER_SESSION];
                if (sessionVar != null)
                {
                    return sessionVar as KhachHang;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[USER_SESSION] = value;
            }
        }
        public static KhachHang Admin
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = HttpContext.Current.Session[ADM_SESSION];
                if (sessionVar != null)
                {
                    return sessionVar as KhachHang;
                }
                return null;
            }
            set
            {
                HttpContext.Current.Session[ADM_SESSION] = value;
            }
        }
    }
}