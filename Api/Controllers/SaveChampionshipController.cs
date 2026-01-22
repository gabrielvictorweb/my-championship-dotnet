using Microsoft.AspNetCore.Mvc;
using my_championship.Application.DTOs;
using my_championship.Domain.Entities;
using my_championship.Application.UseCases;
using my_championship.Api.Presenters;

namespace my_championship.Controllers;

[ApiController]
[Route("championship")]
[Tags("Championships")]
public class SaveChampionshipsController : ControllerBase
{
    private readonly SaveTeam _saveTeam;
    private readonly SaveTeamKey _saveTeamKey;
    private readonly SaveChampionship _saveChampionship;


    public SaveChampionshipsController(SaveChampionship saveChampionship, SaveTeam saveTeam, SaveTeamKey saveTeamKey)
    {
        _saveChampionship = saveChampionship;
        _saveTeam = saveTeam;
        _saveTeamKey = saveTeamKey;
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

        var teams = new List<Team>();

        foreach (var teamName in dto.TeamNames)
        {
            var team = new Team
            {
                Id = Guid.NewGuid(),
                Name = teamName,
                ChampionshipId = championship.Id
            };

            _saveTeam.Execute(team);
            teams.Add(team);

            var teamKey = new TeamKey
            {
                Id = Guid.NewGuid(),
                ChampionshipId = championship.Id,
                TeamId = team.Id,
                Key = Guid.NewGuid().ToString()
            };

            _saveTeamKey.Execute(teamKey);
        }

        var presenter = new ChampionshipPresenter
        {
            Id = championship.Id,
            Name = championship.Name,
            Location = championship.Location,
            Teams = teams.Select(t => new ChampionshipPresenter.TeamPresenter
            {
                Id = t.Id,
                Name = t.Name
            })
        };

        return CreatedAtAction(
            nameof(Create),
            new { id = presenter.Id },
            presenter
        );
    }
}
