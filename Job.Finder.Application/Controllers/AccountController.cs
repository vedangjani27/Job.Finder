using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Job.Finder.Application.Models;

namespace Job.Finder.Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                // Validate the credentials against the database
                var admin = _context.Admin.SingleOrDefault(a => a.Username == model.Username && a.Password == model.Password);

                if (admin != null)
                {
                    // Create claims for the authenticated user
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, admin.Username)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    // Sign in the user
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    // Redirect to the home page after successful login
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If login fails, return to login page with error message
                    ViewData["ErrorMessage"] = "Invalid username or password";
                    return View();
                }
            }

            // If model state is not valid, return to login page with error message
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account"); // Redirect to login page after logout
        }
    }
}
