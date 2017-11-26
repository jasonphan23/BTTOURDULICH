using System;
using System.Collections.Generic;
using System.Linq;
using DATABASE;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using System.Collections;
namespace TOURDULICH_WIN.BAL
{
    class TOURGIA_BAL
    {
        Database<Tour_Gia> tourgia_db;
        public TOURGIA_BAL()
        {
            tourgia_db = new Database<Tour_Gia>();
        }
        public IEnumerable GetList(DateTime dt)
        {

            var kon = tourgia_db.Search(x => x.TGBD <= dt && x.TGKT>=dt).OrderByDescending(x=>x.TGBD).Select(x => new {x.Tour.Ten , x.Gia}).ToList();
            return kon;
        }

    }
}
