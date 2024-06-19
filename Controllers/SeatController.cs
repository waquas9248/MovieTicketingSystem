using Microsoft.AspNetCore.Mvc;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class SeatController : Controller
{
    private readonly ISeatService seatService;

    public SeatController(ISeatService seatService)
    {
        this.seatService = seatService;
    }

    [HttpGet]
    public IActionResult Select()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Select(int showingId)
    {
        var availableSeats = await seatService.GetSeatsForShowing(showingId);
        HttpContext.Session.SetInt32(SessionKeys.ShowingSelectionId, showingId);
        var seatModel = new SeatTicketViewModel { Tickets = availableSeats };
        return View(seatModel);
    }
}
