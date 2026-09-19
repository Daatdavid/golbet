using GolBet.Entities;
using GolBet.Repositories.Data;
using GolBet.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GolBet.Repositories.Repositories;

public class MatchRepository : GenericRepository<Match>
{
    public MatchRepository(GolBetDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<Match>> GetAllWithTeamsAsync()
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .ToListAsync();
    }

    public async Task<Match?> GetByIdWithTeamsAsync(int id)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}