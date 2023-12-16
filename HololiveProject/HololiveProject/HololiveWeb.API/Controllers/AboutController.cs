using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HololiveWeb.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AboutController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<About>>> GetAbouts()
    {
        return await _context.Abouts.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<About>> GetAboutById(int id)
    {
        var about = await _context.Abouts.FindAsync(id);

        if (about == null)
        {
            return NotFound();
        }

        return about;
    }

    [HttpPost]
    public async Task<ActionResult<About>> CreateAbout(About about)
    {
        _context.Abouts.Add(about);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAboutById), new { id = about.Id }, about);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAbout(int id, About about)
    {
        if (id != about.Id)
        {
            return BadRequest();
        }

        _context.Entry(about).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AboutExists(id))
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
    public async Task<IActionResult> DeleteAbout(int id)
    {
        var about = await _context.Abouts.FindAsync(id);
        if (about == null)
        {
            return NotFound();
        }

        _context.Abouts.Remove(about);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AboutExists(int id)
    {
        return _context.Abouts.Any(e => e.Id == id);
    }
}

