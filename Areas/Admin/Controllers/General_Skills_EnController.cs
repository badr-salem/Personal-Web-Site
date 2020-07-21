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
    public class General_Skills_EnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public General_Skills_EnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/General_Skills_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.General_Skills_En.ToListAsync());
        }

        // GET: Admin/General_Skills_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_Skills_En = await _context.General_Skills_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general_Skills_En == null)
            {
                return NotFound();
            }

            return View(general_Skills_En);
        }

        // GET: Admin/General_Skills_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/General_Skills_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] General_Skills_En general_Skills_En)
        {
            if (ModelState.IsValid)
            {
                _context.Add(general_Skills_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(general_Skills_En);
        }

        // GET: Admin/General_Skills_En/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_Skills_En = await _context.General_Skills_En.FindAsync(id);
            if (general_Skills_En == null)
            {
                return NotFound();
            }
            return View(general_Skills_En);
        }

        // POST: Admin/General_Skills_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] General_Skills_En general_Skills_En)
        {
            if (id != general_Skills_En.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(general_Skills_En);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!General_Skills_EnExists(general_Skills_En.Id))
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
            return View(general_Skills_En);
        }

        // GET: Admin/General_Skills_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_Skills_En = await _context.General_Skills_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (general_Skills_En == null)
            {
                return NotFound();
            }

            return View(general_Skills_En);
        }

        // POST: Admin/General_Skills_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var general_Skills_En = await _context.General_Skills_En.FindAsync(id);
            _context.General_Skills_En.Remove(general_Skills_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool General_Skills_EnExists(int id)
        {
            return _context.General_Skills_En.Any(e => e.Id == id);
        }
    }
}
