using Microsoft.AspNetCore.Mvc;

namespace Coffee_store.Areas.Identity
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
