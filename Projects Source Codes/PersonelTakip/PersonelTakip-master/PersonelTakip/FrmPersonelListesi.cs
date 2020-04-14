using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.DTO;
using BLL;
using System.IO;


namespace PersonelTakip
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        PersonelDTO dto = new PersonelDTO();
        PersonelDetayDTO detay = new PersonelDetayDTO();
        bool combofull = false;
        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void doldur()
        {
            dto = PersonelBLL.GetAll();
            dataGridView1.DataSource = dto.Personeller;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].HeaderText = "Departman";
            dataGridView1.Columns[5].HeaderText = "Pozisyon";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Maaş";
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
            dataGridView1.Columns[13].Visible = false;
            cmbDepartman.DataSource = dto.Departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAd";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;
            if (dto.Departmanlar.Count > 0)
                combofull = true;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.DisplayMember = "PozisyonAd";
            cmbPozisyon.ValueMember = "ID";
            cmbPozisyon.SelectedIndex = -1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
            this.Hide();
            frm.isUpdate = false;
            frm.ShowDialog();
          
            this.Visible = true;
            combofull = false;
            Temizle();
            doldur();


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
            this.Hide();
            frm.isUpdate = true;
            frm.detay = detay;
            frm.ShowDialog();
            

            this.Visible = true;
            combofull = false;
            Temizle();
            doldur();

        }

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combofull)
            {
                int departmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                cmbPozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();

            }
        }
        List<PersonelDetayDTO> listt = new List<PersonelDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Personeller;
            if (txtUserNo.Text.Trim() != "")
                listt = listt.Where(x => x.UserNo == Convert.ToInt32(txtUserNo.Text)).ToList();
            if (txtAd.Text.Trim() != "")
                listt = listt.Where(x => x.Ad.Contains(txtAd.Text)).ToList();
            if (txtSoyad.Text.Trim() != "")
                listt = listt.Where(x => x.Soyad.Contains(txtSoyad.Text)).ToList();
            if (cmbDepartman.SelectedIndex != -1)
                listt = listt.Where(x => x.DepartmanID == Convert.ToInt32(cmbDepartman.SelectedValue)).ToList();

            if (cmbPozisyon.SelectedIndex != -1)
                listt = listt.Where(x => x.PozisyonID == Convert.ToInt32(cmbPozisyon.SelectedValue)).ToList();

            dataGridView1.DataSource = listt;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtUserNo.Clear();
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Personeller;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.PersoneID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detay.Ad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detay.Soyad = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            detay.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.DepartmanID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
            detay.PozisyonID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[7].Value);
            detay.Maas = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.password = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            detay.isAdmin= Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detay.Resim = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            detay.Adres = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            detay.DogumTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[13].Value);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silinsinmi", "Dikkat", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                PersonelBLL.PersonelSil(detay.PersoneID);
                string resimyol = Application.StartupPath + "\\resimler\\" + detay.Resim
;
                File.Delete(resimyol);
                MessageBox.Show("Silindi");
                combofull = false;
                Temizle();
                doldur();

            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
