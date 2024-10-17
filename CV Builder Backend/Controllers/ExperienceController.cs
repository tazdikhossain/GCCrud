using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ExperienceController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExperienceController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Experience>>> GetExperiences()
    {
        return await _context.Experiences.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Experience>> GetExperience(int id)
    {
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null) return NotFound();
        return experience;
    }

    [HttpPost]
    public async Task<ActionResult<Experience>> PostExperience(Experience experience)
    {
        _context.Experiences.Add(experience);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetExperience), new { id = experience.Id }, experience);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutExperience(int id, Experience experience)
    {
        if (id != experience.Id) return BadRequest();
        _context.Entry(experience).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExperience(int id)
    {
        var experience = await _context.Experiences.FindAsync(id);
        if (experience == null) return NotFound();
        _context.Experiences.Remove(experience);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
