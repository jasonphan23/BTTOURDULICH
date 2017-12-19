using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;

namespace TOURDULICH_WEB.Controllers
{
    public class ThongKeController : Controller
    {
        //
        // GET: /ThongKe/
        Database<NhanVien> dbNV;
        Database<PhanCong> dbPC;
        Database<Tour> dbTour;
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ThongKeNV()
        {
            dbNV = new Database<NhanVien>();
            var list = dbNV.GetList().Where(x => x.TrangThai == true).ToList();
            ViewBag.LayDSNV = new SelectList(list, "MaNV", "HoTen", null);
            return View();
        }

        public ActionResult LoadSoLanDiTourNV(string start, string end,int id)
        {
            dbPC = new Database<PhanCong>();
            DateTime sd = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime ed = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            List<PhanCong> listtour = dbPC.Search(x => x.Doan.NgayKH >= sd && x.Doan.NgayKH <= ed && x.MaNV == id);
            ViewBag.DsTour = listtour;
            ViewBag.SoLan = listtour.Count();
            return View();
        }

        [HttpGet]
        public ActionResult ThongKeChiPhi()
        {
            dbTour = new Database<Tour>();
            var list = dbTour.GetList().ToList();
            ViewBag.LayDSTour = new SelectList(list, "MaTour", "Ten", null);
            return View();
        }
        public ActionResult LoadChiPhi(string start, string end, int id)
        {
            Database<CTDoan>db = new Database<CTDoan>();
            DateTime sd = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime ed = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var listDoan = db.GetList().Where(x => x.Doan.NgayKH <= ed && x.Doan.NgayKH >=sd && x.Doan.MaTour == id).ToList();
                
            ViewBag.listDoan = listDoan;
            return View();
        }
    }
}
