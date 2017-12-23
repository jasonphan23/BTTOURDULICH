using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_PHUONGTIEN_BIZ
    {
        Database<Doan_PhuongTien> db = new Database<Doan_PhuongTien>();
        public List<Doan_PhuongTien> Search(int madoan)
        {
            return db.Search(x => x.MaDoan == madoan);
        }
        public Doan_PhuongTien GetSingle(int madoan)
        {
            return db.GetSingle(X => X.MaDoan == madoan);
        }
        public Doan_PhuongTien GetSinglePT(int maDPT)
        {
            return db.GetSingle(X => X.MaDPT == maDPT);
        }
        public bool Insert(Doan_PhuongTien dto)
        {
            return db.Insert(dto);
        }
        public bool Delete(Doan_PhuongTien dto)
        {
            return db.Delete(dto);
        }
    }
}
