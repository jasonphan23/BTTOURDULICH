using DATABASE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using System.Collections;
using BIZ;

namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_BIZ
    {
        Database<Doan> db = new Database<Doan>();

        public List<Doan> GetList()
        {
            return db.GetList();
        }

        public bool Insert(Doan dto)
        {
            return db.Insert(dto);
        }
        public int  count_doan(DateTime dtbd, DateTime dtkt,int matour)
        {
            int aggregate2 = db.Search(x=>x.NgayKH <= dtkt && x.NgayKH >= dtbd && x.MaTour == matour)
                        .Distinct()
                        .Count();
            return aggregate2;
        }

        public List<Doan> lst_doan()
        {
            return db.GetList();
        }
        public Doan GetSingle(int madoan)
        {
            return db.GetSingle(x => x.MaDoan == madoan);
        }
        public void Detach(Doan dto)
        {
            db.Detach(dto);
        }
        public bool Update(Doan dto)
        {
            return db.Update(dto);
        }
        public bool Delete(Doan dto)
        {
            return db.Delete(dto);
        }

    }
}
