using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using DATABASE.REPOSITORY;

namespace TOURDULICH_WIN.BIZ
{
    public class NHANVIEN_BIZ
    {
        Database<NhanVien> db = new Database<NhanVien>();
        public List<NhanVien> GetList()
        {
            return db.GetList();
        }
    }
}
