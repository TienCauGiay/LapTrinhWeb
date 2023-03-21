using Microsoft.AspNetCore.Mvc;

namespace BanDoDienTu_Nhom06_N03.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Payment()
        {
            return View();
        }
    }
}
