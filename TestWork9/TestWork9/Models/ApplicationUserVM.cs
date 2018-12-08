using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWork9.Data;

namespace TestWork9.Models
{
    public class ApplicationUserVM : ViewComponent
    {
        private ApplicationDbContext _context;
        public ApplicationUserVM(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicationUser User { get; set; }
        public string ReturnUrl { get; set; }
        public ApplicationUser Balance { get; set; }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            return View(_context.Users.FirstOrDefault());
        }
    }
}