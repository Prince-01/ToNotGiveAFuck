using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToNotGiveAFuck.Models;
using ToNotGiveAFuck.Models.TODOs;

namespace ToNotGiveAFuck.Controllers
{
    public class TODOesController : Controller
    {
        private readonly ToNotGiveAFuckContext _context;

        public TODOesController(ToNotGiveAFuckContext context)
        {
            _context = context;    
        }

        // GET: TODOes
        public async Task<IActionResult> Index()
        {
            var toNotGiveAFuckContext = _context.TODO.Include(t => t.Category);
            return View(await toNotGiveAFuckContext.ToListAsync());
        }

        // GET: TODOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODO = await _context.TODO.SingleOrDefaultAsync(m => m.TodoId == id);
            if (tODO == null)
            {
                return NotFound();
            }

            return View(tODO);
        }

        // GET: TODOes/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return View();
        }

        // POST: TODOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodoId,CategoryId,CreatedBy,Deadline,Description,Name,Priority,StartDate,Status,StatusChangeDate")] TODO tODO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tODO);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", tODO.CategoryId);
            return View(tODO);
        }

        // GET: TODOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODO = await _context.TODO.SingleOrDefaultAsync(m => m.TodoId == id);
            if (tODO == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", tODO.CategoryId);
            return View(tODO);
        }

        // POST: TODOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TodoId,CategoryId,CreatedBy,Deadline,Description,Name,Priority,StartDate,Status,StatusChangeDate")] TODO tODO)
        {
            if (id != tODO.TodoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tODO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TODOExists(tODO.TodoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryId", tODO.CategoryId);
            return View(tODO);
        }

        // GET: TODOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tODO = await _context.TODO.SingleOrDefaultAsync(m => m.TodoId == id);
            if (tODO == null)
            {
                return NotFound();
            }

            return View(tODO);
        }

        // POST: TODOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tODO = await _context.TODO.SingleOrDefaultAsync(m => m.TodoId == id);
            _context.TODO.Remove(tODO);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TODOExists(int id)
        {
            return _context.TODO.Any(e => e.TodoId == id);
        }
    }
}
