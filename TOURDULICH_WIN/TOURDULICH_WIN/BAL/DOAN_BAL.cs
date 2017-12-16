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
    public class DOAN_BAL
    {
         Database<Doan> db;
        public DOAN_BAL()
        {
            db = new Database<Doan>();
        }
        public int  count_doan(DateTime dtbd, DateTime dtkt,int matour)
        {
            int aggregate2 = db.Search(x=>x.NgayKH <= dtkt && x.NgayKH >= dtbd && x.MaTour == matour)
                        .Distinct()
                        .Count();
            return aggregate2;
        }
    }
}
