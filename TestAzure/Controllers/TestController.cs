using Microsoft.AspNetCore.Mvc;

namespace TestAzure.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
