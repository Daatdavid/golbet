
using GolBet.Services.DTOs;

namespace GolBet.Services.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<MatchDto>> GetAllAsync(string? search = null);
    Task<MatchDto?> GetByIdAsync(int id);
}
