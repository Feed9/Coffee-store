using Coffee_store.Data;
using Coffee_store.Data.Entity;
using Coffee_store.Models;
using Coffee_store.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateOrder()
        {
            var cartItems = HttpContext.Session.GetItemFromSession<List<CartItem>>("cart");

            if (cartItems is null || cartItems.Count == 0) return RedirectToAction("Index");

            Cart cart = new Cart(cartItems);

            Order order = new Order()
            {
                Date = DateTime.Now,
                Address = "HOME",
                Status = OrderStatus.Created.ToString(),
                PaymentMethod = PaymentMethod.Cash.ToString(),
                Price = cart.TotalCost,
                UserId = _userManager.GetUserId(User),
                OrderItems = cart.CartItems!.Select(item => new OrderItem()
                {
                    Count = item.Count,
                    OrderAdditions = _context.Additions.Where(addition => item.Additions.Contains(addition)).ToList(),
                    Product = _context.Products.FirstOrDefault(product => product.Id == item.ProductId),                   
                    Price = item.Price,
                    Volume = item.Volume,                   
                }).ToList()

            };
            
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CancelOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(order => order.Id == id);
            if (order is not null)
            {
                order.Status = OrderStatus.AwaitingCancellationConfirmation.ToString();
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var orders = await _context.Orders!
                .Include(or => or.OrderItems!)
                    .ThenInclude(oi => oi.Product!)
                .Include(or => or.OrderItems!)
                    .ThenInclude(oi => oi.OrderAdditions!)
                .Where(or => or.UserId == userId)
                .ToListAsync();
            return View(orders);
        }
    }
}
