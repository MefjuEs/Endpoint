using Endpoint.Models;
using Endpoint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatFactService catService;

        public HomeController(ILogger<HomeController> logger, ICatFactService catService)
        {
            _logger = logger;
            this.catService = catService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFact()
        {
            var result = await catService.GetCatFact();

            if(result != null)
            {
                await catService.SaveCatFact(result);

                return RedirectToAction("");
            }
            else
            {
                ViewBag.ErrorMessage = "Response failed";

                return View("Error");
            }
        }

        public IActionResult Index()
        {
            return View();
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
    }
}
