using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
   public class  CTDOAN_BIZ
    {
       Database<CTDoan> db = new Database<CTDoan>();
       public bool Insert(CTDoan dto)
       {
           return db.Insert(dto);
       }
       public CTDoan GetSingle(int md)
       {
           return db.GetSingle(x => x.MaDoan == md);
       }
       public bool Update(CTDoan dto)
       {
           return db.Update(dto);
       }
    }
}
