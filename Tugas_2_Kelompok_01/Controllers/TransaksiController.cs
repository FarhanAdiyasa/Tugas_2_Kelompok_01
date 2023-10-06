using Microsoft.AspNetCore.Mvc;
using Tugas_2_Kelompok_01.Models;

namespace Tugas_2_Kelompok_01.Controllers
{
    public class TransaksiController : Controller
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
        public IActionResult Sell()
        {
           return View();
        }
    }
}
