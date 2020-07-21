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
    public class MyProjects_ArController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MyProjects_ArController(ApplicationDbContext context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/MyProjects_Ar
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyProjects_Ar.ToListAsync());
        }

        // GET: Admin/MyProjects_Ar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProjects_Ar = await _context.MyProjects_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProjects_Ar == null)
            {
                return NotFound();
            }

            return View(myProjects_Ar);
        }

        // GET: Admin/MyProjects_Ar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MyProjects_Ar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BuiltBy,Description,Github_Url,Live_Url,ImageFile")] MyProjects_Ar myProjects_Ar)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsAr
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(myProjects_Ar.ImageFile.FileName);
                string extension = Path.GetExtension(myProjects_Ar.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                myProjects_Ar.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/MyProjectsAr/", fileName);

                using(var fileStream = new FileStream(path , FileMode.Create))
                {
                    await myProjects_Ar.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(myProjects_Ar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myProjects_Ar);
        }

        // GET: Admin/MyProjects_Ar/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            MyProjects_Ar myProjects_Ar2 = await _context.MyProjects_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (myProjects_Ar2 == null)

            {
                return NotFound();
            }



            return View(myProjects_Ar2);

        }


        // POST: Admin/MyProjects_Ar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, MyProjects_Ar myProjects_Ar , IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }



            MyProjects_Ar myProjects_Ar2 = await _context.MyProjects_Ar.Where(x => x.Id == id).FirstOrDefaultAsync();



            if (myProjects_Ar2 == null)

            {

                return NotFound();

            }





            if (file != null || file.Length != 0)

            {



                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(

                            Directory.GetCurrentDirectory(), "wwwroot", "Images/MyProjectsAr", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                myProjects_Ar2.ImageName = filename;

            }
           







            myProjects_Ar2.Name = myProjects_Ar.Name;

            myProjects_Ar2.Description = myProjects_Ar.Description;

            myProjects_Ar2.BuiltBy = myProjects_Ar.BuiltBy;

            myProjects_Ar2.Github_Url = myProjects_Ar.Github_Url;

            myProjects_Ar2.Live_Url = myProjects_Ar.Live_Url;

            






            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/MyProjects_Ar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProjects_Ar = await _context.MyProjects_Ar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProjects_Ar == null)
            {
                return NotFound();
            }

            return View(myProjects_Ar);
        }

        // POST: Admin/MyProjects_Ar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myProjects_Ar = await _context.MyProjects_Ar.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/MyProjectsAr", myProjects_Ar.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.MyProjects_Ar.Remove(myProjects_Ar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyProjects_ArExists(int id)
        {
            return _context.MyProjects_Ar.Any(e => e.Id == id);
        }
    }
}
