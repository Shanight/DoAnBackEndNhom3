using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hololive.Web.Data;
using Hololive.Web.Models;

namespace Hololive.Web.Controllers
{
    public class HololiveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HololiveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hololive
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        // GET: Hololive/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hololiveEntity = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hololiveEntity == null)
            {
                return NotFound();
            }

            return View(hololiveEntity);
        }

        // GET: Hololive/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hololive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,Password,Email,Role")] HololiveEntity hololiveEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hololiveEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hololiveEntity);
        }

        // GET: Hololive/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hololiveEntity = await _context.Users.FindAsync(id);
            if (hololiveEntity == null)
            {
                return NotFound();
            }
            return View(hololiveEntity);
        }

        // POST: Hololive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,Password,Email,Role")] HololiveEntity hololiveEntity)
        {
            if (id != hololiveEntity.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hololiveEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HololiveEntityExists(hololiveEntity.ID))
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
            return View(hololiveEntity);
        }

        // GET: Hololive/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hololiveEntity = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hololiveEntity == null)
            {
                return NotFound();
            }

            return View(hololiveEntity);
        }

        // POST: Hololive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hololiveEntity = await _context.Users.FindAsync(id);
            if (hololiveEntity != null)
            {
                _context.Users.Remove(hololiveEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HololiveEntityExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
