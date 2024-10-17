﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EducationController : ControllerBase
{
    private readonly AppDbContext _context;

    public EducationController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Education>>> GetEducations()
    {
        return await _context.Educations.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Education>> GetEducation(int id)
    {
        var education = await _context.Educations.FindAsync(id);
        if (education == null) return NotFound();
        return education;
    }

    [HttpPost]
    public async Task<ActionResult<Education>> PostEducation(Education education)
    {
        _context.Educations.Add(education);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEducation), new { id = education.Id }, education);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEducation(int id, Education education)
    {
        if (id != education.Id) return BadRequest();
        _context.Entry(education).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEducation(int id)
    {
        var education = await _context.Educations.FindAsync(id);
        if (education == null) return NotFound();
        _context.Educations.Remove(education);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
