using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HololiveWeb.API.Models;
using HololiveWeb.Models;
using Microsoft.AspNetCore.Authorization;

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;




namespace HololiveWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext1 _dbContext;
        public ProductsController(ApplicationDbContext1 dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _dbContext.Products.ToListAsync();
            return View(productList);
        }

        
        // GET: Products/Create
        public IActionResult Create()
        {
            return View("~/Views/Products/Create.cshtml");
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Catetory,img1,img2,img3,Preview1,Preview2,Preview3,Preview4,Preview5,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(product);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Products/Create.cshtml");
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View("~/Views/Products/edit.cshtml");
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Catetory,img1,img2,img3,Preview1,Preview2,Preview3,Preview4,Preview5,Price")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(product);
                    await _dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View("~/Views/Products/edit.cshtml");
        }

        private bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}