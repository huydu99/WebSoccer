using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Models;
using WebSoccer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSoccer.ViewComponents
{
    public class GetCategoryViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetCategoryViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _unitOfWork.Category.GetAll();
            return View(categories);
        }
    }
}
