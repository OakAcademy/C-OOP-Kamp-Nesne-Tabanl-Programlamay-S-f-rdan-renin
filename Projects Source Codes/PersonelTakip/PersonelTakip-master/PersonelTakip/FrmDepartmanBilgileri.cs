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

namespace PersonelTakip
{
    public partial class FrmDepartmanBilgileri : Form
    {
        public FrmDepartmanBilgileri()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtDepartmanAd.Text.Trim() == "")
                MessageBox.Show("Lütfen Departman Adı giriniz.");
            else
            {


                DEPARTMAN dpt = new DEPARTMAN();
                if(isUpdate)
                {
                    DialogResult result = MessageBox.Show("Eminmisiniz", "dikkat", MessageBoxButtons.YesNo);
                    if(result==DialogResult.Yes)
                    {
                        dpt.DepartmanAd = txtDepartmanAd.Text;
                        dpt.ID = detay.ID;
                        DepartmanBLL.DepartmanGuncelle(dpt);
                        MessageBox.Show("Güncellendi");
                        this.Close();

                    }
                }
                else
                {
                    dpt.DepartmanAd = txtDepartmanAd.Text;
                    DepartmanBLL.DepartmanEkle(dpt);
                    MessageBox.Show("Departman Eklendi");
                    txtDepartmanAd.Clear();
                }
            }
        }
        public bool isUpdate = false;
        public DEPARTMAN detay = new DEPARTMAN();
        private void FrmDepartmanBilgileri_Load(object sender, EventArgs e)
        {
            if (isUpdate)
                txtDepartmanAd.Text = detay.DepartmanAd;
        }
    }
}
