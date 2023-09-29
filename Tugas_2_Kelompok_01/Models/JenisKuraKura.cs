using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_01.Models
{
    public class JenisKuraKura
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Jenis wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis maksimal 30 karakter.")]
        public string namajenis { get; set; }

        [Required(ErrorMessage = "Stok wajib diisi.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Format stok tidak valid. Gunakan format yang benar.")]
        public string stok { get; set; }

        [Range(0, 1, ErrorMessage = "Status tidak valid.")]
        public int status { get; set; }
    }
}
