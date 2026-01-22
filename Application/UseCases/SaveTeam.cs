using my_championship.Domain.Entities;
using my_championship.Infrastructure.Repositories;

namespace my_championship.Application.UseCases;

public class SaveTeam
{
    private readonly TeamRepository _teamRepository;

    public SaveTeam(TeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public void Execute(Team team)
    {
        _teamRepository.Add(team);
    }
}