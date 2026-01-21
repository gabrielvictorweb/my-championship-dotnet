using my_championship.Domain.Entities;
using my_championship.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace my_championship.Infrastructure.Repositories;

public class ChampionshipRepository
{
    private readonly AppDbContext _dbContext;

    public ChampionshipRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Championship>> GetAllAsync()
    {
        return await _dbContext.Championships.ToListAsync();
    }

    public async Task<Championship?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Championships.FindAsync(id);
    }

    public async Task AddAsync(Championship championship)
    {
        await _dbContext.Championships.AddAsync(championship);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Championship championship)
    {
        _dbContext.Championships.Update(championship);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var championship = await GetByIdAsync(id);
        if (championship != null)
        {
            _dbContext.Championships.Remove(championship);
            await _dbContext.SaveChangesAsync();
        }
    }
}
