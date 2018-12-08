using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWork9.Data;

namespace TestWork9.Models
{
    public class ApplicationUserVM : ViewComponent
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserVM(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public new ClaimsPrincipal User { get; set; }
        public string ReturnUrl { get; set; }
        public ApplicationUser Balance { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Users.FirstOrDefault());
        }
    }
}