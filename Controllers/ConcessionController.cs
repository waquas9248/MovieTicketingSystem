using Microsoft.AspNetCore.Mvc;
using Theater.DBModels;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class ConcessionController : Controller
{
    private readonly IConcessionService concessionService;

    public ConcessionController(IConcessionService concessionService)
    {
        this.concessionService = concessionService;
    }

    [HttpGet]
    public IActionResult Select()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Select(int seatId)
    {
        var concessions = await concessionService.GetConcessions();

        // Set inventoryQuantity to 0 so we can reuse the Concession model.
        foreach (var concession in concessions)
        {
            concession.InventoryQuantity = 0;
        }
        var concessionViewModel = new ConcessionViewModel { Concessions = concessions };
       
        HttpContext.Session.SetInt32(SessionKeys.SeatSelectionId, seatId);
        return View(concessionViewModel);
    }
}
