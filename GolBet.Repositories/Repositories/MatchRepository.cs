
using GolBet.Entities;
using GolBet.Entities.Enums;
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

    public async Task<IEnumerable<Match>> GetAllWithTeamsAsync(
        string? search = null,
        MatchStatus? status = null)
    {
        var query = _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var searchTerm = search.Trim().ToLower();

            query = query.Where(m =>
                m.HomeTeam.Name.ToLower().Contains(searchTerm) ||
                m.AwayTeam.Name.ToLower().Contains(searchTerm));
        }

        if (status.HasValue)
        {
            query = query.Where(m => m.Status == status.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Match?> GetByIdWithTeamsAsync(int id)
    {
        return await _context.Matches
            .Include(m => m.HomeTeam)
            .Include(m => m.AwayTeam)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
}
