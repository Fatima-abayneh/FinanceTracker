using FinanceTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    public class DashBoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashBoardsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {            
            return View();
        }
    }
}
