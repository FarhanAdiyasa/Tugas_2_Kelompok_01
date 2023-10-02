using Microsoft.AspNetCore.Mvc;

namespace Tugas_2_Kelompok_01.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
