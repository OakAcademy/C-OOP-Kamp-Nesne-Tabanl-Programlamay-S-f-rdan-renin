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

namespace PersonelTakip
{
    public partial class FrmMaasListesi : Form
    {
        public FrmMaasListesi()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.isUpdate = false;
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            Temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmMaasBilgileri frm = new FrmMaasBilgileri();
            this.Hide();
            frm.isUpdate = true;
            frm.detay = detay;
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            Temizle();
        }
        MaasDTO dto = new MaasDTO();
        private bool combofull;
        MaasDetayDTO detay = new MaasDetayDTO();
  
  
        private void FrmMaasListesi_Load(object sender, EventArgs e)
        {
            doldur();
            if(!UserStatic.isAdmin)
            {
                btnEkle.Visible = false;
                btnGuncelle.Visible = false;
                btnSil.Visible = false;
                dto.Maaslar = dto.Maaslar.Where(x => x.PersoneID == UserStatic.PersonelID).ToList();
                dataGridView1.DataSource = dto.Maaslar;
                panel3.Visible = false;
                btnKapat.Location = new Point(293, 29);


            }



        }

        private void doldur()
        {
            dto = MaasBLL.GetAll();
            dataGridView1.DataSource = dto.Maaslar;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Yıl";
            dataGridView1.Columns[9].HeaderText = "Ay";
            dataGridView1.Columns[10].HeaderText = "Maaş";
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
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
            cmbAylar.DataSource = dto.Aylar;
            cmbAylar.DisplayMember = "Ay";
            cmbAylar.ValueMember = "ID";
            cmbAylar.SelectedIndex = -1;


        }

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                cmbPozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();

            }
        }
        List<MaasDetayDTO> listt = new List<MaasDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Maaslar;
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

            if (cmbAylar.SelectedIndex != -1)
                listt = listt.Where(x => x.MaasAyID == Convert.ToInt32(cmbAylar.SelectedValue)).ToList();
            if (txtYil.Text.Trim() != "")
                listt = listt.Where(x => x.UserNo == Convert.ToInt32(txtYil.Text)).ToList();
            if (rbBuyuk.Checked)
                listt = listt.Where(x => x.MaasMiktar > Convert.ToInt32(txtMaas.Text)).ToList();
           else if (rbKucuk.Checked)
                listt = listt.Where(x => x.MaasMiktar < Convert.ToInt32(txtMaas.Text)).ToList();
           else if (rbEsit.Checked)
                listt = listt.Where(x => x.MaasMiktar == Convert.ToInt32(txtMaas.Text)).ToList();
            dataGridView1.DataSource = listt;

        }
        void Temizle()
        {
            dataGridView1.DataSource = dto.Maaslar;
            txtAd.Clear();
            txtSoyad.Clear();
            txtUserNo.Clear();
            txtMaas.Clear();
            txtYil.Clear();
            cmbAylar.SelectedIndex = -1;
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.SelectedIndex = -1;
            rbBuyuk.Checked = false;
            rbKucuk.Checked = false;
            rbEsit.Checked = false;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.MaasID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detay.PersoneID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            detay.MaasAyID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[12].Value);
            detay.MaasYil = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.MaasMiktar = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
            detay.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.Ad = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            detay.Soyad = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silinsinmi?", "Dikkat", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                MaasBLL.maasSil(detay.MaasID);
                MessageBox.Show("Silindi");
                combofull = false;
                Temizle();
                doldur();

            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
