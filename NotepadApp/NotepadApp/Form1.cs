using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace NotepadApp
{
    public partial class Form1 : Form
    {
        private readonly NotDeposu depo = new NotDeposu();
        private List<Not> notlar = new List<Not>();

        public Form1()
        {
            InitializeComponent();
            lstNotlar.SelectedIndexChanged += lstNotlar_SelectedIndexChanged;
            btnYeni.Click += btnYeni_Click;
            btnKaydet.Click += btnKaydet_Click;
            btnSil.Click += btnSil_Click;
            btnDisaAktar.Click += btnDisaAktar_Click;
            NotlariYukle();
        }

        private void NotlariYukle()
        {
            try
            {
                notlar = depo.Yukle();
                ListeyiYenile();
                lblDurum.Text = $"{notlar.Count} not yüklendi.";
            }
            catch (JsonException)
            {
                MessageBox.Show("Not dosyası bozuk. Yedeği alındı, boş liste açılıyor.");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Notlar okunamadı: " + ex.Message);
                btnKaydet.Enabled = false;
                btnSil.Enabled = false;
            }
        }

        private bool DosyayaKaydet()
        {
            try
            {
                depo.Kaydet(notlar);
                return true;
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Kaydedilemedi: " + ex.Message);
                return false;
            }
        }

        private void ListeyiYenile(Not? secilecek = null)
        {
            lstNotlar.Items.Clear();
            foreach (Not n in notlar)
                lstNotlar.Items.Add(n);

            if (secilecek != null)
                lstNotlar.SelectedItem = secilecek;
        }

        private void Temizle()
        {
            lstNotlar.ClearSelected();
            txtBaslik.Clear();
            rtbIcerik.Clear();
            txtBaslik.Focus();
        }

        private void lstNotlar_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstNotlar.SelectedItem is Not n)
            {
                txtBaslik.Text = n.Baslik;
                rtbIcerik.Text = n.Icerik;
                lblDurum.Text = $"Oluşturma: {n.OlusturmaTarihi:g} | Düzenleme: {n.DuzenlemeTarihi:g}";
            }
        }

        private void btnYeni_Click(object? sender, EventArgs e)
        {
            Temizle();
            lblDurum.Text = "Yeni not yazabilirsiniz.";
        }

        private void btnKaydet_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBaslik.Text))
            {
                MessageBox.Show("Lütfen bir başlık yazın.");
                return;
            }

            // Seçili not varsa düzenle, yoksa yeni ekle
            Not? secilenNot = lstNotlar.SelectedItem as Not;
            if (secilenNot == null)
            {
                secilenNot = new Not();
                notlar.Add(secilenNot);
            }

            secilenNot.Baslik = txtBaslik.Text.Trim();
            secilenNot.Icerik = rtbIcerik.Text;
            secilenNot.DuzenlemeTarihi = DateTime.Now;

            ListeyiYenile(secilenNot);
            if (DosyayaKaydet())
                lblDurum.Text = $"Not kaydedildi: {secilenNot.DuzenlemeTarihi:g}";
        }

        private void btnSil_Click(object? sender, EventArgs e)
        {
            if (lstNotlar.SelectedItem is not Not secili)
            {
                MessageBox.Show("Silmek için bir not seçin.");
                return;
            }

            DialogResult cevap = MessageBox.Show("Not silinsin mi?", "Onay", MessageBoxButtons.YesNo);
            if (cevap != DialogResult.Yes)
                return;

            notlar.Remove(secili);
            ListeyiYenile();
            Temizle();
            if (DosyayaKaydet())
                lblDurum.Text = "Not silindi.";
        }

        private void btnDisaAktar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBaslik.Text))
            {
                MessageBox.Show("Aktarmak için bir not seçin veya yazın.");
                return;
            }

            using SaveFileDialog pencere = new SaveFileDialog
            {
                Filter = "Metin dosyası (*.txt)|*.txt",
                FileName = "not.txt"
            };

            if (pencere.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using StreamWriter yazici = new StreamWriter(pencere.FileName);
                yazici.WriteLine(txtBaslik.Text);
                yazici.WriteLine();
                yazici.Write(rtbIcerik.Text.Replace("\n", Environment.NewLine));
                lblDurum.Text = "TXT olarak aktarıldı.";
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Aktarılamadı: " + ex.Message);
            }
        }
    }
}