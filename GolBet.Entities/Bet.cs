using GolBet.Entities.Enums;

namespace GolBet.Entities;

public class Bet : AuditableEntity
{
    public int MatchId { get; set; }

    public BetType Type { get; set; }

    public decimal Amount { get; set; }

    public decimal Odds { get; set; }

    public Match Match { get; set; } = null!;
}
