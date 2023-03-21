using Microsoft.AspNetCore.Mvc;

namespace BanDoDienTu_Nhom06_N03.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
