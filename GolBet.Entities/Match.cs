using GolBet.Entities.Enums;

namespace GolBet.Entities;

public class Match : AuditableEntity
{
    public int HomeTeamId { get; set; }

    public int AwayTeamId { get; set; }

    public DateTime MatchDate { get; set; }

    public MatchStatus Status { get; set; }

    public decimal HomeOdds { get; set; }

    public decimal DrawOdds { get; set; }

    public decimal AwayOdds { get; set; }

    public int? HomeScore { get; set; }

    public int? AwayScore { get; set; }

    public int BetsCount { get; set; }

    public Team HomeTeam { get; set; } = null!;

    public Team AwayTeam { get; set; } = null!;
}