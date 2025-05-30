﻿using Microsoft.AspNetCore.Mvc;
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
                _db.TaskLists.Add(obj);//keep tracks what added to database
                _db.SaveChanges();//actually save the changes to the database
                return RedirectToAction("Index");// redirects to index action
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            //check if id is null or 0
            if (id == null || id==0)
            {
                return NotFound();
            }

            //check if task with id is present in db
            TaskList? taskFromDb = _db.TaskLists.Find(id);
            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);   
        }
        [HttpPost]
        public IActionResult Edit(TaskList obj)
        {
            if (ModelState.IsValid)
            {
                _db.TaskLists.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        public IActionResult delete(int? id)
        {
            //check if id is null or 0

            if (id == null || id == 0)
            {
                return NotFound();
            }

            //check if task with id is present in db or no

            TaskList? taskFromDb = _db.TaskLists.Find(id);
            if (taskFromDb == null)
            {
                return NotFound();
            }
            return View(taskFromDb);
        }
        [HttpPost]
        [ActionName("Delete")]//this is the name of the action method
        public IActionResult DeletePOST(int? id)
        {
            TaskList? obj = _db.TaskLists.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
               _db.TaskLists.Remove(obj);//keep tracks what added to database
                _db.SaveChanges();//actually save the changes to the database
                return RedirectToAction("Index");// redirects to index action
           
       
        }

        [HttpPost]
        public ActionResult ToggleCompletion(int id, bool isCompleted)
        {
            var task = _db.TaskLists.Find(id); // Use your DbContext name instead of 'db'
            if (task != null)
            {
                task.isCompleted = isCompleted;
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }



    }
}
   