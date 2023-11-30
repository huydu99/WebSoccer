using WebSoccer.Models.ViewModels;
using WebSoccer.Models;
using WebSoccer.Utility;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebSoccer.DataAccess.Repository.IRepository;
using WebSoccer.Utility.Helpers;

namespace WebSoccer.Controllers
{
	public class CheckoutController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartVM shoppingCartVM { get; set; }
		public CheckoutController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
			shoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.
					GetAll(x => x.ApplicationUserId == userId, includeProperties: "Product"),
				OrderHeader = new()
			};
			foreach (var item in shoppingCartVM.ShoppingCartList)
			{
				item.Price = item.Product.Price;
				item.Total = item.Quantity * item.Price;
				shoppingCartVM.OrderHeader.OrderTotal += item.Total;
			}
			return View(shoppingCartVM);
		}
		[HttpPost]
		[ActionName("Index")]
		public IActionResult IndexPost()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = Guid.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
			shoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart
				.GetAll(x => x.ApplicationUserId == userId, includeProperties: "Product");
			shoppingCartVM.OrderHeader.OrderDate = DateTime.Now;
			shoppingCartVM.OrderHeader.ApplicationUserId = userId;
			foreach (var item in shoppingCartVM.ShoppingCartList)
			{
				item.Price = item.Product.Price;
				item.Total = item.Quantity * item.Price;
				shoppingCartVM.OrderHeader.OrderTotal += item.Total;
			}
			shoppingCartVM.OrderHeader.OrderStatus = SD.StatusPending;
			shoppingCartVM.OrderHeader.PaymentStatus = SD.PaymentStatusCOD;
			_unitOfWork.OrderHeader.Add(shoppingCartVM.OrderHeader);
			_unitOfWork.Save();

			//cập nhật chi tiết
			foreach (var item in shoppingCartVM.ShoppingCartList)
			{
				OrderDetail detail = new()
				{
					ProductId = item.ProductId,
					OrderHeaderId = shoppingCartVM.OrderHeader.Id,
					Price = item.Price,
					Count = item.Quantity,
				};
				_unitOfWork.OrderDetail.Add(detail);
				_unitOfWork.Save();
			}
			return RedirectToAction(nameof(Confirmation), new { id = shoppingCartVM.OrderHeader.Id });
		}
		public IActionResult Confirmation(int id)
		{
			OrderHeader orderHeader = _unitOfWork.OrderHeader.Get(u => u.Id == id, includeProperties: "ApplicationUser");
			EmailSenderHelper.SendEmail("dulionel27@gmail.com", orderHeader.ApplicationUser.Email, "Đơn hàng",
				$"<p>Bạn đã đặt một đơn hàng mới {orderHeader.Id}</p>");
		
			List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart
				.GetAll(u => u.ApplicationUserId == orderHeader.ApplicationUserId).ToList();
			HttpContext.Session.Clear();
			_unitOfWork.ShoppingCart.RemoveRange(shoppingCarts);
			_unitOfWork.Save();
			return View();
		}

	}
}
