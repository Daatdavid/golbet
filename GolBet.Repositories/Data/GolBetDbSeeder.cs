using GolBet.Entities;
using GolBet.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace GolBet.Repositories.Data;

public static class GolBetDbSeeder
{
    public static async Task SeedAsync(GolBetDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Teams.AnyAsync())
        {
            return;
        }

        var now = DateTime.UtcNow;

        var teams = new List<Team>
        {
            new Team
            {
                Name = "Atlético Nacional",
                LogoUrl = "https://ssl.gstatic.com/onebox/media/sports/logos/optimized/i6-Yda76iPfeYEg4JcNbuw_64x64.png",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Millonarios FC",
                LogoUrl = "https://a.espncdn.com/i/teamlogos/soccer/500/5484.png",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "América de Cali",
                LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2PD-7KodNmPbvpcZ1jlpopwQZMN5sLTiupI_A7Tnp-w&s=10",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Independiente Medellín",
                LogoUrl = "https://a.espncdn.com/combiner/i?img=/i/teamlogos/soccer/500/2690.png",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Deportivo Cali",
                LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRomx812xkCacDIPtPwbLbcWUlipMhQ96j2DvtwifILcw&s",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Junior FC",
                LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQy6B8_XmfvVkmxansSP3_Rk27_UKNcVyD_RxUm6jPSnw&s=10",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Santa Fe",
                LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRd6yIwkaVvVtfCigbZHu4m_wGfT0IguybkyhFANKw_hw&s=10",
                CreatedAt = now,
                UpdatedAt = now
            },
            new Team
            {
                Name = "Once Caldas",
                LogoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWH_GuXMnv61B1XnAmyHGbYrT45OfCO8uy0HMmAc5ZEA&s",
                CreatedAt = now,
                UpdatedAt = now
            }
        };

        await context.Teams.AddRangeAsync(teams);
        await context.SaveChangesAsync();

        var matches = new List<Match>
        {
            new Match
            {
                HomeTeamId = teams[0].Id,
                AwayTeamId = teams[1].Id,
                MatchDate = DateTime.UtcNow.AddDays(1),
                Status = MatchStatus.Programado,
                HomeOdds = 1.85m,
                DrawOdds = 3.40m,
                AwayOdds = 4.20m,
                HomeScore = null,
                AwayScore = null,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Match
            {
                HomeTeamId = teams[2].Id,
                AwayTeamId = teams[3].Id,
                MatchDate = DateTime.UtcNow.AddDays(2),
                Status = MatchStatus.Programado,
                HomeOdds = 2.10m,
                DrawOdds = 3.20m,
                AwayOdds = 3.50m,
                HomeScore = null,
                AwayScore = null,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Match
            {
                HomeTeamId = teams[4].Id,
                AwayTeamId = teams[5].Id,
                MatchDate = DateTime.UtcNow.AddHours(2),
                Status = MatchStatus.EnVivo,
                HomeOdds = 2.00m,
                DrawOdds = 3.30m,
                AwayOdds = 3.75m,
                HomeScore = 1,
                AwayScore = 1,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Match
            {
                HomeTeamId = teams[6].Id,
                AwayTeamId = teams[7].Id,
                MatchDate = DateTime.UtcNow.AddDays(-1),
                Status = MatchStatus.Finalizado,
                HomeOdds = 1.95m,
                DrawOdds = 3.25m,
                AwayOdds = 4.00m,
                HomeScore = 2,
                AwayScore = 0,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Match
            {
                HomeTeamId = teams[1].Id,
                AwayTeamId = teams[4].Id,
                MatchDate = DateTime.UtcNow.AddDays(3),
                Status = MatchStatus.Programado,
                HomeOdds = 1.75m,
                DrawOdds = 3.60m,
                AwayOdds = 4.50m,
                HomeScore = null,
                AwayScore = null,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            },
            new Match
            {
                HomeTeamId = teams[3].Id,
                AwayTeamId = teams[6].Id,
                MatchDate = DateTime.UtcNow.AddDays(-2),
                Status = MatchStatus.Finalizado,
                HomeOdds = 2.25m,
                DrawOdds = 3.10m,
                AwayOdds = 3.20m,
                HomeScore = 1,
                AwayScore = 2,
                BetsCount = 0,
                CreatedAt = now,
                UpdatedAt = now
            }
        };

        await context.Matches.AddRangeAsync(matches);
        await context.SaveChangesAsync();
    }
}