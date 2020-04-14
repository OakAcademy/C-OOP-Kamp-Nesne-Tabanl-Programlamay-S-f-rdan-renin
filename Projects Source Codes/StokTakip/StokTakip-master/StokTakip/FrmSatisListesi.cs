using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.DAL.DTO;
using StokTakip.BLL;


namespace StokTakip
{
    public partial class FrmSatisListesi : Form
    {
        public FrmSatisListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUrunFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }
        }

        private void txtSatisMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }
        }


        SatisDTO dto = new SatisDTO();
        SatisBLL bll = new SatisBLL();
        private bool combofull;

        private void FrmSatisListesi_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            cmbKategori.DataSource = dto.Kategoriler;
            cmbKategori.DisplayMember = "KategoriAd";
            cmbKategori.ValueMember = "ID";
            cmbKategori.SelectedIndex = -1;
            combofull = true;

            dataGridView1.DataSource = dto.Satislar;
            dataGridView1.Columns[0].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Kategori Adı";
            dataGridView1.Columns[3].HeaderText = "Fiyat";
            dataGridView1.Columns[4].HeaderText = "Satış Tarihi";
            dataGridView1.Columns[5].HeaderText = "Satış Miktar";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;






        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmSatis frm = new FrmSatis();
            this.Hide();
            frm.dto = dto;
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Satislar;
            Temizle();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            List<SatisDetayDTO> list = dto.Satislar;
            if (txtMusteriAd.Text.Trim() != "")
                list = list.Where(x => x.MusteriAd.Contains(txtMusteriAd.Text)).ToList();
            if (txtUrunAd.Text.Trim() != "")
                list = list.Where(x => x.UrunAd.Contains(txtUrunAd.Text)).ToList();
            if (cmbKategori.SelectedIndex != -1)
                list = list.Where(x => x.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue)).ToList();
            if (rbBuyuk.Checked)
                list = list.Where(x => x.Fiyat > Convert.ToInt32(txtUrunFiyat.Text)).ToList();

            if (rbKucuk.Checked)
                list = list.Where(x => x.Fiyat < Convert.ToInt32(txtUrunFiyat.Text)).ToList();
            if (rbEsit.Checked)
                list = list.Where(x => x.Fiyat == Convert.ToInt32(txtUrunFiyat.Text)).ToList();

            if (rbSbuyuk.Checked)
                list = list.Where(x => x.SatisMiktar > Convert.ToInt32(txtSatisMiktar.Text)).ToList();

            if (rbSKucuk.Checked)
                list = list.Where(x => x.SatisMiktar < Convert.ToInt32(txtSatisMiktar.Text)).ToList();
            if (rbSEsit.Checked)
                list = list.Where(x => x.SatisMiktar == Convert.ToInt32(txtSatisMiktar.Text)).ToList();
            if (chTarih.Checked)
                list = list.Where(x => x.SatisTarihi > dpBaslama.Value && x.SatisTarihi < dpBitis.Value).ToList();
            dataGridView1.DataSource = list;




        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void Temizle()
        {
            txtMusteriAd.Clear();
            txtSatisMiktar.Clear();
            txtUrunAd.Clear();
            txtUrunFiyat.Clear();
            combofull = false;
            cmbKategori.SelectedIndex = -1;
            combofull = true;
            rbBuyuk.Checked = false;
            rbKucuk.Checked = false;
            rbEsit.Checked = false;
            rbSEsit.Checked = false;
            rbSKucuk.Checked = false;
            rbSbuyuk.Checked = false;
            dataGridView1.DataSource = dto.Satislar;
        }
        SatisDetayDTO detay = new SatisDetayDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.MusteriAd = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            detay.UrunAd = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            detay.Fiyat = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            detay.SatisID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detay.UrunID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.MusteriID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detay.SatisMiktar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[5].Value);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (detay.UrunID == 0)
                MessageBox.Show("Seçim yapınız");
            else
            {
                FrmSatis frm = new FrmSatis();
                frm.dto = dto;
                frm.detaydto = detay;
                frm.isUpdate = true;
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
                bll = new SatisBLL();
                dto = bll.Select();
                dataGridView1.DataSource = dto.Satislar;


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (detay.SatisID == 0)
                MessageBox.Show("Satış seçiniz.");
            DialogResult result = MessageBox.Show("Silinsinmi", "Dikkat", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {

                if(bll.Delete(detay))
                {
                    MessageBox.Show("Silindi");
                    bll = new SatisBLL();
                    dto = bll.Select();
                    dataGridView1.DataSource = dto.Satislar;

                }

            }
           
        }
    }
}
