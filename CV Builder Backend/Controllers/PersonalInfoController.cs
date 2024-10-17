using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PersonalInfoController : ControllerBase
{
    private readonly AppDbContext _context;

    public PersonalInfoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonalInfo>>> GetPersonalInfos()
    {
        return await _context.PersonalInfos.Include(p => p.Educations).Include(p => p.Experiences).Include(p => p.Skills).Include(p => p.Accomplishments).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonalInfo>> GetPersonalInfo(int id)
    {
        var personalInfo = await _context.PersonalInfos.FindAsync(id);
        if (personalInfo == null) return NotFound();
        return personalInfo;
    }

    [HttpPost]
    public async Task<ActionResult<PersonalInfo>> PostPersonalInfo(PersonalInfo personalInfo)
    {
        _context.PersonalInfos.Add(personalInfo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPersonalInfo), new { id = personalInfo.Id }, personalInfo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPersonalInfo(int id, PersonalInfo personalInfo)
    {
        if (id != personalInfo.Id) return BadRequest();
        _context.Entry(personalInfo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonalInfo(int id)
    {
        var personalInfo = await _context.PersonalInfos.FindAsync(id);
        if (personalInfo == null) return NotFound();
        _context.PersonalInfos.Remove(personalInfo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
