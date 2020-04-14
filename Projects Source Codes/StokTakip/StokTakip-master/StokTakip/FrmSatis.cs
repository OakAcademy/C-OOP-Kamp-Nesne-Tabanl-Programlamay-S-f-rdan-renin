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
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSatisMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            { e.Handled = true; }
        }
        public SatisDTO dto = new SatisDTO();
        public SatisDetayDTO detaydto = new SatisDetayDTO();
        public bool isUpdate = false;
        private void FrmSatis_Load(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                panel1.Visible = false;
                txtMusteri.Text = detaydto.MusteriAd;
                txtUrunAd.Text = detaydto.UrunAd;
                txtUrunFiyat.Text = detaydto.Fiyat.ToString();
                List<UrunDetayDTO> urunler = dto.Urunler;
                UrunDetayDTO urun = urunler.First(x => x.ID == detaydto.UrunID);
                txtStok.Text = urun.StokMiktar.ToString();

            }
            else
            {
                gridMusteriler.DataSource = dto.Musteriler;
                gridMusteriler.Columns[0].Visible = false;
                gridMusteriler.Columns[1].HeaderText = "Müşteri Adı";
                gridUrunler.DataSource = dto.Urunler;
                gridUrunler.Columns[0].Visible = false;
                gridUrunler.Columns[5].Visible = false;
                gridUrunler.Columns[6].Visible = false;
                gridUrunler.Columns[7].Visible = false;
                gridUrunler.Columns[1].HeaderText = "Ürün Adı";
                gridUrunler.Columns[2].HeaderText = "Kategori";
                gridUrunler.Columns[3].Visible = false;
                gridUrunler.Columns[4].Visible = false;
                cmbKategori.DataSource = dto.Kategoriler;
                cmbKategori.DisplayMember = "KategoriAd";
                cmbKategori.ValueMember = "ID";
                cmbKategori.SelectedIndex = -1;
                combofull = true;
            }


        }
        bool combofull = false;
        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                List<UrunDetayDTO> list = dto.Urunler;
                if (cmbKategori.SelectedIndex != -1)
                    list = list.Where(x => x.KategoriID == Convert.ToInt32(cmbKategori.SelectedValue)).ToList();
                gridUrunler.DataSource = list;


            }
        }

        private void txtMusteriAd_TextChanged(object sender, EventArgs e)
        {
            List<MusteriDetayDTO> list = dto.Musteriler;
            list = list.Where(x => x.MusteriAd.Contains(txtMusteriAd.Text)).ToList();
            gridMusteriler.DataSource = list;
        }
        SatisDetayDTO detay = new SatisDetayDTO();
        private void gridMusteriler_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.MusteriID = Convert.ToInt32(gridMusteriler.Rows[e.RowIndex].Cells[0].Value);
            txtMusteri.Text = gridMusteriler.Rows[e.RowIndex].Cells[1].Value.ToString();
            detay.MusteriAd = gridMusteriler.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void gridUrunler_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.UrunID = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[0].Value);
            detay.Fiyat = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[4].Value);
            detay.StokMiktar = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[3].Value);
            detay.KategoriID = Convert.ToInt32(gridUrunler.Rows[e.RowIndex].Cells[5].Value);
            detay.UrunAd = gridUrunler.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtStok.Text = detay.StokMiktar.ToString();
            txtUrunAd.Text = detay.UrunAd;
            txtUrunFiyat.Text = detay.Fiyat.ToString();

        }
        SatisBLL bll = new SatisBLL();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
           
            if (txtSatisMiktar.Text.Trim() == "")
                MessageBox.Show("Satış miktarı giriniz");


            else
            {
                if (isUpdate)
                {
                    if (detaydto.SatisMiktar == Convert.ToInt32(txtSatisMiktar.Text))
                        MessageBox.Show("değişilik yok");
                    else
                    {
                        int temp = detaydto.SatisMiktar + Convert.ToInt32(txtStok.Text);
                        if (temp < Convert.ToInt32(txtSatisMiktar.Text))
                            MessageBox.Show("Elinizde yeterli stok yok");
                        else
                        {

                            detaydto.SatisMiktar = Convert.ToInt32(txtSatisMiktar.Text);
                            detaydto.StokMiktar = Convert.ToInt32(txtStok.Text);
                            if (bll.Update(detaydto))
                            {
                                MessageBox.Show("Güncellendi");
                                this.Close();

                            }

                        }
                    }

                }
                else
                {

                    if (detay.UrunID == 0)
                        MessageBox.Show("Ürün seçiniz");
                    else if (detay.MusteriID == 0)
                        MessageBox.Show("Müşteri seçiniz");

                  else  if (detay.StokMiktar < Convert.ToInt32(txtSatisMiktar.Text))
                        MessageBox.Show("Elinizde yeterli stok yok");
                    else
                    {
                        detay.SatisMiktar = Convert.ToInt32(txtSatisMiktar.Text);
                        if (bll.Insert(detay))
                        {
                            MessageBox.Show("Eklendi");
                            txtSatisMiktar.Clear();
                            dto = bll.Select();
                            gridUrunler.DataSource = dto.Urunler;

                        }
                    }




                }
            }

        }
    }
}