
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

    public async Task<IActionResult> Index(string? status, string? search)
    {
        MatchStatus? parsedStatus = null;

        if (!string.IsNullOrWhiteSpace(status) &&
            Enum.TryParse<MatchStatus>(status, true, out var statusValue))
        {
            parsedStatus = statusValue;
        }

        var matches = await _matchService.GetAllAsync(search, parsedStatus);

        ViewBag.CurrentStatus = status;
        ViewBag.CurrentSearch = search;

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
