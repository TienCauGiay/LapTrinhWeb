//using BanDoDienTu_Nhom06_N03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BanDoDienTu_Nhom06_N03.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}