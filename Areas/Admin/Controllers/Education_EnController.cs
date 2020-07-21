using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadrBinHomeed_NEW.Data;
using BadrBinHomeed_NEW.Models;
using Microsoft.AspNetCore.Authorization;
using BadrBinHomeed_NEW.Utility;

namespace BadrBinHomeed_NEW.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class Education_EnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Education_EnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Education_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.Education_En.ToListAsync());
        }

        // GET: Admin/Education_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_En = await _context.Education_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education_En == null)
            {
                return NotFound();
            }

            return View(education_En);
        }

        // GET: Admin/Education_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Education_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Education_En education_En)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education_En);
        }

        // GET: Admin/Education_En/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_En = await _context.Education_En.FindAsync(id);
            if (education_En == null)
            {
                return NotFound();
            }
            return View(education_En);
        }

        // POST: Admin/Education_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Education_En education_En)
        {
            if (id != education_En.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education_En);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Education_EnExists(education_En.Id))
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
            return View(education_En);
        }

        // GET: Admin/Education_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_En = await _context.Education_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education_En == null)
            {
                return NotFound();
            }

            return View(education_En);
        }

        // POST: Admin/Education_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education_En = await _context.Education_En.FindAsync(id);
            _context.Education_En.Remove(education_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Education_EnExists(int id)
        {
            return _context.Education_En.Any(e => e.Id == id);
        }
    }
}
