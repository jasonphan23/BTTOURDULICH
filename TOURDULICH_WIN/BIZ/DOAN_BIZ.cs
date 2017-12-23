using DATABASE.REPOSITORY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATABASE.MODELS;
using System.Collections;
using TOURDULICH_WEB.Controllers;
using BIZ;

namespace TOURDULICH_WIN.BIZ
{
    public class DOAN_BIZ
    {
        Database<Doan> db = new Database<Doan>();
        Database<NhanVien> dbnv = new Database<NhanVien>();
        ChucVuController cvc = new ChucVuController();
        Database<Doan_ChiPhiKhac> dbcpk = new Database<Doan_ChiPhiKhac>();
        Database<Doan_KhachSan> dbks = new Database<Doan_KhachSan>();
        Database<Doan_PhuongTien> dbpt = new Database<Doan_PhuongTien>();
        Database<Doan_QuanAn> dbqa = new Database<Doan_QuanAn>();
        Database<CTDoan> dbctd = new Database<CTDoan>();
        Database<PhanCong> dbpc = new Database<PhanCong>();

        public int  count_doan(DateTime dtbd, DateTime dtkt,int matour)
        {
            int aggregate2 = db.Search(x=>x.NgayKH <= dtkt && x.NgayKH >= dtbd && x.MaTour == matour)
                        .Distinct()
                        .Count();
            return aggregate2;
        }

        public List<Doan> lst_doan()
        {
            return db.GetList();
        }
       

    }
}
