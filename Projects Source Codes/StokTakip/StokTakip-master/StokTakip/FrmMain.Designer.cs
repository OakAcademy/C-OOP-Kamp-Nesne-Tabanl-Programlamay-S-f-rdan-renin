namespace StokTakip
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMusteri = new System.Windows.Forms.Button();
            this.btnUrun = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStokEkleme = new System.Windows.Forms.Button();
            this.btnSilinenler = new System.Windows.Forms.Button();
            this.btnKategori = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusteri
            // 
            this.btnMusteri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteri.Image = global::StokTakip.Properties.Resources.human_resources_symbol;
            this.btnMusteri.Location = new System.Drawing.Point(12, 12);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(127, 125);
            this.btnMusteri.TabIndex = 0;
            this.btnMusteri.Text = "Müşteriler";
            this.btnMusteri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.BackColor = System.Drawing.Color.Lime;
            this.btnUrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUrun.Image = global::StokTakip.Properties.Resources.gift;
            this.btnUrun.Location = new System.Drawing.Point(145, 12);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(127, 125);
            this.btnUrun.TabIndex = 0;
            this.btnUrun.Text = "Ürünler";
            this.btnUrun.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUrun.UseVisualStyleBackColor = false;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Image = global::StokTakip.Properties.Resources.tag;
            this.button1.Location = new System.Drawing.Point(287, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 125);
            this.button1.TabIndex = 0;
            this.button1.Text = "Satiş";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStokEkleme
            // 
            this.btnStokEkleme.BackColor = System.Drawing.Color.Silver;
            this.btnStokEkleme.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStokEkleme.Image = global::StokTakip.Properties.Resources.warehouse;
            this.btnStokEkleme.Location = new System.Drawing.Point(12, 143);
            this.btnStokEkleme.Name = "btnStokEkleme";
            this.btnStokEkleme.Size = new System.Drawing.Size(127, 125);
            this.btnStokEkleme.TabIndex = 0;
            this.btnStokEkleme.Text = "Stok Ekleme";
            this.btnStokEkleme.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnStokEkleme.UseVisualStyleBackColor = false;
            this.btnStokEkleme.Click += new System.EventHandler(this.btnStokEkleme_Click);
            // 
            // btnSilinenler
            // 
            this.btnSilinenler.BackColor = System.Drawing.Color.Fuchsia;
            this.btnSilinenler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSilinenler.Image = global::StokTakip.Properties.Resources.icon;
            this.btnSilinenler.Location = new System.Drawing.Point(145, 143);
            this.btnSilinenler.Name = "btnSilinenler";
            this.btnSilinenler.Size = new System.Drawing.Size(127, 125);
            this.btnSilinenler.TabIndex = 0;
            this.btnSilinenler.Text = "Silinenler";
            this.btnSilinenler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSilinenler.UseVisualStyleBackColor = false;
            this.btnSilinenler.Click += new System.EventHandler(this.btnSilinenler_Click);
            // 
            // btnKategori
            // 
            this.btnKategori.BackColor = System.Drawing.Color.Aqua;
            this.btnKategori.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKategori.Image = global::StokTakip.Properties.Resources.maintenance;
            this.btnKategori.Location = new System.Drawing.Point(287, 143);
            this.btnKategori.Name = "btnKategori";
            this.btnKategori.Size = new System.Drawing.Size(127, 125);
            this.btnKategori.TabIndex = 0;
            this.btnKategori.Text = "Kategoriler";
            this.btnKategori.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnKategori.UseVisualStyleBackColor = false;
            this.btnKategori.Click += new System.EventHandler(this.btnKategori_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExit.Image = global::StokTakip.Properties.Resources.exit;
            this.btnExit.Location = new System.Drawing.Point(145, 274);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 125);
            this.btnExit.TabIndex = 0;
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 412);
            this.Controls.Add(this.btnKategori);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSilinenler);
            this.Controls.Add(this.btnStokEkleme);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnUrun);
            this.Controls.Add(this.btnMusteri);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Takip";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Button btnUrun;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStokEkleme;
        private System.Windows.Forms.Button btnSilinenler;
        private System.Windows.Forms.Button btnKategori;
        private System.Windows.Forms.Button btnExit;
    }
}