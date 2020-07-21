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
    public class Social_MediaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Social_MediaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Social_Media
        public async Task<IActionResult> Index()
        {
            return View(await _context.Social_Media.ToListAsync());
        }

        // GET: Admin/Social_Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social_Media = await _context.Social_Media
                .FirstOrDefaultAsync(m => m.Id == id);
            if (social_Media == null)
            {
                return NotFound();
            }

            return View(social_Media);
        }

        // GET: Admin/Social_Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Social_Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Github_Url,Insta_Url,Linkedin_Url,Twitter_Url")] Social_Media social_Media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(social_Media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(social_Media);
        }

        // GET: Admin/Social_Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social_Media = await _context.Social_Media.FindAsync(id);
            if (social_Media == null)
            {
                return NotFound();
            }
            return View(social_Media);
        }

        // POST: Admin/Social_Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Github_Url,Insta_Url,Linkedin_Url,Twitter_Url")] Social_Media social_Media)
        {
            if (id != social_Media.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(social_Media);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Social_MediaExists(social_Media.Id))
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
            return View(social_Media);
        }

        // GET: Admin/Social_Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social_Media = await _context.Social_Media
                .FirstOrDefaultAsync(m => m.Id == id);
            if (social_Media == null)
            {
                return NotFound();
            }

            return View(social_Media);
        }

        // POST: Admin/Social_Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var social_Media = await _context.Social_Media.FindAsync(id);
            _context.Social_Media.Remove(social_Media);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Social_MediaExists(int id)
        {
            return _context.Social_Media.Any(e => e.Id == id);
        }
    }
}
