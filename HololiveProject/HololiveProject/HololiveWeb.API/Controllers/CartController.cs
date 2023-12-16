using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HololiveWeb.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CartController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
    {
        return await _context.Carts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Cart>> GetCartById(int id)
    {
        var cart = await _context.Carts.FindAsync(id);

        if (cart == null)
        {
            return NotFound();
        }

        return cart;
    }

    [HttpPost]
    public async Task<ActionResult<Cart>> PostCart(Cart cart)
    {
        _context.Carts.Add(cart);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCartById), new { id = cart.Id }, cart);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCart(int id, Cart cart)
    {
        if (id != cart.Id)
        {
            return BadRequest();
        }

        _context.Entry(cart).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CartExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCart(int id)
    {
        var cart = await _context.Carts.FindAsync(id);
        if (cart == null)
        {
            return NotFound();
        }

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CartExists(int id)
    {
        return _context.Carts.Any(e => e.Id == id);
    }
}
