using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_QUANAN_BIZ
    {
        Database<Doan_QuanAn> db = new Database<Doan_QuanAn>();
        public List<Doan_QuanAn> Search(int madoan)
        {
            return db.Search(x => x.MaDoan == madoan);
        }
        public bool Insert(Doan_QuanAn dto)
        {
            return db.Insert(dto);
        }
        public Doan_QuanAn GetSingleQA(int maDQA)
        {
            return db.GetSingle(x => x.MaDQA == maDQA);
        }
        public bool Delete(Doan_QuanAn dto)
        {
            return db.Delete(dto);
        }
    }
}
