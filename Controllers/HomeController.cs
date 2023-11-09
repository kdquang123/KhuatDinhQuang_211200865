using KhuatDinhQuang_211200865.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace KhuatDinhQuang_211200865.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QLHangHoaContext _context;

        public HomeController(ILogger<HomeController> logger,QLHangHoaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var hangHoas = _context.HangHoas.Where(hh=>hh.Gia>100).ToList();
            return View("KhuatDinhQuang_MainContent",hangHoas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult HangHoaFilter(int ?hid)
        {
            var hangHoas = _context.HangHoas.Where(hh => hh.MaLoai == hid).ToList();
            return PartialView("HangHoaFilter",hangHoas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.LoaiHangID = new SelectList(_context.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa hanghoa)
        {
            _context.HangHoas.Add(hanghoa);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}