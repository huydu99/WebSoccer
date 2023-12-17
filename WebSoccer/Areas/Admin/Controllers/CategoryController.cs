using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.DataAcess.Data;
using WebSoccer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebSoccer.Utility;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace WebSoccer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly INotyfService _notyf;
        public CategoryController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _notyf = notyf;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category,IFormFile? file)
        {

            if (!ModelState.IsValid)
            {
               return View(category);
            }
            string wwwroot = _webHostEnvironment.WebRootPath;
            if(file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string categoryPath = Path.Combine(wwwroot, @"images\categories");
                using ( var fileStream = new FileStream(Path.Combine(categoryPath, filename), FileMode.Create)){
                    file.CopyTo(fileStream);
                }
                category.ImageUrl = @"\images\categories\" + filename;
            }
            _unitOfWork.Category.Add(category);
            _unitOfWork.Save();
            _notyf.Success("Tạp danh mục thành công");
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryDb = _unitOfWork.Category.Get(u => u.Id == id);      
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }
        [HttpPost]
        public IActionResult Edit(Category category, IFormFile? file)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            string wwwroot = _webHostEnvironment.WebRootPath;
            if (file != null)
            {
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string categoryPath = Path.Combine(wwwroot, @"images\categories");
                if(!string.IsNullOrEmpty(category.ImageUrl))
                {
                    var oldPath = Path.Combine(wwwroot, category.ImageUrl.TrimStart('\\'));  
                    if(System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(categoryPath, filename), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                category.ImageUrl = @"\images\categories\" + filename;
            }
            _unitOfWork.Category.Update(category);
            _unitOfWork.Save();
            _notyf.Success("Cập nhật danh mục thành công");
            return View(nameof(Index));
        }
        #region API CALL
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return Json(new {data = categories});
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var cateogry = _unitOfWork.Category.Get(x=>x.Id == id);
            _unitOfWork.Category.Remove(cateogry);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xoá danh mục thành công!" });
        }
        #endregion
    }
}
