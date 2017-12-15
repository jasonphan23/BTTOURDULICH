using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TOURDULICH_WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                  name: "thongkechiphi",
                  url: "thong-ke-chi-phi/",
                  defaults: new { controller = "Thongke", action = "ThongKeChiPhi", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                  name: "thong ke so lan di tour nv",
                  url: "thong-ke-di-tour-nv/",
                  defaults: new { controller = "Thongke", action = "ThongKeNV", id = UrlParameter.Optional }
              );
            routes.MapRoute(
                "load số lần đi tour",
                "Thongke/LoadSoLanDiTourNV/{start}/{end}/{id}",
                new
                {
                    controller = "Thongke",
                    action = "LoadSoLanDiTourNV",

                }
            );
            routes.MapRoute(
                "load chi phí",
                "Thongke/LoadChiPhi/{start}/{end}/{id}",
                new
                {
                    controller = "Thongke",
                    action = "LoadChiPhi",

                }
            );
            routes.MapRoute(
              "danh sách đăng kí tour",
              "danh-sach-dang-ki-tour/",
              new
              {
                  controller = "KhachHang",
                  action = "Index",

              }
          );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}