using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AccomplishmentController : ControllerBase
{
    private readonly AppDbContext _context;

    public AccomplishmentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Accomplishment>>> GetAccomplishments()
    {
        return await _context.Accomplishments.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Accomplishment>> GetAccomplishment(int id)
    {
        var accomplishment = await _context.Accomplishments.FindAsync(id);
        if (accomplishment == null) return NotFound();
        return accomplishment;
    }

    [HttpPost]
    public async Task<ActionResult<Accomplishment>> PostAccomplishment(Accomplishment accomplishment)
    {
        _context.Accomplishments.Add(accomplishment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAccomplishment), new { id = accomplishment.Id }, accomplishment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAccomplishment(int id, Accomplishment accomplishment)
    {
        if (id != accomplishment.Id) return BadRequest();
        _context.Entry(accomplishment).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAccomplishment(int id)
    {
        var accomplishment = await _context.Accomplishments.FindAsync(id);
        if (accomplishment == null) return NotFound();
        _context.Accomplishments.Remove(accomplishment);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
