using Microsoft.AspNetCore.Mvc;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class ShowingController: Controller
{
    private readonly IShowingService showingService;

    public ShowingController(IShowingService showingService)
    {
        this.showingService = showingService;
    }

    [HttpGet]
    public async Task<IActionResult> Select()
    {
        var utcTicksStr = HttpContext.Session.GetString(SessionKeys.UtcTicks) ?? String.Empty;
        var utc = long.Parse(utcTicksStr);
        var date = new DateTime(utc);
        var showings = await showingService.GetShowings(date);
        var showingModel = new ShowingViewModel { Showings = showings, SelectedShowingId = 0 };
        return View(showingModel);
    }
}
