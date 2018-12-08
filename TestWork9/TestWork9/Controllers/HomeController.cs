using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Localization;
using TestWork9.Data;
using TestWork9.Models;

namespace TestWork9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ViewResult Index(ApplicationUser user, string returnUrl)
        {
            var balance = _context.Users.FirstOrDefault();
            return View(/*new ApplicationUserVM()
            {
                User = user,
                Balance = balance,
                ReturnUrl = returnUrl
            }*/);
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /*public PartialViewResult Balance()
        {
            var balance = _context.Users.FirstOrDefault();

            return PartialView(balance);
        }*/
    }
}
