using Microsoft.AspNetCore.Mvc;
using my_championship.Application.DTOs;
using my_championship.Domain.Entities;
using my_championship.Infrastructure.Data;

namespace my_championship.Controllers;

[ApiController]
[Route("championship")]
public class SaveChampionshipsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SaveChampionshipsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateChampionshipDto dto)
    {
        var championship = new Championship
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Location = dto.Location
        };

        _context.Championships.Add(championship);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Create), championship);
    }
}
