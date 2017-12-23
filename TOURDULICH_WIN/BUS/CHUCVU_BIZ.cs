using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;

namespace TOURDULICH_WIN.BIZ
{
    public class CHUCVU_BIZ
    {
        Database<ChucVu> dbcv = new Database<ChucVu>();

        public List<ChucVu> GetList()
        {
            return dbcv.GetList();
        }
    }
}
