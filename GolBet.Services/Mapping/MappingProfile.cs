using AutoMapper;
using GolBet.Entities;
using GolBet.Services.DTOs;

namespace GolBet.Services.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Match, MatchDto>()
            .ForMember(dest => dest.HomeTeamName,
                opt => opt.MapFrom(src => src.HomeTeam.Name))
            .ForMember(dest => dest.AwayTeamName,
                opt => opt.MapFrom(src => src.AwayTeam.Name))
            .ForMember(dest => dest.HomeTeamLogoUrl,
                opt => opt.MapFrom(src => src.HomeTeam.LogoUrl))
            .ForMember(dest => dest.AwayTeamLogoUrl,
                opt => opt.MapFrom(src => src.AwayTeam.LogoUrl));
    }
}