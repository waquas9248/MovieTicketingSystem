using Dapper;
using Microsoft.AspNetCore.Mvc;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService orderService;

    public OrderController(IOrderService orderService)
    {
        this.orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessOrder()
    {
        var customerId = HttpContext.Session.GetInt32(SessionKeys.CustomerId) ?? 0;
        var seatId = HttpContext.Session.GetInt32(SessionKeys.SeatSelectionId) ?? 0;
        var showingId = HttpContext.Session.GetInt32(SessionKeys.ShowingSelectionId) ?? 0 ;

        var concessionQuantitiesStrings = HttpContext.Request.Form.First().Value;
        var concessionQuantities = concessionQuantitiesStrings.Select(s => int.Parse(s));
        
        var orderViewModel = await orderService.ProcessOrder(customerId, seatId, showingId, concessionQuantities.ToList());

        return View(orderViewModel);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
}
