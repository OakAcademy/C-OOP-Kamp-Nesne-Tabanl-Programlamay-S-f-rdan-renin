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
    public partial class FrmIzinListesi : Form
    {
        public FrmIzinListesi()
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

        private void txtSure_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmIzinBilgileri frm = new FrmIzinBilgileri();
            this.Hide();
            frm.isUpdate = false;
            frm.ShowDialog();
            this.Visible = true;
            combofull = false;
            doldur();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
                MessageBox.Show("Lütfen izin seçin");
            else if (detay.IzinDurumID == ComboStatic.Onayla || detay.IzinDurumID == ComboStatic.Reddedildi)
                MessageBox.Show("Onaylanmış yada rewddilmiş izinler güncellenemez.");
            else
            {
                FrmIzinBilgileri frm = new FrmIzinBilgileri();
                this.Hide();
                frm.isUpdate = true;
                frm.detay = detay;
                frm.ShowDialog();
                this.Visible = true;
                combofull = false;
                doldur();
                temizle();
            }
           

          
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        IzinDTO dto = new IzinDTO();
        private bool combofull;
        void doldur()
        {

            dto = IzinBLL.GetAll();
            dataGridView1.DataSource = dto.Izinler;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "User No";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[3].HeaderText = "Soyad";
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
         
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].HeaderText = "Başlama Tarihi";
            dataGridView1.Columns[9].HeaderText = "Bitiş Tarihi";
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].HeaderText = "İzin Durumu";
            dataGridView1.Columns[13].Visible = false;
            dataGridView1.Columns[14].Visible = false;
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
            cmbIzinDurum.DataSource = dto.IzinDurumlar;
            cmbIzinDurum.DisplayMember = "IzinDurumAd";
            cmbIzinDurum.ValueMember = "ID";
            cmbIzinDurum.SelectedIndex = -1;
        }
       
        private void FrmIzinListesi_Load(object sender, EventArgs e)
        {

            doldur();
            if(!UserStatic.isAdmin)
            {
                dto.Izinler = dto.Izinler.Where(x => x.PersoneID == UserStatic.PersonelID).ToList();
                dataGridView1.DataSource = dto.Izinler;

                panel3.Visible = false;
                btnOnayla.Visible = false;
                btnRed.Visible = false;

            }


        }

        private void cmbDepartman_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combofull)
            {
                int departmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                cmbPozisyon.DataSource = dto.Pozisyonlar.Where(x => x.DepartmanID == departmanID).ToList();

            }
        }
        List<IzinDetayDTO> listt = new List<IzinDetayDTO>();
        private void btnAra_Click(object sender, EventArgs e)
        {
            listt = dto.Izinler;
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
            if (rbBaslamaTarihi.Checked)
                listt = listt.Where(x => x.BaslamaTarihi >= Convert.ToDateTime(dpBaslama.Value) 
                && x.BaslamaTarihi < Convert.ToDateTime(dpBitis.Value)).ToList();
            if (rbTeslimTarihi.Checked)
                listt = listt.Where(x => x.BitisTarihi >= Convert.ToDateTime(dpBaslama.Value)
                && x.BitisTarihi < Convert.ToDateTime(dpBitis.Value)).ToList();

            if (cmbIzinDurum.SelectedIndex != -1)
                listt = listt.Where(x => x.IzinDurumID == Convert.ToInt32(cmbIzinDurum.SelectedValue)).ToList();
            if (txtSure.Text.Trim() != "")
                listt = listt.Where(x => x.Sure==Convert.ToInt32(txtSure.Text)).ToList();
            dataGridView1.DataSource = listt;


        }
        void temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtUserNo.Clear();
            cmbDepartman.SelectedIndex = -1;
            cmbPozisyon.DataSource = dto.Pozisyonlar;
            cmbPozisyon.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Izinler;
            rbBaslamaTarihi.Checked = false;
            rbTeslimTarihi.Checked = false;
            txtSure.Clear();
            cmbIzinDurum.SelectedIndex = -1;
            dpBaslama.Value = DateTime.Today;
            dpBitis.Value = DateTime.Today;
        }
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();


        }
        IzinDetayDTO detay = new IzinDetayDTO();
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            detay.IzinID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[14].Value);
            detay.BaslamaTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
            detay.BitisTarihi = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[9].Value);
            detay.UserNo = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            detay.Sure = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[11].Value);
            detay.Aciklama = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            detay.IzinDurumID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[13].Value);

            
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
                MessageBox.Show("Lütfen izin seçin");
            else
            {
                IzinBLL.IzinGuncelle(detay.IzinID, ComboStatic.Onayla);
                MessageBox.Show("Onaylandı");
                temizle();
                doldur();
                
                
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            if (detay.IzinID == 0)
                MessageBox.Show("Lütfen izin seçin");
            else
            {
                IzinBLL.IzinGuncelle(detay.IzinID, ComboStatic.Reddedildi);
                MessageBox.Show("Reddildi");
                temizle();
                doldur();


            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Silinsinmi?", "Dikkat", MessageBoxButtons.YesNo);
            if(result==DialogResult.Yes)
            {
                if (detay.IzinDurumID == ComboStatic.Onayla || detay.IzinDurumID == ComboStatic.Reddedildi)
                    MessageBox.Show("Onaylı yada reddilmiş izinleri silemezsiniz");
                else
                {
                    IzinBLL.IzinSil(detay.IzinID);
                    MessageBox.Show("Silindi");
                    combofull = false;
                    doldur();
                    temizle();

                }

            }
        }

        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExcelExport.ExportExcel(dataGridView1);
        }
    }
}
