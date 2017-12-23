using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOURDULICH_WIN.BAL
{
    class THANHPHO_BAL
    {
        Database<TinhThanh> db;
        public THANHPHO_BAL()
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
