using Microsoft.AspNetCore.Mvc;

namespace TaskAppWeb.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
