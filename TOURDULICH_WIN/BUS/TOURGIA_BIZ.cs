using System;
using System.Collections.Generic;
using System.Linq;
using DATABASE;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using System.Collections;
namespace TOURDULICH_WIN.BIZ
{
    public class TOURGIA_BIZ
    {
        Database<Tour_Gia> tourgia_db;
        Database<Tour> tour_db;
        public TOURGIA_BIZ()
        {
            tourgia_db = new Database<Tour_Gia>();
            tour_db = new Database<Tour>();
        }
        public List<TourGiaViewModel> GetList(DateTime dt)
        {
    

            List<TourGiaViewModel> lst_tourgia = new List<TourGiaViewModel>();
            List<Tour> lst_tour = tour_db.Search(x=>x.TrangThai);
            foreach (Tour t in lst_tour)
            {
               TourGiaViewModel tgm = new TourGiaViewModel();
               var tg = tourgia_db.Search(x => x.TGBD <= dt && x.TGKT >= dt && x.MaTour == t.MaTour).OrderByDescending(x => x.TGBD).Select(x => new { x.Tour.Ten, x.Gia }).First();
               tgm.Ten = tg.Ten;
               tgm.Gia = tg.Gia;
               lst_tourgia.Add(tgm);
           }

            return lst_tourgia;
        }
        public List<Tour_Gia> GetList(int ma)
        {
            List<Tour_Gia> tour_gia = tourgia_db.Search(x => x.MaTour == ma).ToList();
            return tour_gia;
        }
        public bool Insert(Tour_Gia t)
        {
            return tourgia_db.Insert(t);
        }
        
        public Tour_Gia GetSingleByMaTour(int matour)
        {
            return tourgia_db.GetSingle(x => x.MaTour == matour);
        }

    }
}
