using GolBet.Entities.Enums;
using GolBet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolBet.Web.Controllers;

public class MatchesController : Controller
{
    private readonly IMatchService _matchService;

    public MatchesController(IMatchService matchService)
    {
        _matchService = matchService;
    }

    public async Task<IActionResult> Index(string? status)
    {
        var matches = await _matchService.GetAllAsync();

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (Enum.TryParse<MatchStatus>(status, true, out var parsedStatus))
            {
                matches = matches.Where(m => m.Status == parsedStatus);
            }
        }

        return View(matches);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var match = await _matchService.GetByIdAsync(id);

        if (match == null)
        {
            return NotFound();
        }

        return View(match);
    }
}