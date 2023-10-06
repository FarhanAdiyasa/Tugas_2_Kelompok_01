using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using Tugas_2_Kelompok_01.Models;

namespace Tugas_2_Kelompok_01.Controllers
{
    public class TransaksiController : Controller
    {
        private static List<Transaksi> transaksiList = InitializeData();
        private static List<KuraKura> kuras = kuras.ToList();

        private static List<Transaksi> InitializeData()
        {
            List<Transaksi> initialData = new List<Transaksi>
            {
                new Transaksi { idTransaksi = 1, TransactionDate = DateTime.Now, id = 1, Quantity = 2, TotalPrice = 100.0m },
                new Transaksi { idTransaksi = 2, TransactionDate = DateTime.Now, id = 2, Quantity = 1, TotalPrice = 50.0m },
                new Transaksi { idTransaksi = 3, TransactionDate = DateTime.Now, id = 3, Quantity = 3, TotalPrice = 150.0m }
            };
            return initialData;
        }

        public IActionResult Index()
        {
            List<Transaksi> transaksiData = transaksiList.ToList();
            return View(transaksiData);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.KuraKuraList = GetKuraKuraSelectList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaksi transaksi)
        {
            if (ModelState.IsValid)
            {
                int new_idTransaksi = 1;

                while (transaksiList.Any(t => t.idTransaksi == new_idTransaksi))
                {
                    new_idTransaksi++;
                }

                transaksi.idTransaksi = new_idTransaksi;

                // Hitung total harga berdasarkan ID kura-kura dan jumlah yang dibeli
                KuraKura selectedKuraKura = kuras.FirstOrDefault(k => k.id == transaksi.id);
                if (selectedKuraKura != null)
                {
                    transaksi.TotalPrice = selectedKuraKura.harga * transaksi.Quantity;
                }

                transaksiList.Add(transaksi);
                TempData["SuccessMessage"] = "Data transaksi berhasil ditambahkan.";
                return RedirectToAction("Index");
            }

            ViewBag.KuraKuraList = GetKuraKuraSelectList();
            return View(transaksi);
        }

        private IEnumerable<SelectListItem> GetKuraKuraSelectList()
        {
            return kuras.Select(k => new SelectListItem
            {
                Value = k.id.ToString(),
                Text = $"{k.nama} ({k.harga:C})"
            });
        }
    }
}
