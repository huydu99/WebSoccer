using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebSoccer.DataAccess.Repository;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Models;
using WebSoccer.Models.ViewModels;
using WebSoccer.Utility;

namespace eShopSoccer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly INotyfService _notyf;
        [BindProperty]
		public OrderVM OrderVM { get; set; }
        public OrderController(IUnitOfWork unitOfWork, INotyfService notyf)
        {
            _unitOfWork = unitOfWork;
            _notyf = notyf;
        }

        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Details(int orderId)
        {
			OrderVM orderVM = new()
			{
				OrderHeader = _unitOfWork.OrderHeader.Get(x=>x.Id == orderId,includeProperties: "ApplicationUser"),
				OrderDetail = _unitOfWork.OrderDetail.GetAll(x=>x.OrderHeaderId == orderId,includeProperties:"Product")
			};
            return View(orderVM);
        }

        [HttpPost]
        //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult UpdateOrderDetail()
        {
            var orderHeaderFromDb = _unitOfWork.OrderHeader.Get(u => u.Id == OrderVM.OrderHeader.Id);
            orderHeaderFromDb.Name = OrderVM.OrderHeader.Name;
            orderHeaderFromDb.Phone = OrderVM.OrderHeader.Phone;
            orderHeaderFromDb.Address = OrderVM.OrderHeader.Address;
            _unitOfWork.OrderHeader.Update(orderHeaderFromDb);
            _unitOfWork.Save();
            _notyf.Success("Cập nhật đơn hàng thành công");
            return RedirectToAction(nameof(Details), new { orderId = orderHeaderFromDb.Id });
        }

        [HttpPost]
        //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult StartProcessing()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusApproved);
            _unitOfWork.Save();
            _notyf.Success("Đã xác nhận");
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }
        [HttpPost]
        //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShippingOrder()
        {
            var orderheader = _unitOfWork.OrderHeader.Get(x => x.Id == OrderVM.OrderHeader.Id);
            orderheader.ShippingDate = DateTime.Now;
            orderheader.OrderStatus = SD.StatusInTransit;
            _unitOfWork.OrderHeader.Update(orderheader);
            _unitOfWork.Save();
            _notyf.Success("Đang vận chuyển");
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult ShippedOrder()
        {
            _unitOfWork.OrderHeader.UpdateStatus(OrderVM.OrderHeader.Id, SD.StatusShipped, SD.PaymentStatusApproved);
            _unitOfWork.Save();
            _notyf.Success("Hoàn tất đơn hàng");
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        [HttpPost]
        //[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
        public IActionResult CancelOrder()
        {
            var orderheader = _unitOfWork.OrderHeader.Get(x => x.Id == OrderVM.OrderHeader.Id);
            _unitOfWork.OrderHeader.UpdateStatus(orderheader.Id, SD.StatusCancelled);
            _unitOfWork.Save();
            _notyf.Success("Đã huỷ đơn hàng");
            return RedirectToAction(nameof(Details), new { orderId = OrderVM.OrderHeader.Id });
        }

        #region API CALL
        [HttpGet]
		public IActionResult GetAll(string status)
		{
            IEnumerable<OrderHeader> order = _unitOfWork.OrderHeader
                .GetAll(includeProperties: "ApplicationUser");   
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
