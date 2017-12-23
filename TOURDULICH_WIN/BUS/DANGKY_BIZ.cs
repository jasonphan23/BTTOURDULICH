using DATABASE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using System.Collections;

namespace TOURDULICH_WIN.BIZ
{
   public class DANGKY_BIZ
    {
        Database<DangKi> db = new Database<DangKi>();

        public IEnumerable lst_tk(DateTime dtbd, DateTime dtkt, int matour)
        {
            IEnumerable lst_dk = db.Search(x => x.NgayDK >= dtbd && x.NgayDK <= dtkt && x.Doan.MaTour == matour).GroupBy(x => x.NgayDK)
     .Select(x => new { Ngay = (DateTime)x.Key, TongDoanhThu = x.Sum(X => X.GiaDangKy) }).ToList();
            return lst_dk;
        }

        public int get_sum_tk(DateTime dtbd, DateTime dtkt, int matour)
        {
            int sum = db.Search(x => x.NgayDK >= dtbd && x.NgayDK <= dtkt && x.Doan.MaTour == matour).Sum(x => x.GiaDangKy);
            return sum;
        }
        public List<DangKi> GetList()
        {
            return db.GetList();
        }
        public DangKi GetSingle(int madk)
        {
            return db.GetSingle(x => x.MaDK == madk);
        }
        public bool Insert(DangKi dto)
        {
            return db.Insert(dto);
        }
        public bool Update(DangKi dto)
        {
            return db.Update(dto);
        }
        public bool Delete(DangKi dto)
        {
            return db.Delete(dto);
        }
    }
}
