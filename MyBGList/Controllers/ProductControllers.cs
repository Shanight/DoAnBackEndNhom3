// Trong namespace MyBGList.Controllers
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBGList.Models;
using System.Collections.Generic;
using System.Linq;

[Route("[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return _context.Products.ToList();
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public ActionResult<Product> GetById(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost(Name = "AddProduct")]
    public ActionResult<Product> AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}", Name = "UpdateProduct")]
    public IActionResult UpdateProduct(int id, Product updatedProduct)
    {
        if (id != updatedProduct.Id)
        {
            return BadRequest();
        }

        _context.Entry(updatedProduct).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteProduct")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        return NoContent();
    }
}
