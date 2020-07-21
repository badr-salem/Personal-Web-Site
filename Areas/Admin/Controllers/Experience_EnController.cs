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
    public class Experience_EnController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Experience_EnController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Experience_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.Experience_En.ToListAsync());
        }

        // GET: Admin/Experience_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_En = await _context.Experience_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience_En == null)
            {
                return NotFound();
            }

            return View(experience_En);
        }

        // GET: Admin/Experience_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Experience_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Company_Name,Role_Name,Description,From,To,ImageFile")] Experience_En experience_En)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsEn
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(experience_En.ImageFile.FileName);
                string extension = Path.GetExtension(experience_En.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                experience_En.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/Experience_En/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await experience_En.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(experience_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(experience_En);
        }

        // GET: Admin/Experience_En/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            Experience_En experience_En2 = await _context.Experience_En.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (experience_En2 == null)

            {
                return NotFound();
            }



            return View(experience_En2);

        }


        // POST: Admin/Experience_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Experience_En experience_En, IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }

            Experience_En experience_En2 = await _context.Experience_En.Where(x => x.Id == id).FirstOrDefaultAsync();



            if (experience_En2 == null)

            {

                return NotFound();

            }

            if (file != null || file.Length != 0)

            {

                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images/Experience_En", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                experience_En2.ImageName = filename;

            }

            experience_En2.Company_Name = experience_En.Company_Name;
            experience_En2.Role_Name = experience_En.Role_Name;
            experience_En2.Description = experience_En.Description;
            experience_En2.From = experience_En.From;
            experience_En2.To = experience_En.To;



            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/Experience_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience_En = await _context.Experience_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience_En == null)
            {
                return NotFound();
            }

            return View(experience_En);
        }

        // POST: Admin/Experience_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience_En = await _context.Experience_En.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/Experience_En", experience_En.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.Experience_En.Remove(experience_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Experience_EnExists(int id)
        {
            return _context.Experience_En.Any(e => e.Id == id);
        }
    }
}
