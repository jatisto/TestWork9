using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestWork9.Data;
using TestWork9.Models;

namespace TestWork9.Controllers
{
    public class AddBalancesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AddBalancesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AddBalances
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddBalances.ToListAsync());
        }

        // GET: AddBalances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addBalance = await _context.AddBalances
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addBalance == null)
            {
                return NotFound();
            }

            return View(addBalance);
        }

        // GET: AddBalances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddBalances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SumAdd,Id")] AddBalance addBalance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addBalance);
                Transaction(addBalance.Id, addBalance.SumAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addBalance);
        }

        // GET: AddBalances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addBalance = await _context.AddBalances.SingleOrDefaultAsync(m => m.Id == id);
            if (addBalance == null)
            {
                return NotFound();
            }
            return View(addBalance);
        }

        // POST: AddBalances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SumAdd,Id")] AddBalance addBalance)
        {
            if (id != addBalance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addBalance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddBalanceExists(addBalance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(addBalance);
        }

        // GET: AddBalances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addBalance = await _context.AddBalances
                .SingleOrDefaultAsync(m => m.Id == id);
            if (addBalance == null)
            {
                return NotFound();
            }

            return View(addBalance);
        }

        // POST: AddBalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var addBalance = await _context.AddBalances.SingleOrDefaultAsync(m => m.Id == id);
            _context.AddBalances.Remove(addBalance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddBalanceExists(string id)
        {
            return _context.AddBalances.Any(e => e.Id == id);
        }

        public void Transaction(string id, double addBalance)
        {
            var user = _userManager.GetUserAsync(User);
            var userId = _context.Users.SingleOrDefault(m => m.Id == id);
            //            var user = new ApplicationUser();
            userId.Balance += userId.Balance;
            _context.Users.Add(userId);
        }
    }
}
