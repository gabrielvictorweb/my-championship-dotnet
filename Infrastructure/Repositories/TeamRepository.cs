using my_championship.Domain.Entities;
using my_championship.Infrastructure.Data;

namespace my_championship.Infrastructure.Repositories;

public class TeamRepository
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Team team)
    {
        _context.Teams.Add(team);
        _context.SaveChanges();
    }

    public Team? GetById(Guid id)
    {
        return _context.Teams.Find(id);
    }

    public IEnumerable<Team> GetAll()
    {
        return _context.Teams.ToList();
    }

    public void Update(Team team)
    {
        _context.Teams.Update(team);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var team = _context.Teams.Find(id);
        if (team != null)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }
    }
}