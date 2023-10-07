using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_01.Models
{
    public class KuraKura
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Nama wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Nama maksimal 30 karakter.")]
        public string nama { get; set; }

        [Required(ErrorMessage = "Jenis wajib diisi.")]
        [MaxLength(30, ErrorMessage = "Jenis maksimal 30 karakter.")]
        public string namajenis { get; set; }

        [Required(ErrorMessage = "Harga wajib diisi.")]
        public string harga { get; set; }

        [Range(0, 1, ErrorMessage = "Status tidak valid.")]
        public int status { get; set; }
    }
}
