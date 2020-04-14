using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.BLL;
using StokTakip.DAL.DTO;


namespace StokTakip
{
    public partial class FrmUyari : Form
    {
        public FrmUyari()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            FrmMain frm = new FrmMain();
            this.Hide();
            frm.ShowDialog();
           
        }
        UrunBLL bll = new UrunBLL();
        UrunDTO dto = new UrunDTO();
        private void FrmUyari_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dto.Urunler = dto.Urunler.Where(x => x.StokMiktar <= 50).ToList();
            if(dto.Urunler.Count==0)
            {
                FrmMain frm = new FrmMain();
                this.Visible = false;
                frm.ShowDialog();
            }
            dataGridView1.DataSource = dto.Urunler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori";
            dataGridView1.Columns[3].HeaderText = "Stok Miktarı";
            dataGridView1.Columns[4].HeaderText = "Ürün Fiyatı";
        }
    }
}
