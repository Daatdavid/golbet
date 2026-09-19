using GolBet.Entities;
using Microsoft.EntityFrameworkCore;

namespace GolBet.Repositories.Data;

public class GolBetDbContext : DbContext
{
    public GolBetDbContext(DbContextOptions<GolBetDbContext> options)
        : base(options)
    {
    }

    public DbSet<Team> Teams => Set<Team>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<Bet> Bets => Set<Bet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(t => t.LogoUrl)
                .HasMaxLength(500);

            entity.HasIndex(t => t.Name)
                .IsUnique();
        });

        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.HomeOdds)
                .HasPrecision(10, 2);

            entity.Property(m => m.DrawOdds)
                .HasPrecision(10, 2);

            entity.Property(m => m.AwayOdds)
                .HasPrecision(10, 2);

            entity.HasOne(m => m.HomeTeam)
                .WithMany()
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.AwayTeam)
                .WithMany()
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Bet>(entity =>
        {
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Amount)
                .HasPrecision(10, 2);

            entity.Property(b => b.Odds)
                .HasPrecision(10, 2);

            entity.HasOne(b => b.Match)
                .WithMany()
                .HasForeignKey(b => b.MatchId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}