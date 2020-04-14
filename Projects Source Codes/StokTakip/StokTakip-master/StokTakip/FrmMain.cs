using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            FrmMusteriListesi frm = new FrmMusteriListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            FrmUrunListesi frm = new FrmUrunListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmSatisListesi frm = new FrmSatisListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnStokEkleme_Click(object sender, EventArgs e)
        {
            FrmStokEkleme frm = new FrmStokEkleme();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnSilinenler_Click(object sender, EventArgs e)
        {
            FrmSilinenler frm = new FrmSilinenler();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriListesi frm = new FrmKategoriListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
