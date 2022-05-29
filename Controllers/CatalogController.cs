using Coffee_store.Data;
using Coffee_store.Data.Entity;
using Coffee_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Catalog(int? categoryId, SortState sortState = SortState.NameAsc)
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            IQueryable<Product> products = _context.Products.Include(pr => pr.ProductQuantity).Where(pr => pr.ProductQuantity!.Quantity > 0);

            if (categoryId != null)
            {
                products = products.Where(product => product.CategoryId == categoryId);
            }

            List<CatalogProduct> catalogProducts = await products.Select(product => new CatalogProduct()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IconPath = product.IconPath,
                Price = product.PricesAndVolumes.OrderBy(e => e.Volume).Select(e => e.Price).FirstOrDefault()

            }).ToListAsync();

            Catalog catalog = new Catalog(categories, catalogProducts, sortState);
            catalog.SortProducts();

            ViewBag.sortState = sortState;
            ViewBag.categoryId = categoryId;
            ViewBag.catalog = catalog;
            return View();
        }
        public async Task<IActionResult> ProductCard(int productId)
        {
            Product? product = await _context.Products.Include(product => product.PricesAndVolumes).FirstOrDefaultAsync(p => p.Id == productId);
            List<Addition> additions = await _context.Additions.Include(ad => ad.AdditionQuantity)
                .Where(ad => ad.AdditionQuantity!.Quantity > 0).ToListAsync();
            ProductCard productCard = new ProductCard(product, additions);

            return PartialView("_ProductCardPartial", productCard);
        }

    }
}
