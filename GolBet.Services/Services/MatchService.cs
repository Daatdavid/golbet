
using AutoMapper;
using GolBet.Entities.Enums;
using GolBet.Repositories.Repositories;
using GolBet.Services.DTOs;
using GolBet.Services.Interfaces;

namespace GolBet.Services.Services;

public class MatchService : IMatchService
{
    private readonly MatchRepository _matchRepository;
    private readonly IMapper _mapper;

    public MatchService(
        MatchRepository matchRepository,
        IMapper mapper)
    {
        _matchRepository = matchRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MatchDto>> GetAllAsync(
        string? search = null,
        MatchStatus? status = null)
    {
        var matches = await _matchRepository.GetAllWithTeamsAsync(
            search,
            status);

        return _mapper.Map<IEnumerable<MatchDto>>(matches);
    }

    public async Task<MatchDto?> GetByIdAsync(int id)
    {
        var match = await _matchRepository.GetByIdWithTeamsAsync(id);

        if (match is null)
        {
            return null;
        }

        return _mapper.Map<MatchDto>(match);
    }
}
