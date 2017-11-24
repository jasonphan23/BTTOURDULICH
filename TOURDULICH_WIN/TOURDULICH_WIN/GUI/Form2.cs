using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using TOURDULICH_WIN.BAL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATABASE.MODELS;
namespace TOURDULICH_WIN.GUI
{
    public partial class Form2 : Form
    {
        DiaDiem_BAL diadiem_bal = new DiaDiem_BAL();
        Khachsan_BAL khachsan_bal = new Khachsan_BAL();
        QuanAn_BAL quanan_bal = new QuanAn_BAL();
        public Form2()
        {
            InitializeComponent();
            LoadCacDS();
        }
        public void LoadCacDS()
        {
            List<DiaDiem> lst_diadiem = diadiem_bal.Lst_Diadiem();        
            List<KhachSan> lst_khsan = khachsan_bal.Lst_Khachsan();

            foreach (KhachSan kh in lst_khsan)
            {
                lst_khsanmoi.Rows.Add(kh.Ten, kh.DiaChi, kh.DiaDiem.TinhThanh);
            }
            List<QuanAn> lst_quanan = quanan_bal.Lst_QuanAn();

            
            lst_dd_moi.DataSource = lst_diadiem;
            lst_dd_moi.ValueMember = "MaDD";
            lst_dd_moi.DisplayMember = "Ten";

            lst_khsanmoi.DataSource = lst_khsan;

            lst_dd_moi.DataSource = lst_diadiem;
            lst_dd_moi.ValueMember = "MaDD";
            lst_dd_moi.DisplayMember = "Ten";

        }
    }
}
