using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
    public class PHANCONG_BIZ
    {
        Database<PhanCong> db = new Database<PhanCong>();
        public bool Insert(PhanCong dto)
        {
            return db.Insert(dto);
        }
        public PhanCong GetSingle (int macp)
        {
            return db.GetSingle(x=>x.MaPC == macp);
        }
        public List<PhanCong> Search(int md)
        {
            return db.Search(x => x.MaDoan == md);
        }
    }
}
