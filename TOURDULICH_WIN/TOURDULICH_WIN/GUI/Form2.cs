using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DATABASE.MODELS;
using System.Collections;
using DATABASE.REPOSITORY;
using TOURDULICH_WIN.BIZ;
using System.Globalization;
namespace TOURDULICH_WIN.GUI
{
    public partial class Form2 : Form
    {

        DIADIEM_BIZ dd_BIZ;
        THANHPHO_BIZ tp_BIZ;
        LOAIHINH_BIZ lh_BIZ;
        TOUR_BIZ tour_BIZ;
        TOURGIA_BIZ tourgia_BIZ;
        TOURDIAIDIEM_BIZ tourdd_BIZ;
        BindingSource tour_biding = new BindingSource();


        public Form2()
        {
            InitializeComponent();
            LoadCacDS();
        }
        public void LoadCacDS()
        {
            dd_BIZ = new DIADIEM_BIZ();
            IEnumerable lst_dd = dd_BIZ.GetList();
            dtgv_diadiem.DataSource = lst_dd;
            dtgv_dd_new.DataSource = lst_dd;
            dtgv_diadiem.Columns["MaDD"].Visible = false;


            tp_BIZ = new THANHPHO_BIZ();
            IEnumerable lst_tt = tp_BIZ.GetList();
            cbb_noibd.DataSource = lst_tt;
            cbb_noibd.ValueMember = "MaTT";
            cbb_noibd.DisplayMember = "Ten";
            cbb_noibd_new.DataSource = lst_tt;
            cbb_noibd_new.ValueMember = "MaTT";
            cbb_noibd_new.DisplayMember = "Ten";

            IEnumerable lst_tt_kt = tp_BIZ.GetList();

            cbb_noikt.DataSource = lst_tt_kt;
            cbb_noikt.ValueMember = "MaTT";
            cbb_noikt.DisplayMember = "Ten";
            cbb_noikt_new.DataSource = lst_tt_kt;
            cbb_noikt_new.ValueMember = "MaTT";
            cbb_noikt_new.DisplayMember = "Ten";

            lh_BIZ = new LOAIHINH_BIZ();
            IEnumerable lst_lh = lh_BIZ.GetList();
            cbb_loaihinh.DataSource = lst_lh;
            cbb_loaihinh.ValueMember = "MaLHDL";
            cbb_loaihinh.DisplayMember = "Ten";

            cbb_loaihinh_new.DataSource = lst_lh;
            cbb_loaihinh_new.ValueMember = "MaLHDL";
            cbb_loaihinh_new.DisplayMember = "Ten";
            loadtour();
            tourgia_BIZ = new TOURGIA_BIZ();
            tourdd_BIZ = new TOURDIAIDIEM_BIZ();


        }



        private void loadtour()
        {

            tour_BIZ = new TOUR_BIZ();
            IEnumerable lst_tour = tour_BIZ.GetList();
            tour_biding.DataSource = lst_tour;
            datagv_tour.DataSource = tour_biding;
            datagv_tour.Columns["MaTour"].Visible = false;
        }
        private void laydulieutourtk()
        {

            IEnumerable lst_tour = tour_BIZ.GetListTK();
            tour_biding.DataSource = lst_tour;
            dtgv_tour_tk.DataSource = tour_biding;
            dtgv_tour_tk.Columns["MaTour"].Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            TOURGIA_BIZ BIZ = new TOURGIA_BIZ();
            IEnumerable LST_banggia = BIZ.GetList(data_giatour.Value.Date);
            dtgv_banggia.DataSource = LST_banggia;

        }


        private void txt_giatien_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_giatien.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_giatien.Text = txt_giatien.Text.Remove(txt_giatien.Text.Length - 1);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_giatien_new.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_giatien_new.Text = txt_giatien_new.Text.Remove(txt_giatien_new.Text.Length - 1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int index = dtgv_diadiem.CurrentCell.RowIndex;
            bool check_exists = true;
            foreach (DataGridViewRow row in dtgv_dd_tour.Rows)
            {
                if (row.Tag.ToString() == dtgv_diadiem[0, index].Value.ToString())
                {
                    MessageBox.Show("Địa điểm đã chèn!");
                    check_exists = false;
                    break;
                }
            }
            if (check_exists)
            {
                Tour_DiaDiem tdd = new Tour_DiaDiem();
                tdd.MaTour = Int32.Parse(datagv_tour[0, datagv_tour.CurrentRow.Index].Value.ToString());
                tdd.MaDD = Int32.Parse(dtgv_diadiem[0, index].Value.ToString());

                if (tourdd_BIZ.Insert(tdd))
                {
                    MessageBox.Show("Đã chèn");
                    dtgv_dd_tour.Rows.Add(tdd.MaTDD, dtgv_diadiem[1, index].Value, dtgv_diadiem[2, index].Value);
                    dtgv_dd_tour.Rows[dtgv_dd_tour.Rows.Count - 1].Tag = dtgv_diadiem[0, index].Value;
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int index = dtgv_dd_new.CurrentCell.RowIndex;
            bool check_exists = true;
            foreach (DataGridViewRow row in dtgv_dd_tour_new.Rows)
            {
                if (row.Tag.ToString() == dtgv_dd_new[0, index].Value.ToString())
                {
                    MessageBox.Show("Địa điểm đã chèn!");
                    check_exists = false;
                    break;
                }
            }
            if (check_exists)
            {
                dtgv_dd_tour_new.Rows.Add(dtgv_dd_new[1, index].Value, dtgv_dd_new[2, index].Value);
                dtgv_dd_tour_new.Rows[dtgv_dd_tour_new.Rows.Count - 1].Tag = dtgv_dd_new[0, index].Value;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DateTime new_giaap_date = date_doigiaad.Value.Date;
            DateTime new_giakt_date = date_doigiakt.Value.Date;
            DateTime old_bd = DateTime.Parse(dtgv_gia[1, dtgv_gia.Rows.Count - 1].Value.ToString());
            DateTime old_kt = DateTime.Parse(dtgv_gia[2, dtgv_gia.Rows.Count - 1].Value.ToString());

            if (new_giaap_date < DateTime.Now.Date || new_giaap_date >= old_bd.Date && new_giaap_date <= old_kt.Date || new_giakt_date < old_kt.Date || new_giaap_date < old_bd.Date) //gia nam trong khoang gia gan nhat da duoc luu o  db
            {
                MessageBox.Show("Khoảng giá không hợp lệ hoặc đã tồn tại");
            }
            else if (new_giaap_date > new_giakt_date)
            {
                MessageBox.Show("Giá bắt đầu bé hơn kết thúc");
            }
            else if (txt_giatien.Text == "")
            {
                MessageBox.Show("Giá tiền không được rỗng");
            }
            else
            {

                Tour_Gia tg = new Tour_Gia();
                tg.MaTour = Int32.Parse(datagv_tour[0, datagv_tour.CurrentRow.Index].Value.ToString());
                tg.Gia = Int32.Parse(txt_giatien.Text.ToString());
                tg.TGBD = new_giaap_date;
                tg.TGKT = new_giakt_date;
                if (tourgia_BIZ.Insert(tg))
                {
                    dtgv_gia.Rows.Add(txt_giatien.Text, new_giaap_date, new_giakt_date);
                }
                MessageBox.Show("Bạn đã nhập thành công giá mới !");
                button2.Enabled = false;
            }
        }



        private void datagv_tour_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = datagv_tour.CurrentCell.RowIndex;
            txt_tentour.Text = datagv_tour[1, index].Value.ToString();
            cbb_loaihinh.SelectedIndex = cbb_loaihinh.FindStringExact(datagv_tour[2, index].Value.ToString());
            if (datagv_tour[3, index].Value == null)
            {
                txt_dd.Text = "";
            }
            else
            {
                txt_dd.Text = datagv_tour[3, index].Value.ToString();
            }
            cbb_noibd.Text = datagv_tour[4, index].Value.ToString();
            cbb_noikt.Text = datagv_tour[5, index].Value.ToString();

            List<Tour_Gia> lst_tourgia = tourgia_BIZ.GetList(Int16.Parse(datagv_tour[0, index].Value.ToString()));
            dtgv_gia.Rows.Clear();
            foreach (Tour_Gia tourgia in lst_tourgia)
            {
                dtgv_gia.Rows.Add(tourgia.Gia, tourgia.TGBD, tourgia.TGKT);
                dtgv_gia.Rows[dtgv_gia.Rows.Count - 1].Tag = tourgia.MaTourGia;

            }
            dtgv_gia.Columns[0].DefaultCellStyle.Format = "C0";
            List<Tour_DiaDiem> lst_tourdd = tourdd_BIZ.GetList(Int16.Parse(datagv_tour[0, index].Value.ToString()));
            if (dtgv_dd_tour.Rows.Count > 0)
            {
                dtgv_dd_tour.Rows.Clear();
            }
            foreach (Tour_DiaDiem tourdd in lst_tourdd)
            {
                dtgv_dd_tour.Rows.Add(tourdd.MaTDD, tourdd.DiaDiem.Ten, tourdd.DiaDiem.TinhThanh1.Ten);
                dtgv_dd_tour.Rows[dtgv_dd_tour.Rows.Count - 1].Tag = tourdd.MaDD;

            }
            dtgv_dd_tour.Columns[0].Visible = false;
            if (button2.Enabled == false)
            {
                button2.Enabled = true;
            }
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtgv_gia_new_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgv_gia_new_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context_menu_sp = new ContextMenuStrip();
                //context_menu_sp.Items.Add("Xóa", null, new EventHandler(xoa_gia_new));
                context_menu_sp.Show(dtgv_gia, e.X, e.Y);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int giatien = 0;
            bool ktgiatour = Int32.TryParse(txt_giatien_new.Text, out giatien);
            if (txt_giatien_new.Text == "")
            {
                MessageBox.Show("Giá tour không được rỗng");
            }
            else if (!ktgiatour)
            {
                MessageBox.Show("Giá tour không được là chữ");
            }


            else if (txt_tentour_new.Text == "")
            {
                MessageBox.Show("Tên tour không được rỗng");
            }
            else if (cbb_noibd_new.SelectedValue.ToString() == cbb_noikt_new.SelectedValue.ToString())
            {
                MessageBox.Show("Nơi khởi hành và nơi kết thúc tour không thể trùng nhau !");
            }
            else
            {
                Tour t = new Tour();
                LoaiHinhDL lh = new LoaiHinhDL();
                //lh = lh_BIZ.First(Int16.Parse(cbb_loaihinh_new.SelectedValue.ToString());
                t.Ten = txt_tentour_new.Text;
                t.LoaiHinhDL = Int16.Parse(cbb_loaihinh_new.SelectedValue.ToString());
                t.DiemBatDau = Int16.Parse(cbb_noibd_new.SelectedValue.ToString());
                t.DiemKetThuc = Int16.Parse(cbb_noikt_new.SelectedValue.ToString());
                t.GhiChu = txt_ghichu_new.Text;
                t.DacDiem = txt_dd_new.Text;

                t.TrangThai = true;

                List<Tour_Gia> lst_tour_gia = new List<Tour_Gia>();
                Tour_Gia tg = new Tour_Gia();
                tg.Gia = Int32.Parse(txt_giatien_new.Text);
                tg.TGBD = DateTime.Parse(data_apdungnew.Value.ToString());
                tg.TGKT = DateTime.Parse(date_ketthucnew.Value.ToString());
                lst_tour_gia.Add(tg);
                t.Tour_Gia = lst_tour_gia;


                List<Tour_DiaDiem> lst_tour_dd = new List<Tour_DiaDiem>();
                foreach (DataGridViewRow row in dtgv_dd_tour_new.Rows)
                {
                    Tour_DiaDiem tour_dd = new Tour_DiaDiem();
                    tour_dd.MaDD = Int32.Parse(row.Tag.ToString());
                    lst_tour_dd.Add(tour_dd);

                }
                t.Tour_DiaDiem = lst_tour_dd;


                if (tour_BIZ.Insert(t))
                {
                    MessageBox.Show("CHEN THANH CONG");
                    foreach (var c in groupBox6.Controls)
                    {
                        if (c is TextBox) ((TextBox)c).Text = String.Empty;
                    }
                    dtgv_dd_tour_new.Rows.Clear();

                }
                else
                {
                    MessageBox.Show("chen that bai" + Database<Tour>.error_message);
                }
                //t.TinhThanh1 =  short.Parse(cbb_loaihinh_new.SelectedValue.ToString();
            }
        }

        private void dgvphieudat_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context_menu = new ContextMenuStrip();
                context_menu.Items.Add("Xóa");
                context_menu.ItemClicked += context_menu_ItemClicked;
                context_menu.Show(dtgv_dd_tour_new, e.X, e.Y);
            }

        }

        void context_menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = dtgv_dd_tour_new.CurrentRow.Index;
            dtgv_dd_tour_new.Rows.RemoveAt(index);
        }

        private void dtgv_dd_tour_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context_menu = new ContextMenuStrip();
                context_menu.Items.Add("Xóa");
                context_menu.ItemClicked += context_menu_tour_ItemClicked;
                context_menu.Show(dtgv_dd_tour, e.X, e.Y);
            }
        }
        void context_menu_tour_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = dtgv_dd_tour.CurrentRow.Index;
            int matour_dd = Int32.Parse(dtgv_dd_tour[0, index].Value.ToString());
            if (tourdd_BIZ.Delete(matour_dd))
            {
                dtgv_dd_tour.Rows.RemoveAt(index);
                MessageBox.Show("Đã xóa!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (date_ngaykttk.Value.Date < date_ngaybdtk.Value.Date)
            {
                MessageBox.Show("không hợp lệ");
            }
            else
            {
                DANGKY_BIZ dk_BIZ = new DANGKY_BIZ();
                if (dtgv_tour_tk.CurrentRow.Index != null)
                {
                    IEnumerable lst_dk = dk_BIZ.lst_tk(date_ngaybdtk.Value.Date, date_ngaykttk.Value.Date, Int32.Parse(dtgv_tour_tk[0, dtgv_tour_tk.CurrentRow.Index].Value.ToString()));
                    dtgv_ctdt.DataSource = lst_dk;
                }
                else
                {
                    MessageBox.Show("bạn chưa chọn tour!");
                }

            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_tentour.Text == "")
            {
                MessageBox.Show("Tên tour không được rỗng");
            }
            else
            {
                Tour t = new Tour();
                LoaiHinhDL lh = new LoaiHinhDL();
                //lh = lh_BIZ.First(Int16.Parse(cbb_loaihinh_new.SelectedValue.ToString());
                t.MaTour = Int32.Parse(datagv_tour[0, datagv_tour.CurrentRow.Index].Value.ToString());
                t.Ten = txt_tentour.Text;
                t.LoaiHinhDL = Int16.Parse(cbb_loaihinh.SelectedValue.ToString());
                t.DiemBatDau = Int16.Parse(cbb_noibd.SelectedValue.ToString());
                t.DiemKetThuc = Int16.Parse(cbb_noikt.SelectedValue.ToString());
                t.GhiChu = txt_ghichu.Text;
                t.DacDiem = txt_dd.Text;

                t.TrangThai = true;

                List<Tour_Gia> lst_tour_gia = new List<Tour_Gia>();
                foreach (DataGridViewRow row in dtgv_gia.Rows)
                {
                    Tour_Gia tg = new Tour_Gia();
                    tg.Gia = Int32.Parse(dtgv_gia[0, row.Index].Value.ToString());
                    tg.TGBD = DateTime.Parse(dtgv_gia[1, row.Index].Value.ToString());
                    tg.TGKT = DateTime.Parse(dtgv_gia[2, row.Index].Value.ToString());
                    lst_tour_gia.Add(tg);

                }

                t.Tour_Gia = lst_tour_gia;


                List<Tour_DiaDiem> lst_tour_dd = new List<Tour_DiaDiem>();
                foreach (DataGridViewRow row in dtgv_dd_tour.Rows)
                {
                    Tour_DiaDiem tour_dd = new Tour_DiaDiem();
                    tour_dd.MaDD = Int32.Parse(row.Tag.ToString());
                    lst_tour_dd.Add(tour_dd);

                }
                t.Tour_DiaDiem = lst_tour_dd;


                if (tour_BIZ.Update(t))
                {
                    MessageBox.Show("ĐÃ SỬA THÀNH CÔNG!!!");
                    loadtour();
                    foreach (var c in groupBox1.Controls)
                    {
                        if (c is TextBox) ((TextBox)c).Text = String.Empty;
                    }
                    dtgv_gia.Rows.Clear();
                    dtgv_dd_tour.Rows.Clear();
                }
                else
                {
                    MessageBox.Show("chen that bai" + Database<Tour>.error_message);
                }
            }
        }

        private void datagv_tour_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip context_menu = new ContextMenuStrip();
                context_menu.Items.Add("Xóa");
                context_menu.ItemClicked += context_tour_ItemClicked;
                context_menu.Show(datagv_tour, e.X, e.Y);
            }
        }
        void context_tour_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = datagv_tour.CurrentRow.Index;

            int matour = Int32.Parse(datagv_tour[0, index].Value.ToString());

            if (tour_BIZ.Delete(matour))
            {
                MessageBox.Show("Xóa thành công");
                datagv_tour.Rows.RemoveAt(index);
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            laydulieutourtk();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            IEnumerable lst_tour = tour_BIZ.GetListTK();
            BindingSource tour_biding = new BindingSource();
            tour_biding.DataSource = lst_tour;
            dtgv_thhd.DataSource = tour_biding;
            dtgv_thhd.Columns["MaTour"].Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (datetkhd_bd.Value.Date > datetkhd_kt.Value.Date)
            {
                MessageBox.Show("không hợp lệ");
            }
            else
            {
                DOAN_BIZ d_BIZ = new DOAN_BIZ();
                DANGKY_BIZ dk_BIZ = new DANGKY_BIZ();
                if (dtgv_thhd.CurrentRow.Index != null)
                {
                    int count = d_BIZ.count_doan(datetkhd_bd.Value.Date, datetkhd_kt.Value.Date, Int32.Parse(dtgv_thhd[0, dtgv_thhd.CurrentRow.Index].Value.ToString()));
                    //dtgv_ctdt.DataSource = lst_dk;

                    label32.Text = count.ToString();

                    int sum = dk_BIZ.get_sum_tk(datetkhd_bd.Value.Date, datetkhd_kt.Value.Date, Int32.Parse(dtgv_thhd[0, dtgv_thhd.CurrentRow.Index].Value.ToString()));
                    //dtgv_ctdt.DataSource = lst_dk;
                    label33.Text = sum.ToString();
                    label27.Text = dtgv_thhd[1, dtgv_thhd.CurrentRow.Index].Value.ToString();
                }
                else
                {
                    MessageBox.Show("bạn chưa chọn tour!");
                }

            }
        }

        private void datagv_tour_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void v(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            IEnumerable lst_tour = tour_BIZ.Search(textBox2.Text);
            BindingSource tour_biding = new BindingSource();
            tour_biding.DataSource = lst_tour;
            datagv_tour.DataSource = tour_biding;
            datagv_tour.Columns["MaTour"].Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            IEnumerable lst_tour = tour_BIZ.GetList();
            BindingSource tour_biding = new BindingSource();
            tour_biding.DataSource = lst_tour;
            datagv_tour.DataSource = tour_biding;
            datagv_tour.Columns["MaTour"].Visible = false;
        }

    }


    }
