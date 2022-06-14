using Coffee_store.Data;
using Coffee_store.Models;
using Coffee_store.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coffee_store.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int productId, int volume, int[] additions)
        {
            if (productId < 1 || volume < 1)
            {
                return RedirectToAction("Catalog", "Catalog");
            }

            CartItem cartItem = new CartItem
            {
                ProductId = productId,
                Product = _context.Products.FirstOrDefault(product => product.Id == productId),
                Count = 1,
                Volume = _context.PricesVolumes.Where(vp => vp.Id == volume).Select(vp => vp.Volume).FirstOrDefault(),
                Additions = _context.Additions.Where(ads => additions.Contains(ads.Id)).ToList(),
                ProductPrice = _context.PricesVolumes.Where(vp => vp.Id == volume).Select(vp => vp.Price).FirstOrDefault(),
                AdditionsPrice = _context.Additions.Where(ads => additions.Contains(ads.Id)).Sum(ad => ad.Price)
            };

            List<CartItem> cartItems = new();
            if (HttpContext.Session.GetItemFromSession<List<CartItem>>("cart") is null)
            {
                cartItems.Add(cartItem);
            }
            else
            {
                cartItems = HttpContext.Session.GetItemFromSession<List<CartItem>>("cart");

                if (IsExists(cartItems, cartItem))
                {
                    cartItems[cartItems.IndexOf(cartItem)].Count++;
                }
                else
                {
                    cartItems.Add(cartItem);
                }
            }

            HttpContext.Session.SetItemToSession<List<CartItem>>("cart", cartItems);

            return RedirectToAction("Catalog", "Catalog");
        }
        public IActionResult Cart()
        {
            List<CartItem>? cartItems = HttpContext.Session.GetItemFromSession<List<CartItem>>("cart");
            Cart cart = new Cart(cartItems);
            return PartialView("_ShopingCartPartial", cart);
        }

        public IActionResult Remove(int productId)
        {
            var cartItems = HttpContext.Session.GetItemFromSession<List<CartItem>>("cart");
            var index = IsExists(cartItems, productId);

            if (index > -1)
            {
                cartItems?.RemoveAt(index);

            }

            HttpContext.Session.SetItemToSession<List<CartItem>>("cart", cartItems);
            return RedirectToAction("Catalog", "Catalog");
        }
        [NonAction]
        public int IsExists(List<CartItem> cartItems, int cartItemId)
        {
            var index = cartItems.FindIndex(0, cartItems.Count, ci => ci.ProductId == cartItemId);
            return index;
        }
        [NonAction]
        public bool IsExists(List<CartItem> cartItems, CartItem cartItem)
        {
            return cartItems.Contains(cartItem);
        }

        public IActionResult ChangeQuantity(int itemId, string? operation)
        {
            List<CartItem>? cartItems = HttpContext.Session.GetItemFromSession<List<CartItem>>("cart");

            var cartItem = cartItems?.FirstOrDefault(c => c.ProductId == itemId);

            if (cartItems == null || cartItem == null)
            {
                return RedirectToAction("Cart", "Cart");
            }

            if (operation == "plus")
            {
                cartItem.Count++;
            }
            else if (operation == "minus")
            {
                cartItem.Count--;

                if (cartItem.Count <= 0)
                {
                    cartItems.Remove(cartItem);
                }
            }

            HttpContext.Session.SetItemToSession<List<CartItem>>("cart", cartItems);
            return View();
        }
    }
}
