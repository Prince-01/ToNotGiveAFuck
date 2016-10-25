using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToNotGiveAFuck.Models;
using ToNotGiveAFuck.Models.Social;
using ToNotGiveAFuck.Models.TODOs;
using static ToNotGiveAFuck.Models.TODOs.Enumerations;

namespace ToNotGiveAFuck.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ToNotGiveAFuckContext _context;

        public PeopleController(ToNotGiveAFuckContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(await _context.Person.ToListAsync());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);
            if (User.Identity.IsAuthenticated && User.Claims.First().Value == id.ToString() && person == null)
            {
                _context.Add(person = new Person { PersonId = (Guid)id });
                await _context.SaveChangesAsync();
            }
            if (person == null)
            {
                return NotFound();
            }
            var personVM = new PersonViewModel
            {
                Person = person,
                TODOList = _context.PersonClaimsAbout.Where(u => u.UserId == id).Join(_context.TODO, p => p.PinnedToId, t => t.TodoId, (p, t) => new Tuple<Priviliges, TODO>(p.Privilege, t)).ToList()
            };
            personVM.TODOList.ForEach(t => t.Item2.Category = _context.Category.SingleOrDefault(c => c.CategoryId == t.Item2.CategoryId));

            return View(personVM);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,Name")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.PersonId = Guid.NewGuid();
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PersonId,Name")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.PersonId))
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var person = await _context.Person.SingleOrDefaultAsync(m => m.PersonId == id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PersonExists(Guid id)
        {
            return _context.Person.Any(e => e.PersonId == id);
        }
    }
}
