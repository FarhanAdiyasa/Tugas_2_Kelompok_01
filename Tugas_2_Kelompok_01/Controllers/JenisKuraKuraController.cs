﻿using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_01.Models;

namespace Tugas_2_Kelompok_01.Controllers
{
    public class JenisKuraKuraController : Controller
    {
        private static List<JenisKuraKura> jeniss = InitializeData();

        private static List<JenisKuraKura> InitializeData()
        {
            List<JenisKuraKura> initialData = new List<JenisKuraKura>
            {
                new JenisKuraKura
                {
                    id = 1,
                    namajenis = "Kura-Kura Ambon",
                    stok = "3",
                    status = 1
                },
                new JenisKuraKura
                {
                    id = 2,
                    namajenis = "Kura-Kura Brazil",
                    stok = "5",
                    status = 1
                }
            };
            return initialData;
        }


        public IActionResult Index()
        {
            List<JenisKuraKura> JenisList = jeniss.ToList();
            return View(JenisList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JenisKuraKura jenis)
        {
            if (ModelState.IsValid)
            {
                int new_id = 1;

                while (jeniss.Any(b => b.id == new_id))
                {
                    new_id++;
                }

                jenis.id = new_id;
                jenis.status = 1;

                jeniss.Add(jenis);
                TempData["SuccessMessage"] = "Data berhasil ditambahkan";
                return RedirectToAction("Index");
            }

            return View(jenis);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var response = new { success = false, message = "Gagal menghapus Jenis kura-kura." };

            try
            {
                var jenis = jeniss.FirstOrDefault(b => b.id == id);
                if (jenis != null)
                {
                    jeniss.Remove(jenis);
                    response = new { success = true, message = "Jenis Kura-kura berhasil dihapus." };
                }
                else
                {
                    response = new { success = false, message = "Jenis Kura-kura tidak ditemukan." };
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
            JenisKuraKura jenis = jeniss.FirstOrDefault(b => b.id == id);

            if (jenis == null)
            {
                return NotFound();
            }

            return View(jenis);
        }

        [HttpPost]
        public IActionResult Edit(JenisKuraKura jenis)
        {
            if (ModelState.IsValid)
            {
                JenisKuraKura newJenis = jeniss.FirstOrDefault(b => b.id == jenis.id);

                if (newJenis == null)
                {
                    return NotFound();
                }

                newJenis.namajenis = jenis.namajenis;
                newJenis.stok = jenis.stok;
 
                TempData["SuccessMessage"] = "Jenis Kura-kura berhasil diupdate.";
                return RedirectToAction("Index");
            }

            return View(jenis);
        }



    }
}