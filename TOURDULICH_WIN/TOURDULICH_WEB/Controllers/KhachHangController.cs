using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;

namespace TOURDULICH_WEB.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        Database<DangKi> dbDK;
        Database<Doan> dbDoan;
        Database<Tour> dbTour;
        Database<KhachHang> dbKH;
        public ActionResult Index()
        {
            dbDK = new Database<DangKi>();
            return View(dbDK.GetList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            dbTour = new Database<Tour>();
            ViewBag.LayDSTour = new SelectList(dbTour.GetList().ToList(), "MaTour", "Ten", null);
        //    ViewBag.LayDSKH = new SelectList(dbKH.GetList().ToList(), "MaKH", "HoTen", null);
            return View();
        }
        public ActionResult tenkh(string id)
        {
            dbKH = new Database<KhachHang>();
           
            KhachHang tenkh = dbKH.GetSingle(x=>x.CMND ==  id.Trim());
            if (tenkh != null)
            {

                return Json(tenkh, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("KH chưa đăng kí", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult DsDoan(int id)
        {
            dbDoan = new Database<Doan>();
            ViewBag.DsDoan = dbDoan.GetList().Where(x => x.MaTour == id && x.NgayKH > DateTime.Now).ToList();
            return View();
        }
    }
}
