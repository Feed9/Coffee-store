#nullable disable
using Coffee_store.Data;
using Coffee_store.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriceVolumeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PriceVolumeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/PriceVolume
        public async Task<IActionResult> Index(int productId)
        {
            List<PriceVolume> pricesVolumes = await _context.PricesVolumes.Where(pv => pv.ProductId == productId).ToListAsync();
            int categoryId = Convert.ToInt32(_context.Products.FirstOrDefault(p => p.Id == productId).CategoryId);
            ViewBag.Productid = productId;
            ViewBag.Categoryid = categoryId;
            return View(pricesVolumes);
        }

        // GET: Admin/PriceVolume/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceVolume = await _context.PricesVolumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceVolume == null)
            {
                return NotFound();
            }

            return View(priceVolume);
        }

        // GET: Admin/PriceVolume/Create
        public IActionResult Create(int productId)
        {
            PriceVolume priceVolume = new() { ProductId = productId };
            return View(priceVolume);
        }

        // POST: Admin/PriceVolume/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Price,Volume,Quantity")] PriceVolume priceVolume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(priceVolume);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index), new { ProductId = priceVolume.ProductId });
            }
            return View(priceVolume);
        }

        // GET: Admin/PriceVolume/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceVolume = await _context.PricesVolumes.FindAsync(id);
            if (priceVolume == null)
            {
                return NotFound();
            }
            return View(priceVolume);
        }

        // POST: Admin/PriceVolume/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Price,Volume,Quantity")] PriceVolume priceVolume)
        {
            if (id != priceVolume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(priceVolume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PriceVolumeExists(priceVolume.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { ProductId = priceVolume.ProductId });
            }
            return View(priceVolume);
        }

        // GET: Admin/PriceVolume/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var priceVolume = await _context.PricesVolumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (priceVolume == null)
            {
                return NotFound();
            }

            return View(priceVolume);
        }

        // POST: Admin/PriceVolume/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var priceVolume = await _context.PricesVolumes.FindAsync(id);
            _context.PricesVolumes.Remove(priceVolume);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { ProductId = priceVolume.ProductId });
        }

        private bool PriceVolumeExists(int id)
        {
            return _context.PricesVolumes.Any(e => e.Id == id);
        }
    }
}
