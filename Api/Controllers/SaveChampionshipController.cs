using Microsoft.AspNetCore.Mvc;
using my_championship.Application.DTOs;
using my_championship.Domain.Entities;
using my_championship.Infrastructure.Data;
using my_championship.Domain.UseCases;

namespace my_championship.Controllers;

[ApiController]
[Route("championship")]
public class SaveChampionshipsController : ControllerBase
{
    private readonly SaveChampionship _saveChampionship;

    public SaveChampionshipsController(SaveChampionship saveChampionship)
    {
        _saveChampionship = saveChampionship;
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

        await _saveChampionship.ExecuteAsync(championship);

        return CreatedAtAction(nameof(Create), championship);
    }
}
