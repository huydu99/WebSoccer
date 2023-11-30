using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Models;
using WebSoccer.Models.ViewModels;
using WebSoccer.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebSoccer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int orderId)
        {
            OrderVM orderVM = new()
            {
                OrderHeader = _unitOfWork.OrderHeader.Get(x => x.Id == orderId, includeProperties: "ApplicationUser"),
                OrderDetail = _unitOfWork.OrderDetail.GetAll(x => x.OrderHeaderId == orderId, includeProperties: "Product")
            };
            return View(orderVM);
        }
        #region API CALL
        public IActionResult GetAll(string status)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);

            IEnumerable<OrderHeader> order = _unitOfWork.OrderHeader
                .GetAll(x=>x.ApplicationUserId == userId, includeProperties: "ApplicationUser");

            switch (status)
            {
                case "pending":
                    order = order.Where(u => u.OrderStatus == SD.StatusPending);
                    break;
                case "approved":
                    order = order.Where(u => u.OrderStatus == SD.StatusApproved);
                    break;
                case "intransit":
                    order = order.Where(u => u.OrderStatus == SD.StatusInTransit);
                    break;
                case "shipped":
                    order = order.Where(u => u.OrderStatus == SD.StatusShipped);
                    break;
                case "cancelled":
                    order = order.Where(u => u.OrderStatus == SD.StatusCancelled);
                    break;
                default:
                    break;
            }


            return Json(new { data = order });
        }
        #endregion
    }
}
