using Microsoft.AspNetCore.Mvc;
using Theater.ViewModels;

namespace Theater.Controllers;

public class DateSelectController : Controller
{
    public DateSelectController()
    {
    }

    [HttpGet]
    public IActionResult DateSelect()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DateSelect(DateSelection date)
    {
        if (ModelState.IsValid == false || date.DateTime.Date < DateTime.Now.Date)
        {
            ViewData.Add("invalidDate", true);
            return Redirect($"/DateSelect/DateSelect");
        }

        HttpContext.Session.SetString(SessionKeys.UtcTicks, date.DateTime.Ticks.ToString());
        return Redirect($"/Showing/Select");
    }
}
