using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace NotepadApp
{
    // Notları JSON dosyasına kaydeder ve yükler
    public class NotDeposu
    {
        private readonly string klasor = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "YMH219-NotepadApp");

        private string DosyaYolu => Path.Combine(klasor, "notlar.json");

        public List<Not> Yukle()
        {
            if (!File.Exists(DosyaYolu))
                return new List<Not>();

            try
            {
                string json = File.ReadAllText(DosyaYolu);
                return JsonSerializer.Deserialize<List<Not>>(json) ?? new List<Not>();
            }
            catch (JsonException)
            {
                // Bozuk dosyanın yedeğini al
                File.Copy(DosyaYolu, DosyaYolu + ".bozuk", true);
                throw;
            }
        }

        public void Kaydet(List<Not> notlar)
        {
            Directory.CreateDirectory(klasor);
            var ayar = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(DosyaYolu, JsonSerializer.Serialize(notlar, ayar));
        }
    }
}