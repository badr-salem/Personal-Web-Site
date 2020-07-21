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
    public class MyProjects_EnController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MyProjects_EnController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Admin/MyProjects_En
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyProjects_En.ToListAsync());
        }

        // GET: Admin/MyProjects_En/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProjects_En = await _context.MyProjects_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProjects_En == null)
            {
                return NotFound();
            }

            return View(myProjects_En);
        }

        // GET: Admin/MyProjects_En/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MyProjects_En/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BuiltBy,Description,Github_Url,Live_Url,ImageFile")] MyProjects_En myProjects_En)
        {
            if (ModelState.IsValid)
            {
                //save image to wwwroot/Images/MyProjectsEn
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(myProjects_En.ImageFile.FileName);
                string extension = Path.GetExtension(myProjects_En.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                myProjects_En.ImageName = fileName;
                string path = Path.Combine(wwwRootPath + "/Images/MyProjectsEn/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await myProjects_En.ImageFile.CopyToAsync(fileStream);
                }


                //insert record
                _context.Add(myProjects_En);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myProjects_En);
        }

        // GET: Admin/MyProjects_En/Edit/5
        [HttpGet]

        public async Task<IActionResult> Edit(int? id)

        {

            if (id == null)

            {
                return NotFound();
            }

            MyProjects_En myProjects_En2 = await _context.MyProjects_En.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (myProjects_En2 == null)

            {
                return NotFound();
            }



            return View(myProjects_En2);

        }


        // POST: Admin/MyProjects_En/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, MyProjects_En myProjects_En, IFormFile file)
        {
            if (id == null)

            {

                return NotFound();

            }



            MyProjects_En myProjects_En2 = await _context.MyProjects_En.Where(x => x.Id == id).FirstOrDefaultAsync();



            if (myProjects_En2 == null)

            {

                return NotFound();

            }





            if (file != null || file.Length != 0)

            {



                string filename = System.Guid.NewGuid().ToString() + ".jpg";

                var path = Path.Combine(

                            Directory.GetCurrentDirectory(), "wwwroot", "Images/MyProjectsEn", filename);



                using (var stream = new FileStream(path, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                myProjects_En2.ImageName = filename;

            }








            myProjects_En2.Name = myProjects_En.Name;

            myProjects_En2.Description = myProjects_En.Description;

            myProjects_En2.BuiltBy = myProjects_En.BuiltBy;

            myProjects_En2.Github_Url = myProjects_En.Github_Url;

            myProjects_En2.Live_Url = myProjects_En.Live_Url;








            await _context.SaveChangesAsync();

            return RedirectToAction("Index");





        }

        // GET: Admin/MyProjects_En/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myProjects_En = await _context.MyProjects_En
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myProjects_En == null)
            {
                return NotFound();
            }

            return View(myProjects_En);
        }

        // POST: Admin/MyProjects_En/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myProjects_En = await _context.MyProjects_En.FindAsync(id);

            //delete image from wwwroot/Images/MyProjects
            var imagePath = Path.Combine(_hostEnvironment.WebRootPath, "Images/MyProjectsEn", myProjects_En.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            //delete the record
            _context.MyProjects_En.Remove(myProjects_En);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyProjects_EnExists(int id)
        {
            return _context.MyProjects_En.Any(e => e.Id == id);
        }
    }
}
