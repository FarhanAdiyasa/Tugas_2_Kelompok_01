﻿using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_01.Models;

namespace Tugas_2_Kelompok_01.Controllers
{
    public class KuraKuraController : Controller
    {
        private static List<KuraKura> kuras = InitializeData();

        private static List<KuraKura> InitializeData()
        {
            List<KuraKura> initialData = new List<KuraKura>
            {
                new KuraKura
                {
                    id = 1,
                    nama = "Cizi",
                    namajenis = "Kura-Kura Ambon",
                    harga = "Rp.500.000",
                    status = 1
                },
                new KuraKura
                {
                    id = 2,
                    nama = "Pat",
                    namajenis = "Kura-Kura Brazil",
                    harga = "Rp.650.000",
                    status = 1
                }
            };
            return initialData;
        }


        public IActionResult Index()
        {
            List<KuraKura> kuraList = kuras.ToList();
            return View(kuraList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(KuraKura kura)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (kuras.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                kura.id = new_id;
                kura.status = 1;

                kuras.Add(kura);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(kura);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus kura-kura." };

            try
            {
                var kura = kuras.FirstOrDefault(b => b.id == id);
                if (kura != null)
                {
                    kuras.Remove(kura);
                    response = new { success = true, message = "Kura-kura berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Kura-kura tidak ditemukan." };
                }
            }
            catch (Exception ex)
            {
                response = new { success = false, message = ex.Message };
            }

            return Json(response);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            KuraKura kura = kuras.FirstOrDefault(b => b.id == id);

            if (kura == null)
            {
                return NotFound();
            }

            return View(kura);
        }

        [HttpPost]
        public IActionResult Edit(KuraKura kura)
        {
            if (ModelState.IsValid)
            {
                KuraKura newKura = kuras.FirstOrDefault(b => b.id == kura.id);

                if (newKura == null)
                {
                    return NotFound();
                }

                newKura.nama = kura.nama;
                newKura.namajenis = kura.namajenis;
                newKura.harga = kura.harga;
 
                TempData["SuccessMessage"] = "Kura-kura berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(kura);
        }



    }
}
