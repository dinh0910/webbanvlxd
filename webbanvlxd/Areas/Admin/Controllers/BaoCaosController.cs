using Microsoft.AspNetCore.Mvc;

namespace webbanvlxd.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BaoCaosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
