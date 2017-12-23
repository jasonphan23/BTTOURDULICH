using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
using System.Data.Entity;
using TOURDULICH_WIN.BIZ;

namespace TOURDULICH_WEB.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/

        DANGKY_BIZ dbDK = new DANGKY_BIZ();
        DOAN_BIZ dbDoan = new DOAN_BIZ();
        TOUR_BIZ dbTour = new TOUR_BIZ();


        KHACHHANG_BIZ dbKH = new KHACHHANG_BIZ();
        TOURGIA_BIZ dbTour_Gia = new TOURGIA_BIZ();

        DOAN_CHIPHIKHAC_BIZ dbcpk = new DOAN_CHIPHIKHAC_BIZ();
        DOAN_KHACHSAN_BIZ dbks = new DOAN_KHACHSAN_BIZ();
        DOAN_PHUONGTIEN_BIZ dbpt = new DOAN_PHUONGTIEN_BIZ();
        DOAN_QUANAN_BIZ dbqa = new DOAN_QUANAN_BIZ();

        public ActionResult Index()
        {

            return View(dbDK.GetList());
        }


        [HttpGet]
        public ActionResult Create()
        {
          
            ViewBag.LayDSTour = new SelectList(dbTour.GetList(), "MaTour", "Ten", null);
            ViewBag.ngay = DateTime.Now;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {


            int id_doan = Convert.ToInt32(form["id_doantour"]);
            int id_KH = Convert.ToInt32(form["makh"]);
            DateTime ngay_DK = Convert.ToDateTime(form["ngaynhap"]);

            int id_tour = Convert.ToInt32(dbDoan.GetSingle(id_doan).MaTour);
            int gia_tour = dbTour_Gia.GetSingleByMaTour(id_tour).Gia;
            Tour tour = dbTour.GetSingle(id_tour);

            DangKi dki = new DangKi();

            dki.MaDoan = id_doan;
            dki.MaKH = id_KH;
            dki.NgayDK = ngay_DK;
            dki.GiaDangKy = gia_tour;

            dbDK.Insert(dki);

            return Redirect("../danh-sach-dang-ki-tour");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            DangKi dk = dbDK.GetSingle(id);
            Doan doan = dk.Doan;
            var dstour = dbTour.GetList();
            int id_tour = doan.MaTour;
            int id_doan = dk.MaDoan;

            ViewBag.madangki = id;
            ViewBag.tenkh = dk.KhachHang.HoTen;
            ViewBag.cmnd = dk.KhachHang.CMND;
            ViewBag.ngaydk = dk.NgayDK;
            ViewBag.makh = dk.MaKH;
            ViewBag.dstour = new SelectList(dstour, "MaTour", "Ten", id_tour);
            ViewBag.madoan = id_doan;
            ViewBag.matour = doan.MaTour;

            return View();
        }
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id_doan;
            int id_dk = Convert.ToInt32(form["madangki"]);
            id_doan = Convert.ToInt32(form["id_doantour"]);
            int id_KH = Convert.ToInt32(form["makh"]);
            DateTime ngay_DK = Convert.ToDateTime(form["ngaynhap"]);

            int id_tour = Convert.ToInt32(dbDoan.GetSingle(id_doan).MaTour);
            int gia_tour = dbTour_Gia.GetSingleByMaTour(id_tour).Gia;
            Tour tour = dbTour.GetSingle(id_tour);

            DangKi dki;
            // Get Dang Ki entity from DB
            dki = dbDK.GetSingle(id_dk);

            //change student name in disconnected mode (out of ctx scope)
            if (dki != null)
            {
                dki.MaDoan = id_doan;
                dki.MaKH = id_KH;
                dki.NgayDK = ngay_DK;
                dki.GiaDangKy = gia_tour;
            }

            //save modified entity using new Context

            dbDK.Update(dki);


            return Redirect("../../danh-sach-dang-ki-tour");
        }

        public ActionResult Detail(int id)
        {
            DangKi dangki = dbDK.GetSingle(id);
            Doan doan = dangki.Doan;
            Tour tour = doan.Tour;

            ViewBag.tour = tour;
            ViewBag.doan = doan;
            ViewBag.dangki = dangki;
            ViewBag.khachsan = dbks.Search(doan.MaDoan);
            ViewBag.phuongtien = dbpt.Search(doan.MaDoan);
            ViewBag.quanan = dbqa.Search(doan.MaDoan);
            ViewBag.chiphikhac = dbcpk.Search(doan.MaDoan);
            return View();
        }

        public ActionResult Delete(int id)
        {
            DangKi dangki = dbDK.GetSingle(id);
            dbDK.Delete(dangki);
            return Redirect("../../danh-sach-dang-ki-tour");
        }
        public ActionResult tenkh(string id)
        {

            KhachHang tenkh = dbKH.GetSingle(id.Trim());
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
            ViewBag.DsDoan = dbDoan.GetList().Where(x => x.MaTour == id && x.NgayKH > DateTime.Now).ToList();
            return View();
        }


    }
}
