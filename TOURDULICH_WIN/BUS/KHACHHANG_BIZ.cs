using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.REPOSITORY;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.BIZ
{
    public class KHACHHANG_BIZ
    {
        Database<KhachHang> db = new Database<KhachHang>();
        public KhachHang GetSingle(string cmd)
        {
            return db.GetSingle(x => x.CMND == cmd);
        }
    }
}
