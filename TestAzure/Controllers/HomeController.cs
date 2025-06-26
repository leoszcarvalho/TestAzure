using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAzure.Models;

namespace TestAzure.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<Conversation> Conversations = new();
        private static List<string> UsersOnline = new() { "alice", "bob", "carol" };

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

            var currentUser = User.Identity?.Name!;
            var otherUsers = UsersOnline.Where(u => u != currentUser).ToList();
            return View(otherUsers);
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
