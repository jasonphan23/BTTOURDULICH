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
    class DANGKY_BAL
    {
        Database<DangKi> db;
        public DANGKY_BAL()
        {
            db = new Database<DangKi>();
        }
        public IEnumerable  lst_tk(DateTime dtbd, DateTime dtkt,int matour)
        {
            IEnumerable lst_dk = db.Search(x => x.NgayDK >= dtbd && x.NgayDK <= dtkt && x.Doan.MaTour == matour).GroupBy(x => x.NgayDK)
     .Select(x => new { Ngay = (DateTime)x.Key, TongDoanhThu = x.Sum(X=>X.GiaDangKy) }).ToList();
            return lst_dk;
        }
     }
}
