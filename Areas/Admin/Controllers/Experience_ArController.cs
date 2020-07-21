using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BadrBinHomeed_NEW.Data;
using BadrBinHomeed_NEW.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using BadrBinHomeed_NEW.Utility;

namespace BadrBinHomeed_NEW.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class Experience_ArController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Experience_ArController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Experience_Ar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experience_Ar.ToListAsync());
        }

        // GET: Admin/Experience_Ar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_Ar = await _context.Experience_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience_Ar == null)
            {
                return NotFound();
            }

            return View(experience_Ar);
        }

        // GET: Admin/Experience_Ar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Experience_Ar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company_Name,Role_Name,Description,From,To,ImageFile")] Experience_Ar experience_Ar)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsEn
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(experience_Ar.ImageFile.FileName);
                string extension = Path.GetExtension(experience_Ar.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                experience_Ar.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/Experience_Ar/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await experience_Ar.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(experience_Ar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience_Ar);
        }

        // GET: Admin/Experience_Ar/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            Experience_Ar experience_Ar2 = await _context.Experience_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (experience_Ar2 == null)

            {
                return NotFound();
            }



            return View(experience_Ar2);

        }


        // POST: Admin/Experience_Ar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Experience_Ar experience_Ar, IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }

            Experience_Ar experience_Ar2 = await _context.Experience_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();



            if (experience_Ar2 == null)

            {

                return NotFound();

            }

            if (file != null || file.Length != 0)

            {

                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images/Experience_Ar", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                experience_Ar2.ImageName = filename;

            }

            experience_Ar2.Company_Name = experience_Ar.Company_Name;
            experience_Ar2.Role_Name = experience_Ar.Role_Name;
            experience_Ar2.Description = experience_Ar.Description;
            experience_Ar2.From = experience_Ar.From;
            experience_Ar2.To = experience_Ar.To;



            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/Experience_Ar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_Ar = await _context.Experience_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience_Ar == null)
            {
                return NotFound();
            }

            return View(experience_Ar);
        }

        // POST: Admin/Experience_Ar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience_Ar = await _context.Experience_Ar.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/Experience_Ar", experience_Ar.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.Experience_Ar.Remove(experience_Ar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Experience_ArExists(int id)
        {
            return _context.Experience_Ar.Any(e => e.Id == id);
        }
    }
}
