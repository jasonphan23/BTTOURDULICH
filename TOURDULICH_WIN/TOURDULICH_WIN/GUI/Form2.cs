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
       
        public Form2()
        {
            InitializeComponent();
            LoadCacDS();
        }
        public void LoadCacDS()
        {
            
        }


        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            TOURGIA_BAL bal = new TOURGIA_BAL();
            IEnumerable abc = bal.GetList(data_giatour.Value);
            dtgv_banggia.DataSource = abc;

        }
    }
}
