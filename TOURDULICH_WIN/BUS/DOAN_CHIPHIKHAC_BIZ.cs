using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_CHIPHIKHAC_BIZ
    {
        Database<Doan_ChiPhiKhac> db = new Database<Doan_ChiPhiKhac>();
        public List<Doan_ChiPhiKhac> Search(int madoan)
        {
            return db.Search(x => x.MaDoan == madoan);
            
        }
        public bool Insert(Doan_ChiPhiKhac dto)
        {
            return db.Insert(dto);
        }
        public Doan_ChiPhiKhac GetSingleCPK(int macpk)
        {
            return db.GetSingle(x => x.MaDCPK == macpk);
        }
    }
}
