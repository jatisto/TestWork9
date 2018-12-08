using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TestWork9.Data;

namespace TestWork9.Models
{
    public class ApplicationUserVM : ViewComponent
    {
        static Random generator = new Random();
        private static double _balance = 1000;
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserVM(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string ReturnUrl { get; set; }
        public ApplicationUser Balance { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!AddUserExists(UserId))
            {
                return View(new ApplicationUser()
                {
                    UserName = generator.Next(0, 1000000).ToString("D6"),
                    Balance = _balance
                });
            }
            return View(_context.Users.FirstOrDefault());
        }

        private bool AddUserExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}