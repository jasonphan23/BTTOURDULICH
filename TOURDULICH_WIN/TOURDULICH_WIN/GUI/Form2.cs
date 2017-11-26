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
using System.Collections;
namespace TOURDULICH_WIN.GUI
{
    public partial class Form2 : Form
    {

        DIADIEM_BAL dd_bal;
        THANHPHO_BAL tp_bal;
        LOAIHINH_BAL lh_bal;
        public Form2()
        {
            InitializeComponent();
            LoadCacDS();
        }
        public void LoadCacDS()
        {
            dd_bal = new DIADIEM_BAL();
            IEnumerable lst_dd = dd_bal.GetList();
            datagv_diadiem.DataSource = lst_dd;
            datagv_diadiem_new.DataSource = lst_dd;

            tp_bal = new THANHPHO_BAL();
            IEnumerable lst_tt = tp_bal.GetList();
            cbb_noibd.DataSource = lst_tt;
            cbb_noibd.ValueMember = "MaTT";
            cbb_noibd.DisplayMember = "Ten";
            cbb_noibd_new.DataSource = lst_tt;
            cbb_noibd_new.ValueMember = "MaTT";
            cbb_noibd_new.DisplayMember = "Ten";
            cbb_noikt.DataSource = cbb_noibd.DataSource;
            cbb_noikt.ValueMember = "MaTT";
            cbb_noikt.DisplayMember = "Ten";
            cbb_noikt_new.DataSource = cbb_noibd.DataSource;
            cbb_noikt_new.ValueMember = "MaTT";
            cbb_noikt_new.DisplayMember = "Ten";

            lh_bal = new LOAIHINH_BAL();
            IEnumerable lst_lh = lh_bal.GetList();
            cbb_loaihinh.DataSource = lst_lh;
            cbb_loaihinh.ValueMember = "MaLHDL";
            cbb_loaihinh.DisplayMember = "Ten";

            cbb_loaihinh_new.DataSource = lst_lh;
            cbb_loaihinh_new.ValueMember = "MaLHDL";
            cbb_loaihinh_new.DisplayMember = "Ten";

        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            TOURGIA_BAL bal = new TOURGIA_BAL();
            IEnumerable LST_banggia = bal.GetList(data_giatour.Value);
            dtgv_banggia.DataSource = LST_banggia;

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
