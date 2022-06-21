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
using Coffee_store.Models;

namespace Coffee_store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Order
        public async Task<IActionResult> Index(string? status)
        {
            var query = _context.Orders;

            if (status != null)
            {
                query.Where(or => or.Status.Equals(status));
            }

            var orders = await query.ToListAsync();
            return View(orders);
        }

        // GET: Admin/Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.CancellationRequest)
                .Include(or => or.OrderItems!).ThenInclude(oi => oi.OrderAdditions)
                .Include(or => or.OrderItems!).ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(or => or.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Admin/Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            var statuses = (Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>()
                .Select(status => new SelectListItem()
                {
                    Text = status.ToString(),
                    Value = status.ToString(),
                    Selected = order.Status == status.ToString()
                })).ToList();
            ViewBag.Statuses = statuses;
            return View(order);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Address,PaymentMethod,Status,Price,UserId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}