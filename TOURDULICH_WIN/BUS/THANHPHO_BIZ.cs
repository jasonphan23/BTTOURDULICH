using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOURDULICH_WIN.BIZ
{
   public class THANHPHO_BIZ
    {
        Database<TinhThanh> db;
        public THANHPHO_BIZ()
        {
            db = new Database<TinhThanh>();
        }
        public IEnumerable GetList()
        {

            var list = db.GetList().Select(x => new { x.Ten,x.MaTT }).ToList();
            return list;
        }
    }
}
