using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_KHACHSAN_BIZ
    {
        Database<Doan_KhachSan> db = new Database<Doan_KhachSan>();
        public List<Doan_KhachSan> Search(int madoan)
        {
            return db.Search(x => x.MaDoan == madoan);
        }
        public Doan_KhachSan GetSingle(int madoan)
        {
            return db.GetSingle(X => X.MaDoan == madoan);
        }
        public bool Insert(Doan_KhachSan dto)
        {
            return db.Insert(dto);
        }
        public bool Delete(Doan_KhachSan dto)
        {
            return db.Delete(dto);
        }
        public Doan_KhachSan GetSingleKS(int madks)
        {
            return db.GetSingle(x => x.MaDKS == madks);
        }
    }
}
