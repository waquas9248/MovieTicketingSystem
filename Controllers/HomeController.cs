using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Theater.Models;

namespace Theater.Controllers;

public class HomeController : Controller
{
    /// <summary>
    /// Gets the index view
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return Redirect("/User/Login");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}