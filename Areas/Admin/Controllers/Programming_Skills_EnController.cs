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
    public class Programming_Skills_EnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Programming_Skills_EnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Programming_Skills_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.Programming_Skills_En.ToListAsync());
        }

        // GET: Admin/Programming_Skills_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programming_Skills_En = await _context.Programming_Skills_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programming_Skills_En == null)
            {
                return NotFound();
            }

            return View(programming_Skills_En);
        }

        // GET: Admin/Programming_Skills_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Programming_Skills_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Programming_Skills_En programming_Skills_En)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programming_Skills_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programming_Skills_En);
        }

        // GET: Admin/Programming_Skills_En/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programming_Skills_En = await _context.Programming_Skills_En.FindAsync(id);
            if (programming_Skills_En == null)
            {
                return NotFound();
            }
            return View(programming_Skills_En);
        }

        // POST: Admin/Programming_Skills_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Programming_Skills_En programming_Skills_En)
        {
            if (id != programming_Skills_En.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programming_Skills_En);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Programming_Skills_EnExists(programming_Skills_En.Id))
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
            return View(programming_Skills_En);
        }

        // GET: Admin/Programming_Skills_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programming_Skills_En = await _context.Programming_Skills_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (programming_Skills_En == null)
            {
                return NotFound();
            }

            return View(programming_Skills_En);
        }

        // POST: Admin/Programming_Skills_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var programming_Skills_En = await _context.Programming_Skills_En.FindAsync(id);
            _context.Programming_Skills_En.Remove(programming_Skills_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Programming_Skills_EnExists(int id)
        {
            return _context.Programming_Skills_En.Any(e => e.Id == id);
        }
    }
}
