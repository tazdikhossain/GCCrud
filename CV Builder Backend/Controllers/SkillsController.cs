using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SkillsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Skills>>> GetSkills()
    {
        return await _context.Skills.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Skills>> GetSkill(int id)
    {
        var skill = await _context.Skills.FindAsync(id);
        if (skill == null) return NotFound();
        return skill;
    }

    [HttpPost]
    public async Task<ActionResult<Skills>> PostSkill(Skills skill)
    {
        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSkill), new { id = skill.Id }, skill);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutSkill(int id, Skills skill)
    {
        if (id != skill.Id) return BadRequest();
        _context.Entry(skill).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSkill(int id)
    {
        var skill = await _context.Skills.FindAsync(id);
        if (skill == null) return NotFound();
        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
