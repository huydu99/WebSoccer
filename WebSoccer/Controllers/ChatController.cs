using Microsoft.AspNetCore.Mvc;

namespace WebSoccer.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
