using Microsoft.AspNetCore.Mvc;
using Theater.Services;
using Theater.ViewModels;

namespace Theater.Controllers;

public class UserController: Controller
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult CreateAccount()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLogin loginRequest)
    {
        if (ModelState.IsValid)
        {
            var credentialsMatch = await userService.Login(loginRequest.Email, loginRequest.Password);
            if (credentialsMatch)
            {
                ViewData.Add("Email", loginRequest.Email);
                HttpContext.Session.SetString(SessionKeys.Email, loginRequest.Email);
                var account = await userService.GetAccount(loginRequest.Email);
                HttpContext.Session.SetInt32(SessionKeys.CustomerId, account?.CustomerId ?? 0);
                return Redirect($"/DateSelect/DateSelect");
            }
        }

        ViewData.Add("lastLoginFailed", true);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAccount(UserLogin accountCreation)
    {
        if (ModelState.IsValid == false)
        {
            ViewData.Add("accountCreationFailed", true);
            return View();
        }

        var accountCreated = await userService.CreateAccount(accountCreation.Email, accountCreation.Password);
        if(ModelState.IsValid == true && accountCreated == true)
        {
            return Redirect("/User/Login");
        }

        ViewData.Add("accountCreationFailed", true);
        return View();
    }
}
