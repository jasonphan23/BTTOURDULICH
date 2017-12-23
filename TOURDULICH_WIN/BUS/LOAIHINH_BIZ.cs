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
    public class LOAIHINH_BIZ
    {
        Database<LoaiHinhDL> db;
        public LOAIHINH_BIZ()
        {
            db = new Database<LoaiHinhDL>();
        }
        public IEnumerable GetList()
        {

            var list = db.GetList().Select(x => new { x.MaLHDL, x.Ten }).ToList();
            return list;
        }
        public LoaiHinhDL First(int ma)
        {

            LoaiHinhDL lh = db.GetSingle(x => x.MaLHDL == ma);
            return lh;
        }
    }


}
