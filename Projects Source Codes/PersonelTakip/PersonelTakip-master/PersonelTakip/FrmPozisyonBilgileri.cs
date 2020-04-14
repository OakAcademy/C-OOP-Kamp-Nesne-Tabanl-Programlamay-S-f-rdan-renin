using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.DTO;
namespace PersonelTakip
{
    public partial class FrmPozisyonBilgileri : Form
    {
        public FrmPozisyonBilgileri()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        List<DEPARTMAN> departmanlar = new List<DEPARTMAN>();
        public bool isUpdate = false;
        public PozisyonDetayDTO detay = new PozisyonDetayDTO();
        private void FrmPozisyonBilgileri_Load(object sender, EventArgs e)
        {
            departmanlar = DAL.DAO.DepartmanDAO.DepartmanGetir();
            cmbDepartman.DataSource = departmanlar;
            cmbDepartman.DisplayMember = "DepartmanAd";
            cmbDepartman.ValueMember = "ID";
            cmbDepartman.SelectedIndex = -1;

            if(isUpdate)
            {
                TxtPozisyonAd.Text = detay.PozisyonAD;
                cmbDepartman.SelectedValue = detay.DepartmanID;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (TxtPozisyonAd.Text.Trim() == "")
                MessageBox.Show("Pozisyon Adın giriniz");
            else if (cmbDepartman.SelectedIndex == -1)
                MessageBox.Show("Departman seçiniz");
            else
            {
                if(isUpdate)
                {
                    DialogResult result = MessageBox.Show("Eminmisiniz", "Dikkat", MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        detay.PozisyonAD = TxtPozisyonAd.Text;
                        detay.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                        bool control = false;
                        if (detay.EskiDepartmanID != detay.DepartmanID)
                            control = true;
                        PozisyonBLL.PozisyonGuncelle(detay, control);
                        MessageBox.Show("Güncellendi");
                        this.Close();

                    }
                }
                else
                {
POZISYON pz = new POZISYON();
                pz.PozisyonAd = TxtPozisyonAd.Text;
                pz.DepartmanID = Convert.ToInt32(cmbDepartman.SelectedValue);
                PozisyonBLL.PozisyonEkle(pz);
                MessageBox.Show("Pozisyon Eklendi");
                TxtPozisyonAd.Clear();
                cmbDepartman.SelectedIndex = -1;
                }

                



            }

            

        }
    }
}
