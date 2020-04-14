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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {

            if (!UserStatic.isAdmin)
            {
                FrmPersonelBilgileri frm = new FrmPersonelBilgileri();
                PersonelDTO dto = new PersonelDTO();
                dto = PersonelBLL.GetAll();
                PersonelDetayDTO detay = new PersonelDetayDTO();
                detay = dto.Personeller.First(x => x.PersoneID == UserStatic.PersonelID);
                frm.isUpdate = true;
                frm.detay = detay;
                frm.ShowDialog();
                this.Visible = true;


            }
            else
            {
                FrmPersonelListesi frm = new FrmPersonelListesi();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        private void btnIs_Click(object sender, EventArgs e)
        {
            FrmIsListesi frm = new FrmIsListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnMaas_Click(object sender, EventArgs e)
        {
            FrmMaasListesi frm = new FrmMaasListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnIzin_Click(object sender, EventArgs e)
        {
            FrmIzinListesi frm = new FrmIzinListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnDepartman_Click(object sender, EventArgs e)
        {
            FrmDepartmanListesi frm = new FrmDepartmanListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnPozisyon_Click(object sender, EventArgs e)
        {
            FrmPozisyonListesi frm = new FrmPozisyonListesi();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            this.Hide();
            frm.ShowDialog();
            this.Visible = true;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if(!UserStatic.isAdmin)
            {
                btnDepartman.Visible = false;
                btnPozisyon.Visible = false;
                btnLogOut.Location = new Point(167, 143);
                btnExit.Location = new Point(324, 143);


            }
        }
    }
}
