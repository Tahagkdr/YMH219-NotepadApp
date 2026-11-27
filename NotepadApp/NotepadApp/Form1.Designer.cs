using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NotepadApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lstNotlar = new ListBox();
            lblBaslik = new Label();
            txtBaslik = new TextBox();
            lblIcerik = new Label();
            rtbIcerik = new RichTextBox();
            btnYeni = new Button();
            btnKaydet = new Button();
            btnSil = new Button();
            btnDisaAktar = new Button();
            lblDurum = new Label();
            SuspendLayout();

            lstNotlar.Location = new Point(12, 12);
            lstNotlar.Name = "lstNotlar";
            lstNotlar.Size = new Size(220, 424);
            lstNotlar.TabIndex = 0;

            lblBaslik.AutoSize = true;
            lblBaslik.Location = new Point(248, 12);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Text = "Başlık:";

            txtBaslik.Location = new Point(248, 35);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.Size = new Size(540, 23);
            txtBaslik.TabIndex = 1;

            lblIcerik.AutoSize = true;
            lblIcerik.Location = new Point(248, 72);
            lblIcerik.Name = "lblIcerik";
            lblIcerik.Text = "İçerik:";

            rtbIcerik.Location = new Point(248, 95);
            rtbIcerik.Name = "rtbIcerik";
            rtbIcerik.Size = new Size(540, 290);
            rtbIcerik.TabIndex = 2;
            rtbIcerik.Text = "";

            btnYeni.Location = new Point(248, 400);
            btnYeni.Name = "btnYeni";
            btnYeni.Size = new Size(120, 36);
            btnYeni.TabIndex = 3;
            btnYeni.Text = "Yeni";

            btnKaydet.Location = new Point(388, 400);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 36);
            btnKaydet.TabIndex = 4;
            btnKaydet.Text = "Kaydet";

            btnSil.Location = new Point(528, 400);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(120, 36);
            btnSil.TabIndex = 5;
            btnSil.Text = "Sil";

            btnDisaAktar.Location = new Point(668, 400);
            btnDisaAktar.Name = "btnDisaAktar";
            btnDisaAktar.Size = new Size(120, 36);
            btnDisaAktar.TabIndex = 6;
            btnDisaAktar.Text = "TXT Aktar";

            lblDurum.AutoSize = true;
            lblDurum.Location = new Point(12, 450);
            lblDurum.Name = "lblDurum";
            lblDurum.Text = "Hazır";

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 480);
            Controls.Add(lstNotlar);
            Controls.Add(lblBaslik);
            Controls.Add(txtBaslik);
            Controls.Add(lblIcerik);
            Controls.Add(rtbIcerik);
            Controls.Add(btnYeni);
            Controls.Add(btnKaydet);
            Controls.Add(btnSil);
            Controls.Add(btnDisaAktar);
            Controls.Add(lblDurum);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Not Defteri";
            ResumeLayout(false);
            PerformLayout();
        }

        private ListBox lstNotlar;
        private Label lblBaslik;
        private TextBox txtBaslik;
        private Label lblIcerik;
        private RichTextBox rtbIcerik;
        private Button btnYeni;
        private Button btnKaydet;
        private Button btnSil;
        private Button btnDisaAktar;
        private Label lblDurum;
    }
}