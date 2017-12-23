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
  public  class DIADIEM_BIZ
    {
        Database<DiaDiem> db = new Database<DiaDiem>();
        public IEnumerable GetList()
        {
            var list = db.GetList().Select(x => new {x.MaDD,TenDiaDiem = x.Ten,TenTinhThanh = x.TinhThanh1.Ten}).ToList();
            return list;
        }
        public DiaDiem First(int ma)
        {

            DiaDiem dd = db.GetSingle(x => x.MaDD == ma);
            return dd;
        }
    }
}
