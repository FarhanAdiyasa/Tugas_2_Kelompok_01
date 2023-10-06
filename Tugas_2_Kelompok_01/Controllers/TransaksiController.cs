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

        private static List<Transaksi> InitializeData()
        {
            List<Transaksi> initialData = new List<Transaksi>
            {
                new Transaksi { idTransaksi = 1, TransactionDate = DateTime.Now.ToString("dd/MM/yyyy"), nama = "NAMA", Quantity = 2, TotalPrice = "100.0m" },
                new Transaksi { idTransaksi = 2, TransactionDate = DateTime.Now.ToString("dd/MM/yyyy"), nama = "NAMA", Quantity = 1, TotalPrice = "50.0m" },
                new Transaksi { idTransaksi = 3, TransactionDate = DateTime.Now.ToString("dd/MM/yyyy"), nama = "NAMA", Quantity = 3, TotalPrice = "150.0m" }
            };  
            return initialData;
        }

        public IActionResult Index()
        {
            List<Transaksi> transaksiData = transaksiList.ToList();
            return View(transaksiData);
        }


        [HttpPost]
        public IActionResult Create(Transaksi transaksi)
        {
            if(transaksi.Quantity == 0)
            {
                TempData["ErrorMessage"] = "Jumlah harus lebih dari 0.";
                return RedirectToAction("Index");
            }
            else
            {
                transaksiList.Add(transaksi);
                TempData["SuccessMessage"] = "Data transaksi berhasil ditambahkan.";
                return RedirectToAction("Index");

            }
           
        }
        
    }
}
