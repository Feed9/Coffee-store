#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coffee_store.Data;
using Coffee_store.Data.Entity;
using Microsoft.AspNetCore.Authorization;

namespace Coffee_store.Areas.Admin
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdditionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdditionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Addition
        public async Task<IActionResult> Index()
        {
            return View(await _context.Additions.ToListAsync());
        }

        // GET: Admin/Addition/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addition = await _context.Additions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addition == null)
            {
                return NotFound();
            }

            return View(addition);
        }

        // GET: Admin/Addition/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Addition/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Volume,Price,Quantity")] Addition addition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addition);
        }

        // GET: Admin/Addition/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addition = await _context.Additions.FindAsync(id);
            if (addition == null)
            {
                return NotFound();
            }
            return View(addition);
        }

        // POST: Admin/Addition/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Volume,Price,Quantity")] Addition addition)
        {
            if (id != addition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdditionExists(addition.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(addition);
        }

        // GET: Admin/Addition/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addition = await _context.Additions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (addition == null)
            {
                return NotFound();
            }

            return View(addition);
        }

        // POST: Admin/Addition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addition = await _context.Additions.FindAsync(id);
            _context.Additions.Remove(addition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdditionExists(int id)
        {
            return _context.Additions.Any(e => e.Id == id);
        }
    }
}
