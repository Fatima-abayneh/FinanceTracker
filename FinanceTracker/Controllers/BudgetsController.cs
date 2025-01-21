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
    public class BudgetsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Budgets
        public async Task<IActionResult> Index(string searchString)
        {
            //var budgets = from m in _context.Budgets
            //             select m;

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    budgets = budgets.Where(s => s.Category.Name!.Contains(searchString));
            //}

            //return View(await budgets.ToListAsync());

            var applicationDbContext = _context.Budgets.Include(t => t.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Budgets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // GET: Budgets/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Budgets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Budget budget)
        {
            if (ModelState.IsValid)
            {
                //budget.CurrentAmount = budget.InicialAmount;
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", budget.CategoryId);
            return View(budget);
        }

        // GET: Budgets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", budget.CategoryId);
            return View(budget);
        }

        // POST: Budgets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Budget budget)
        {
            if (id != budget.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    //budget.CurrentAmount = budget.InicialAmount;
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", budget.CategoryId);
            return View(budget);
        }

        // GET: Budgets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budgets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Budgets == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Budgets'  is null.");
            }
            var budget = await _context.Budgets.FindAsync(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
          return (_context.Budgets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
