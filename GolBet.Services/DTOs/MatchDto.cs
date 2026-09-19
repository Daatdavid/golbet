using GolBet.Entities.Enums;

namespace GolBet.Services.DTOs;

public class MatchDto
{
    public int Id { get; set; }

    public string HomeTeamName { get; set; } = string.Empty;
    public string AwayTeamName { get; set; } = string.Empty;

    public string? HomeTeamLogoUrl { get; set; }
    public string? AwayTeamLogoUrl { get; set; }

    public DateTime MatchDate { get; set; }
    public MatchStatus Status { get; set; }

    public decimal HomeOdds { get; set; }
    public decimal DrawOdds { get; set; }
    public decimal AwayOdds { get; set; }

    public int? HomeScore { get; set; }
    public int? AwayScore { get; set; }

    public int BetsCount { get; set; }
}