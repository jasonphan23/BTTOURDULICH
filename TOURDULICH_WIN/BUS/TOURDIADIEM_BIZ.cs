using System;
using System.Collections.Generic;
using System.Linq;
using DATABASE;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;
using System.Collections;
namespace TOURDULICH_WIN.BIZ
{
    public class TOURDIAIDIEM_BIZ
    {
        Database<Tour_DiaDiem> tourdd_db;
        public TOURDIAIDIEM_BIZ()
        {
            tourdd_db = new Database<Tour_DiaDiem>();
        }
       
        public List<Tour_DiaDiem> GetList(int ma)
        {
            List<Tour_DiaDiem> tour_dd = tourdd_db.Search(x => x.MaTour == ma).ToList();
            return tour_dd;
        }
        public bool Insert(Tour_DiaDiem t)
        {
            return tourdd_db.Insert(t);
        }
        public bool Delete(int ma)
        {
            Tour_DiaDiem tdd = tourdd_db.GetSingle(x => x.MaTDD == ma);
            return tourdd_db.Delete(tdd);
        }
    
    }
}
