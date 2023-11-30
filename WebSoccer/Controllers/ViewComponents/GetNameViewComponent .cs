using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Models;

namespace eShopSoccer.ViewComponents
{
    public class GetNameViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public GetNameViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }
    }
}
