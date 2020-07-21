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
    public class Personal_Info_EnController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public Personal_Info_EnController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/Personal_Info_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.Personal_Info_En.ToListAsync());
        }

        // GET: Admin/Personal_Info_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_Info_En = await _context.Personal_Info_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal_Info_En == null)
            {
                return NotFound();
            }

            return View(personal_Info_En);
        }

        // GET: Admin/Personal_Info_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Personal_Info_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Mobile,Email,Nationality,Residence,ImageFile")] Personal_Info_En personal_Info_En)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsEn
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(personal_Info_En.ImageFile.FileName);
                string extension = Path.GetExtension(personal_Info_En.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                personal_Info_En.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/Personal_Info_En/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await personal_Info_En.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(personal_Info_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal_Info_En);
        }

        // GET: Admin/Personal_Info_En/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            Personal_Info_En personal_Info_En2 = await _context.Personal_Info_En.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (personal_Info_En2 == null)

            {
                return NotFound();
            }



            return View(personal_Info_En2);

        }


        // POST: Admin/Personal_Info_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Personal_Info_En personal_Info_En, IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }

            Personal_Info_En personal_Info_En2 = await _context.Personal_Info_En.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (personal_Info_En2 == null)

            {

                return NotFound();

            }

            if (file != null || file.Length != 0)

            {

                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images/Personal_Info_En", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                personal_Info_En2.ImageName = filename;

            }

            personal_Info_En2.Mobile = personal_Info_En.Mobile;
            personal_Info_En2.Email = personal_Info_En.Email;
            personal_Info_En2.Nationality = personal_Info_En.Nationality;
            personal_Info_En2.Residence = personal_Info_En.Residence;
           



            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/Personal_Info_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personal_Info_En = await _context.Personal_Info_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal_Info_En == null)
            {
                return NotFound();
            }

            return View(personal_Info_En);
        }

        // POST: Admin/Personal_Info_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personal_Info_En = await _context.Personal_Info_En.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/Personal_Info_En", personal_Info_En.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.Personal_Info_En.Remove(personal_Info_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Personal_Info_EnExists(int id)
        {
            return _context.Personal_Info_En.Any(e => e.Id == id);
        }
    }
}
