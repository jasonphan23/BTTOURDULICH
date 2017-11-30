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
    class TOURDIAIDIEM_BAL
    {
        Database<Tour_DiaDiem> tourdd_db;
        public TOURDIAIDIEM_BAL()
        {
            tourdd_db = new Database<Tour_DiaDiem>();
        }
       
        public List<Tour_DiaDiem> GetList(int ma)
        {
            List<Tour_DiaDiem> tour_dd = tourdd_db.Search(x => x.MaTour == ma).ToList();
            return tour_dd;
        }

    }
}
