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
        public List<DangKi> lst_tk(DateTime dtbd, DateTime dtkt)
        {
            List<DangKi> lst_dk = db.Search(x => x.NgayDK >= dtbd && x.NgayDK <= dtkt);
            return lst_dk;
        }
     }
}
