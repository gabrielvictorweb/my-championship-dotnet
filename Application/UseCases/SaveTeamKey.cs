using my_championship.Domain.Entities;
using my_championship.Infrastructure.Repositories;

namespace my_championship.Application.UseCases;

public class SaveTeamKey
{
    private readonly TeamKeyRepository _teamKeyRepository;

    public SaveTeamKey(TeamKeyRepository teamKeyRepository)
    {
        _teamKeyRepository = teamKeyRepository;
    }

    public void Execute(TeamKey teamKey)
    {
        _teamKeyRepository.Add(teamKey);
    }
}