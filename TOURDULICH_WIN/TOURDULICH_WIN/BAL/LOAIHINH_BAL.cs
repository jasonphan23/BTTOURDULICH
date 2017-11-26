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
    class LOAIHINH_BAL
    {
         Database<LoaiHinhDL> db;
        public LOAIHINH_BAL()
        {
            db = new Database<LoaiHinhDL>();
        }
        public IEnumerable GetList()
        {

            var list = db.GetList().Select(x => new {x.MaLHDL,x.Ten}).ToList();
            return list;
        }
    }
    }
