using GolBet.Services.DTOs;

namespace GolBet.Services.Interfaces;

public interface IMatchService
{
    Task<IEnumerable<MatchDto>> GetAllAsync();
    Task<MatchDto?> GetByIdAsync(int id);
}