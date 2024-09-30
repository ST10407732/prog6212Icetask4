using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROG2BIceTask4.Data;
using PROG2BIceTask4.Models;

namespace PROG2BIceTask4.Controllers
{
    public class TaskManagersController : Controller
    {
        private readonly PROG2BICETask4 _context;

        public TaskManagersController(PROG2BICETask4 context)
        {
            _context = context;
        }

        // GET: TaskManagers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskManager.ToListAsync());
        }

        // GET: TaskManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskManager == null)
            {
                return NotFound();
            }

            return View(taskManager);
        }

        // GET: TaskManagers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskName,Taskdetails,Deadline,Status")] TaskManager taskManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskManager);
        }

        // GET: TaskManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager.FindAsync(id);
            if (taskManager == null)
            {
                return NotFound();
            }
            return View(taskManager);
        }

        // POST: TaskManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskName,Taskdetails,Deadline,Status")] TaskManager taskManager)
        {
            if (id != taskManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskManagerExists(taskManager.Id))
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
            return View(taskManager);
        }

        // GET: TaskManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskManager = await _context.TaskManager
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskManager == null)
            {
                return NotFound();
            }

            return View(taskManager);
        }

        // POST: TaskManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskManager = await _context.TaskManager.FindAsync(id);
            if (taskManager != null)
            {
                _context.TaskManager.Remove(taskManager);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskManagerExists(int id)
        {
            return _context.TaskManager.Any(e => e.Id == id);
        }
    }
}
