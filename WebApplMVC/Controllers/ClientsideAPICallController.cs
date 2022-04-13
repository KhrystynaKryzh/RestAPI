using Microsoft.AspNetCore.Mvc;

namespace WebApplMVC.Controllers
{
    public class ClientsideAPICallController : Controller
    {   
        public IActionResult GetRestDataClient()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
