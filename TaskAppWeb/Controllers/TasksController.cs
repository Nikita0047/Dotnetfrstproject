using Microsoft.AspNetCore.Mvc;
using TaskAppWeb.Data;
using TaskAppWeb.Models;

namespace TaskAppWeb.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TasksController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<TaskList> objTaskLists = _db.TaskLists.ToList();
            return View(objTaskLists);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TaskList obj)
        {
            if (ModelState.IsValid)
            {
                _db.TaskLists.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
   