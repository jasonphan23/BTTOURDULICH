using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;

namespace TOURDULICH_WEB.Controllers
{
    public class DoanController : Controller
    {
        //
        // GET: /Doan/
        Database<Doan> db = new Database<Doan>();
        Database<NhanVien> dbnv = new Database<NhanVien>();
        public ActionResult Index()
        {
            ViewBag.DsDoan = db.GetList().ToList();
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            Session["listkhachsan"] = new List<Doan_KhachSan>();
            Session["listphuongtien"] = new List<Doan_PhuongTien>();
            Session["listquanan"] = new List<Doan_QuanAn>();
            Session["listchiphikhac"] = new List<Doan_ChiPhiKhac>();
            return View();
        }
        public JsonResult laydanhsachnhanvien()
        {
            var list = dbnv.GetList().Select(x => new { label = x.HoTen, value = x.MaNV,}).ToList() ;

            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddKhachSan(string tenkhachsan, int gia,string dc)
        {
            Doan_KhachSan dks = new Doan_KhachSan();

            dks.TenKS = tenkhachsan;
            dks.Gia = gia;
            dks.DiaChi = dc;
            ((List<Doan_KhachSan>)Session["listkhachsan"]).Add(dks);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPhuongTien(string tenphuongtien, int gia)
        {
            Doan_PhuongTien dpt = new Doan_PhuongTien();
            dpt.TenPT =  tenphuongtien;
            dpt.Gia = gia;
            ((List<Doan_PhuongTien>)Session["listphuongtien"]).Add(dpt);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddQuanAn(string tenquanan, int gia, string dc)
        {
            Doan_QuanAn dks = new Doan_QuanAn();

            dks.TenQA = tenquanan;
            dks.Gia = gia;
            dks.DiaChi = dc;
            ((List<Doan_QuanAn>)Session["listquanan"]).Add(dks);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCPK(string tencpk, int gia)
        {
            Doan_ChiPhiKhac dks = new Doan_ChiPhiKhac();

            dks.TenCPKhac = tencpk;
            dks.Gia = gia;
            ((List<Doan_ChiPhiKhac>)Session["listchiphikhac"]).Add(dks);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
    }
}
