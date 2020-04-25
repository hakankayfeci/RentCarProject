using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RCP.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Profile",
              url: "Profil",
              defaults: new { controller = "User", action = "Profile", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "ForgetPassword",
              url: "SifremiUnuttum",
              defaults: new { controller = "User", action = "ForgetPassword", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "login",
              url: "GirisYap",
              defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "register",
              url: "KayitOl",
              defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "dashboard",
              url: "Dashboard",
              defaults: new { controller = "Admin", action = "Dashboard", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "AdvertAdd",
              url: "ilanekle",
              defaults: new { controller = "Admin", action = "AdvertAdd", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "BlogList",
              url: "BlogListele",
              defaults: new { controller = "Admin", action = "BlogList", id = UrlParameter.Optional }
              );
            routes.MapRoute(
              name: "CarList",
              url: "ArabaListele",
              defaults: new { controller = "Admin", action = "CarList", id = UrlParameter.Optional }
              );
            routes.MapRoute(
               name: "İletisim",
               url: "Iletisim",
               defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
               );
            routes.MapRoute(
               name: "Anasayfa",
               url: "Anasayfa",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
               );
            routes.MapRoute(
               name: "ArabaDetayı",
               url: "ArabaDetayi",
               defaults: new { controller = "Cars", action = "CarDetail", id = UrlParameter.Optional }
               );
            routes.MapRoute(
               name: "Araba",
               url: "ilanlar",
               defaults: new { controller = "Cars", action = "Cars", id = UrlParameter.Optional }
               );
            routes.MapRoute(
               name: "Hakkimizda",
               url: "Hakkimizda",
               defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
               );
            routes.MapRoute(
               name: "Blog",
               url: "Blog",
               defaults: new { controller = "Blog", action = "Blog", id = UrlParameter.Optional }
               );
            
            routes.MapRoute(
               name: "Servis",
               url: "Servis",
               defaults: new { controller = "Home", action = "Service", id = UrlParameter.Optional }
               );
            routes.MapRoute(
              name: "404",
              url: "404",
              defaults: new { controller = "Admin", action = "Error", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "RCP.Controllers" }
            );
        }
    }
}
