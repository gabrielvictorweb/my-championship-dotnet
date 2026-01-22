using my_championship.Domain.Entities;
using my_championship.Infrastructure.Data;

namespace my_championship.Infrastructure.Repositories;

public class TeamKeyRepository
{
    private readonly AppDbContext _context;

    public TeamKeyRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(TeamKey teamKey)
    {
        _context.TeamKeys.Add(teamKey);
        _context.SaveChanges();
    }

    public TeamKey? GetById(Guid id)
    {
        return _context.TeamKeys.Find(id);
    }

    public IEnumerable<TeamKey> GetAll()
    {
        return _context.TeamKeys.ToList();
    }

    public void Update(TeamKey teamKey)
    {
        _context.TeamKeys.Update(teamKey);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var teamKey = _context.TeamKeys.Find(id);
        if (teamKey != null)
        {
            _context.TeamKeys.Remove(teamKey);
            _context.SaveChanges();
        }
    }
}