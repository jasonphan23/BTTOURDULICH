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
    public class DoanController : Controller
    {
        //
        // GET: /Doan/
        DOAN_BIZ db = new DOAN_BIZ();
        NHANVIEN_BIZ dbnv = new NHANVIEN_BIZ();
        CHUCVU_BIZ cvc = new CHUCVU_BIZ();
        DOAN_CHIPHIKHAC_BIZ dbcpk = new DOAN_CHIPHIKHAC_BIZ();
        DOAN_KHACHSAN_BIZ dbks = new DOAN_KHACHSAN_BIZ();
        DOAN_PHUONGTIEN_BIZ dbpt = new DOAN_PHUONGTIEN_BIZ();
        DOAN_QUANAN_BIZ dbqa = new DOAN_QUANAN_BIZ();
        CTDOAN_BIZ dbctd = new CTDOAN_BIZ();
        PHANCONG_BIZ dbpc = new PHANCONG_BIZ();
   
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
            Session["listphancong"] = new List<PhanCong>();
            List<ChucVu> cv = new List<ChucVu>();
            cv = cvc.GetList();
            ViewBag.Chucvu = cv;
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            Doan d = new Doan();
            d.Ten = f["tendoan"].ToString();
            d.MaTour = Int32.Parse(f["id_tour"]);
            d.MoTaChiTiet = f["motachitiet"].ToString();
            d.NgayKT = DateTime.Parse(f["ngayketthuc"].ToString());
            d.NgayKH = DateTime.Parse(f["ngaybatdau"].ToString());
            d.TruongDoan = Int32.Parse(f["truongdoan_id"]);
            d.Doan_KhachSan = ((List<Doan_KhachSan>)Session["listkhachsan"]);
            d.Doan_ChiPhiKhac = ((List<Doan_ChiPhiKhac>)Session["listchiphikhac"]);
            d.Doan_PhuongTien = ((List<Doan_PhuongTien>)Session["listphuongtien"]);
            d.Doan_QuanAn = ((List<Doan_QuanAn>)Session["listquanan"]);
            d.PhanCong = ((List<PhanCong>)Session["listphancong"]);
            db.Insert(d);

            CTDoan ctd = new CTDoan();
            ctd.MaDoan = d.MaDoan;
            if (dbqa.Search(ctd.MaDoan).Any() != null)
            {
                ctd.TongCPBA = dbqa.Search(d.MaDoan).Sum(x => x.Gia);
            }
            else
            {
                ctd.TongCPBA = 0;
            }

            if (dbks.Search(d.MaDoan).Any() != null)
            {
                ctd.TongCPKS = dbks.Search(d.MaDoan).Sum(x => x.Gia);
            }
            else
            {
                ctd.TongCPKS = 0;
            }

            if (dbks.Search(d.MaDoan).Any() != null)
            {
                ctd.TongCPKhac = dbcpk.Search(d.MaDoan).Sum(x => x.Gia);
            }
            else
            {
                ctd.TongCPKhac = 0;
            }
            ctd.TongCPPT = dbpt.Search(d.MaDoan).Sum(x => x.Gia);
            dbctd.Insert(ctd);
            return RedirectToAction("Index");
        }
        public JsonResult laydanhsachnhanvien()
        {
            var list = dbnv.GetList().Select(x => new { label = x.HoTen, value = x.MaNV, }).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        } 
        

        //add to session
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

        public ActionResult AddCV(int idnv, int idcv)
        {
            PhanCong pc = new PhanCong();
            pc.MaNV = idnv;
            pc.MaCV = idcv;
            
            ((List<PhanCong>)Session["listphancong"]).Add(pc);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
        //delete from session

        public ActionResult DeleteKS_Session(string tenkhachsan, int gia, string dc)
        {
            Doan_KhachSan dks = new Doan_KhachSan();
            dks = ((List<Doan_KhachSan>)Session["listkhachsan"]).Single(x => x.TenKS == tenkhachsan && x.Gia == gia && x.DiaChi == dc);
            ((List<Doan_KhachSan>)Session["listkhachsan"]).Remove(dks);           
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteQA_Session(string tenquanan, int gia, string dc)
        {
            Doan_QuanAn dks = new Doan_QuanAn();
            dks = ((List<Doan_QuanAn>)Session["listquanan"]).Single(x => x.TenQA == tenquanan && x.Gia == gia && x.DiaChi == dc);
            ((List<Doan_QuanAn>)Session["listquanan"]).Remove(dks);           
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeletePT_Session(string tenphuongtien,int gia)
        {
            Doan_PhuongTien dks = new Doan_PhuongTien();
            dks = ((List<Doan_PhuongTien>)Session["listphuongtien"]).Single(x => x.TenPT == tenphuongtien && x.Gia == gia);
            ((List<Doan_PhuongTien>)Session["listphuongtien"]).Remove(dks);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteCPK_Session(string tencpk, int gia)
        {
            Doan_ChiPhiKhac dks = new Doan_ChiPhiKhac();
            dks = ((List<Doan_ChiPhiKhac>)Session["listchiphikhac"]).Single(x => x.TenCPKhac == tencpk && x.Gia == gia);
            ((List<Doan_ChiPhiKhac>)Session["listchiphikhac"]).Remove(dks); 
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeletePC_Session(int idnv, int idcv)
        {
            PhanCong pc = new PhanCong();
            pc = ((List<PhanCong>)Session["listphancong"]).Single(x => x.MaNV == idnv && x.MaCV == idcv);
            ((List<PhanCong>)Session["listphancong"]).Remove(pc); 
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        


        //chinh sua 


        public ActionResult Edit(int id)
        {
            var doan = db.GetSingle(id);
            List<ChucVu> cv = new List<ChucVu>();
            cv = cvc.GetList();
            ViewBag.Chucvu = cv;
            return View(doan);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            Doan d = new Doan();
            int madoan = Int32.Parse(f["madoan"].ToString());
            d = db.GetSingle(madoan);
            db.Detach(d);
            d.Ten = f["tendoan"].ToString();
            d.MaTour = Int32.Parse(f["id_tour"]);
            d.MoTaChiTiet = f["motachitiet"].ToString();
            d.NgayKT = DateTime.Parse(f["ngayketthuc"].ToString());
            d.NgayKH = DateTime.Parse(f["ngaybatdau"].ToString());
            d.TruongDoan = Int32.Parse(f["truongdoan_id"]);

            db.Update(d);

            return RedirectToAction("Index");
        }



        //append to db

        public ActionResult AddKhachSan_DB(string tenkhachsan, int gia, string dc,int madoan)
        {
            Doan_KhachSan dks = new Doan_KhachSan();

            dks.TenKS = tenkhachsan;
            dks.Gia = gia;
            dks.DiaChi = dc;
            dks.MaDoan = madoan;
            dbks.Insert(dks);
            CTDoan ctd = dbctd.GetSingle(dks.MaDoan);
            ctd.TongCPKS = ctd.TongCPKS +  dks.Gia;
            dbctd.Update(ctd);
            return Json(dks.MaDKS, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPhuongTien_DB(string tenphuongtien, int gia,int madoan)
        {
            Doan_PhuongTien dpt = new Doan_PhuongTien();
            dpt.TenPT = tenphuongtien;
            dpt.Gia = gia;
            dpt.MaDoan = madoan;
            dbpt.Insert(dpt);
            CTDoan ctd = dbctd.GetSingle(dpt.MaDoan);
            ctd.TongCPPT = ctd.TongCPPT + dpt.Gia;
            dbctd.Update(ctd);
            return Json(dpt.MaDPT, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddQuanAn_DB(string tenquanan, int gia, string dc,int madoan)
        {
            Doan_QuanAn dks = new Doan_QuanAn();

            dks.TenQA = tenquanan;
            dks.Gia = gia;
            dks.DiaChi = dc;
            dks.MaDoan = madoan;
            dbqa.Insert(dks);
            CTDoan ctd = dbctd.GetSingle(dks.MaDoan);
            ctd.TongCPBA = ctd.TongCPBA + dks.Gia;
            dbctd.Update(ctd);
            return Json(dks.MaDQA, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCPK_DB(string tencpk, int gia,int madoan)
        {
            Doan_ChiPhiKhac dks = new Doan_ChiPhiKhac();

            dks.TenCPKhac = tencpk;
            dks.Gia = gia;
            dks.MaDoan = madoan;
            dbcpk.Insert(dks);

            CTDoan ctd = dbctd.GetSingle(dks.MaDoan);
            ctd.TongCPKhac = ctd.TongCPKhac + dks.Gia;
            dbctd.Update(ctd);

            return Json(dks.MaDCPK, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCV_DB(int idnv, int idcv,int madoan)
        {
            PhanCong pc = new PhanCong();
            pc.MaNV = idnv;
            pc.MaCV = idcv;
            pc.MaDoan = madoan;
            dbpc.Insert(pc);
            return Json(pc.MaPC, JsonRequestBehavior.AllowGet);
        }





        //delete from db 

        public ActionResult DeleteKS(int MaDKS)
        {
            Doan_KhachSan dks = new Doan_KhachSan();
            dks = dbks.GetSingleKS(MaDKS);
            dbks.Delete(dks);
            CTDoan ctd = dbctd.GetSingle(dks.MaDoan);
            ctd.TongCPKS = ctd.TongCPKS - dks.Gia;
            dbctd.Update(ctd);
            return RedirectToAction("Edit", new { id = dks.MaDoan });
        }
        public ActionResult DeletePT(int maDPT)
        {
            Doan_PhuongTien dpt = new Doan_PhuongTien();
            dpt = dbpt.GetSinglePT(maDPT);
            dbpt.Delete(dpt);
            CTDoan ctd = dbctd.GetSingle(dpt.MaDoan);
            ctd.TongCPPT = ctd.TongCPPT - dpt.Gia;
            dbctd.Update(ctd);
            return RedirectToAction("Edit", new { id = dpt.MaDoan });
        }
        public ActionResult DeleteQA(int maDQA)
        {
            Doan_QuanAn dq = new Doan_QuanAn();
            dq = dbqa.GetSingleQA(maDQA);
            dbqa.Delete(dq);
            CTDoan ctd = dbctd.GetSingle(dq.MaDoan);
            ctd.TongCPBA = ctd.TongCPBA - dq.Gia;
            dbctd.Update(ctd);
            return RedirectToAction("Edit", new { id = dq.MaDoan });
        }
        public ActionResult DeleteCPK(int cpk)
        {
            Doan_ChiPhiKhac dks = new Doan_ChiPhiKhac();
            dks = dbcpk.GetSingleCPK(cpk);
            CTDoan ctd = dbctd.GetSingle(dks.MaDoan);
            ctd.TongCPKhac = ctd.TongCPKhac - dks.Gia;
            dbctd.Update(ctd);
            return RedirectToAction("Edit", new { id = dks.MaDoan });
        }
        public ActionResult DeleteCV(int cv)
        {

            PhanCong PC = new PhanCong();
            PC = dbpc.GetSingle(cv);
            return RedirectToAction("Edit", new { id = PC.MaDoan});
        }

        public ActionResult Delete(int madoan)
        {

            Doan d = new Doan();
            d = db.GetSingle(madoan);
            if (d.DangKi.Count == 0)
            {
                List<Doan_KhachSan> lst_dks = new List<Doan_KhachSan>();
                lst_dks = dbks.Search(d.MaDoan);
                List<Doan_QuanAn> lst_dqa = new List<Doan_QuanAn>();
                lst_dqa = dbqa.Search(d.MaDoan);
                List<Doan_PhuongTien> lst_dpt = new List<Doan_PhuongTien>();
                lst_dpt = dbpt.Search(d.MaDoan);
                List<Doan_ChiPhiKhac> lst_cpk = new List<Doan_ChiPhiKhac>();
                lst_cpk = dbcpk.Search(d.MaDoan);
                List<PhanCong> lst_pc = new List<PhanCong>();
                lst_pc = dbpc.Search(d.MaDoan);
                TourDuLichEntities entity = new TourDuLichEntities();
                //entity.Entry(lst_dks).State = EntityState.Deleted;
                //entity.Doan_KhachSan.RemoveRange(lst_dks);
            
                //entity.Entry(lst_cpk).State = EntityState.Deleted;
                //entity.Doan_ChiPhiKhac.RemoveRange(lst_cpk);
                //entity.Entry(lst_dpt).State = EntityState.Deleted;
                //entity.Doan_PhuongTien.RemoveRange(lst_dpt);
                //entity.Entry(lst_dqa).State = EntityState.Deleted;
                //entity.Doan_QuanAn.RemoveRange(lst_dqa);
                //entity.Entry(lst_dqa).State = EntityState.Deleted;
                //entity.PhanCong.RemoveRange(lst_pc);
                db.Delete(d);
            }
                return RedirectToAction("Index");


        }

      


    }
}
