using DATABASE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using System.Collections;


namespace TOURDULICH_WIN.BAL
{
    class TOUR_BAL
    {
        
         Database<Tour> db;
         public TOUR_BAL()
        {
            db = new Database<Tour>();
        }
        public IEnumerable GetList()
        {

            var list = db.GetList().Where(x=>x.TrangThai==true).Select(x => new {x.MaTour,x.Ten,LoaiHinhDuLich = x.LoaiHinhDL1.Ten,x.DacDiem,NoiBatDau = x.TinhThanh.Ten,NoiKetThuc = x.TinhThanh1.Ten}).ToList();
            return list;
        }
        public IEnumerable GetListTK()
        {

            var list = db.GetList().Select(x => new { x.MaTour, x.Ten, NoiBatDau = x.TinhThanh.Ten, NoiKetThuc = x.TinhThanh1.Ten }).ToList();
            return list;
        }
        
        public bool Insert(Tour t)
        {

            return db.Insert(t);
        }

        public bool Update(Tour t)
        {
            Tour tour = db.GetSingle(x => x.MaTour == t.MaTour);
           
            db.Detach(tour);
            tour.Ten = t.Ten;
            tour.LoaiHinhDL = t.LoaiHinhDL;
            tour.DacDiem = t.DacDiem;
            tour.DiemBatDau = t.DiemBatDau;
            tour.DiemKetThuc = t.DiemKetThuc;
            tour.GhiChu = t.GhiChu;
            return db.Update(tour);
        }

        public bool Delete(int ma)
        {
            Tour t = db.GetSingle(x => x.MaTour == ma);
            t.TrangThai = false;
            return db.Update(t);
        }
    }
}
