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

    public class Current_Work_EnController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Current_Work_EnController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Current_Work_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.Current_Work_En.ToListAsync());
        }

        // GET: Admin/Current_Work_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var current_Work_En = await _context.Current_Work_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (current_Work_En == null)
            {
                return NotFound();
            }

            return View(current_Work_En);
        }

        // GET: Admin/Current_Work_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Current_Work_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Current_Work_En current_Work_En)
        {
            if (ModelState.IsValid)
            {
                _context.Add(current_Work_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(current_Work_En);
        }

        // GET: Admin/Current_Work_En/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var current_Work_En = await _context.Current_Work_En.FindAsync(id);
            if (current_Work_En == null)
            {
                return NotFound();
            }
            return View(current_Work_En);
        }

        // POST: Admin/Current_Work_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Current_Work_En current_Work_En)
        {
            if (id != current_Work_En.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(current_Work_En);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Current_Work_EnExists(current_Work_En.Id))
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
            return View(current_Work_En);
        }

        // GET: Admin/Current_Work_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var current_Work_En = await _context.Current_Work_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (current_Work_En == null)
            {
                return NotFound();
            }

            return View(current_Work_En);
        }

        // POST: Admin/Current_Work_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var current_Work_En = await _context.Current_Work_En.FindAsync(id);
            _context.Current_Work_En.Remove(current_Work_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Current_Work_EnExists(int id)
        {
            return _context.Current_Work_En.Any(e => e.Id == id);
        }
    }
}
