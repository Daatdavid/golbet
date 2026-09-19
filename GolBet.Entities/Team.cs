namespace GolBet.Entities;

public class Team : AuditableEntity
{
    public string Name { get; set; } = string.Empty;

    public string? LogoUrl { get; set; }
}