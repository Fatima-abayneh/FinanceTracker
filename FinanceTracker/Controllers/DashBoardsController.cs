using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.Controllers
{
    public class DashBoardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
