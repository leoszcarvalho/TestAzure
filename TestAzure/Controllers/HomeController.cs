using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestAzure.Models;

namespace TestAzure.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            logger.LogInformation("Application starting...");
        }

        public IActionResult Index()
        {
            _logger.LogTrace("TRACE log message - for very detailed debugging");
            _logger.LogDebug("DEBUG log message - for general debugging");
            _logger.LogInformation("INFO log message - for normal operations");
            _logger.LogWarning("WARNING log message - something may be wrong");
            _logger.LogError("ERROR log message - something went wrong");
            _logger.LogCritical("CRITICAL log message - critical failure");

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
