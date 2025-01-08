using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceTracker.Data;
using FinanceTracker.Models;

namespace FinanceTracker.Controllers
{
    public class RecurringTransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecurringTransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RecurringTransactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RecurringTransaction.Include(r => r.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RecurringTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RecurringTransaction == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransaction
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: RecurringTransactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Description,Amount,CategoryId,RecurrenceType,NextOccurrence")] RecurringTransaction recurringTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recurringTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", recurringTransaction.CategoryId);
            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RecurringTransaction == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransaction.FindAsync(id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", recurringTransaction.CategoryId);
            return View(recurringTransaction);
        }

        // POST: RecurringTransactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Description,Amount,CategoryId,RecurrenceType,NextOccurrence")] RecurringTransaction recurringTransaction)
        {
            if (id != recurringTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recurringTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecurringTransactionExists(recurringTransaction.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", recurringTransaction.CategoryId);
            return View(recurringTransaction);
        }

        // GET: RecurringTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RecurringTransaction == null)
            {
                return NotFound();
            }

            var recurringTransaction = await _context.RecurringTransaction
                .Include(r => r.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recurringTransaction == null)
            {
                return NotFound();
            }

            return View(recurringTransaction);
        }

        // POST: RecurringTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RecurringTransaction == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RecurringTransaction'  is null.");
            }
            var recurringTransaction = await _context.RecurringTransaction.FindAsync(id);
            if (recurringTransaction != null)
            {
                _context.RecurringTransaction.Remove(recurringTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecurringTransactionExists(int id)
        {
          return (_context.RecurringTransaction?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
