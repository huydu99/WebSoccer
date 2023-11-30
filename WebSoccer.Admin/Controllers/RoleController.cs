using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Policy;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Models;
using WebSoccer.Models.ViewModels;

namespace WebSoccer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> _appRole;
        private readonly INotyfService _notyf;
        public RoleController(RoleManager<ApplicationRole> appRole)
        {
            _appRole = appRole;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ApplicationRole> roles = _appRole.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RoleVM role)
        {
            if (!ModelState.IsValid)
            {
                return View(role);
            }
            if (!_appRole.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                 _appRole.CreateAsync(new ApplicationRole { Name = role.Name, Description = role.Description }).GetAwaiter().GetResult();
                _notyf.Success("Tạo phân quyền thành công");
            }
            return RedirectToAction("Index", "Role");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string roleId)
        {
            var roles = await _appRole.FindByIdAsync(roleId);
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleVM roleVM)
        {
            if (!ModelState.IsValid) { return View(roleVM); }
            var roledB = await _appRole.FindByNameAsync(roleVM.Name);
            if(roledB != null) {
                _notyf.Error("Phân quyền này đã tồn tại");
                return View(roleVM);
            }
            var role = new ApplicationRole()
            {
                Name = roleVM.Name,
                Description = roleVM.Description,
            };
            await _appRole.UpdateAsync(role);
            return RedirectToAction("Index");
        }

    }
}
