using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSoccer.Utility;

namespace WebSoccer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
