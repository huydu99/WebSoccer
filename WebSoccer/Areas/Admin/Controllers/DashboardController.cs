using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Utility;
using WebSoccer.Utility.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebSoccer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DashboardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
            var orderheaders = _unitOfWork.OrderHeader.GetAll().Where(x=>x.OrderStatus == SD.StatusShipped);
            double total = 0;
            foreach(var order in orderheaders) {
                total += order.OrderTotal;
            }
            var totalusers = _unitOfWork.ApplicationUser.GetAll().Count();
            var productsold = _unitOfWork.OrderDetail.GetAll();
            int totalProducts = 0;
            foreach (var order in productsold)
            {
                totalProducts += order.Count;
            }
            var orderheader = _unitOfWork.OrderHeader.GetAll().Where(x => x.OrderStatus == SD.StatusShipped).Count();
            ViewBag.TotalOrder = orderheader;
            ViewBag.Total = total.ToVnd();
            ViewBag.TotalUsers = totalusers;
            ViewBag.Products = totalProducts;
			return View();
		}
	}
}
