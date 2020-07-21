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
    public class Education_ArController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Education_ArController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Education_Ar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Education_Ar.ToListAsync());
        }

        // GET: Admin/Education_Ar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_Ar = await _context.Education_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education_Ar == null)
            {
                return NotFound();
            }

            return View(education_Ar);
        }

        // GET: Admin/Education_Ar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Education_Ar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Education_Ar education_Ar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(education_Ar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(education_Ar);
        }

        // GET: Admin/Education_Ar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_Ar = await _context.Education_Ar.FindAsync(id);
            if (education_Ar == null)
            {
                return NotFound();
            }
            return View(education_Ar);
        }

        // POST: Admin/Education_Ar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Education_Ar education_Ar)
        {
            if (id != education_Ar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(education_Ar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Education_ArExists(education_Ar.Id))
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
            return View(education_Ar);
        }

        // GET: Admin/Education_Ar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education_Ar = await _context.Education_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education_Ar == null)
            {
                return NotFound();
            }

            return View(education_Ar);
        }

        // POST: Admin/Education_Ar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education_Ar = await _context.Education_Ar.FindAsync(id);
            _context.Education_Ar.Remove(education_Ar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Education_ArExists(int id)
        {
            return _context.Education_Ar.Any(e => e.Id == id);
        }
    }
}
