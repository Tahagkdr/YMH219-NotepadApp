using System;

namespace NotepadApp
{
    public class Not
    {
        public string Baslik { get; set; } = "";
        public string Icerik { get; set; } = "";
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime DuzenlemeTarihi { get; set; } = DateTime.Now;

        // Listede notun başlığı görünsün
        public override string ToString() => Baslik;
    }
}