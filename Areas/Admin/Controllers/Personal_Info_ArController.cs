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
    public class Personal_Info_ArController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Personal_Info_ArController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Personal_Info_Ar
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personal_Info_Ar.ToListAsync());
        }

        // GET: Admin/Personal_Info_Ar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_Info_Ar = await _context.Personal_Info_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal_Info_Ar == null)
            {
                return NotFound();
            }

            return View(personal_Info_Ar);
        }

        // GET: Admin/Personal_Info_Ar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Personal_Info_Ar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mobile,Email,Nationality,Residence,ImageFile")] Personal_Info_Ar personal_Info_Ar)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsEn
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(personal_Info_Ar.ImageFile.FileName);
                string extension = Path.GetExtension(personal_Info_Ar.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                personal_Info_Ar.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/Personal_Info_Ar/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await personal_Info_Ar.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(personal_Info_Ar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal_Info_Ar);
        }

        // GET: Admin/Personal_Info_Ar/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            Personal_Info_Ar personal_Info_Ar2 = await _context.Personal_Info_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (personal_Info_Ar2 == null)

            {
                return NotFound();
            }



            return View(personal_Info_Ar2);

        }


        // POST: Admin/Personal_Info_Ar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Personal_Info_Ar personal_Info_Ar, IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }

            Personal_Info_Ar personal_Info_Ar2 = await _context.Personal_Info_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (personal_Info_Ar2 == null)

            {

                return NotFound();

            }

            if (file != null || file.Length != 0)

            {

                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images/Personal_Info_Ar", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                personal_Info_Ar2.ImageName = filename;

            }

            personal_Info_Ar2.Mobile = personal_Info_Ar.Mobile;
            personal_Info_Ar2.Email = personal_Info_Ar.Email;
            personal_Info_Ar2.Nationality = personal_Info_Ar.Nationality;
            personal_Info_Ar2.Residence = personal_Info_Ar.Residence;
           



            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/Personal_Info_Ar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_Info_Ar = await _context.Personal_Info_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal_Info_Ar == null)
            {
                return NotFound();
            }

            return View(personal_Info_Ar);
        }

        // POST: Admin/Personal_Info_Ar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personal_Info_Ar = await _context.Personal_Info_Ar.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/Personal_Info_Ar", personal_Info_Ar.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.Personal_Info_Ar.Remove(personal_Info_Ar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Personal_Info_ArExists(int id)
        {
            return _context.Personal_Info_Ar.Any(e => e.Id == id);
        }
    }
}
