using System;
using System.ComponentModel.DataAnnotations;

namespace Tugas_2_Kelompok_01.Models
{
    public class Transaksi
    {
        public int idTransaksi { get; set; }

        [Required(ErrorMessage = "Tanggal penjualan wajib diisi.")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }

        [Required(ErrorMessage = "Kura-kura wajib dipilih.")]
        public int id { get; set; }

        [Required(ErrorMessage = "Jumlah kura-kura wajib diisi.")]
        [Range(1, int.MaxValue, ErrorMessage = "Jumlah kura-kura tidak valid.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Total harga wajib diisi.")]
        [Range(0, double.MaxValue, ErrorMessage = "Total harga tidak valid.")]
        public decimal TotalPrice { get; set; }

        public KuraKura kura { get; set; }
    }
}
