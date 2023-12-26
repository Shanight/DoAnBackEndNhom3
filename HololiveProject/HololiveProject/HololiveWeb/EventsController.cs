using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HololiveWeb.API.Models;

namespace HololiveWeb
{
    public class EventsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDbContext1 _context;

        public EventsController(ApplicationDbContext1 context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(await _context.Events.ToListAsync());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Img1,Img2,Img3,Img1up,Img2up,Img3up,Preview1,Preview2,Preview3,Preview4,Preview5")] Event @event)
        {
            if (ModelState.IsValid)
            {
                if (@event.Img1up != null && @event.Img1up.Length > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(@event.Img1up.FileName);
                    string extension = Path.GetExtension(@event.Img1up.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await @event.Img1up.CopyToAsync(fileStream);
                    }
                    @event.Img1 = fileName;
                }

                if (@event.Img2up != null && @event.Img2up.Length > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(@event.Img2up.FileName);
                    string extension = Path.GetExtension(@event.Img2up.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await @event.Img2up.CopyToAsync(fileStream);
                    }
                    @event.Img2 = fileName;
                }

                if (@event.Img3up != null && @event.Img3up.Length > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(@event.Img3up.FileName);
                    string extension = Path.GetExtension(@event.Img3up.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await @event.Img3up.CopyToAsync(fileStream);
                    }
                    @event.Img3 = fileName;
                }

                _context.Add(@event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@event);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Img1,Img2,Img3,Preview1,Preview2,Preview3,Preview4,Preview5,Img1up,Img2up,Img3up")] Event @event)
        {
            if (id != @event.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (@event.Img1up != null && @event.Img1up.Length > 0)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(@event.Img1up.FileName);
                        string extension = Path.GetExtension(@event.Img1up.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/img/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await @event.Img1up.CopyToAsync(fileStream);
                        }
                        @event.Img1 = fileName;
                    }

                    if (@event.Img2up != null && @event.Img2up.Length > 0)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(@event.Img2up.FileName);
                        string extension = Path.GetExtension(@event.Img2up.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/img/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await @event.Img2up.CopyToAsync(fileStream);
                        }
                        @event.Img2 = fileName;
                    }

                    if (@event.Img3up != null && @event.Img3up.Length > 0)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Path.GetFileNameWithoutExtension(@event.Img3up.FileName);
                        string extension = Path.GetExtension(@event.Img3up.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwRootPath + "/img/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await @event.Img3up.CopyToAsync(fileStream);
                        }
                        @event.Img3 = fileName;
                    }
                    _context.Update(@event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@event.Id))
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
            return View(@event);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event != null)
            {
                _context.Events.Remove(@event);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Events.Any(e => e.Id == id);
        }
    }
}
