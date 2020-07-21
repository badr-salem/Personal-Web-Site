using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BadrBinHomeed_NEW.Models;
using BadrBinHomeed_NEW.Models.ViewModels;
using BadrBinHomeed_NEW.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace BadrBinHomeed_NEW.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var IndexVM = new IndexVM
            {
                Programming_Skills_Ar = await _context.Programming_Skills_Ar.ToListAsync(),
                General_Skills_Ar = await _context.General_Skills_Ar.ToListAsync(),
                MyProjects_Ar = await _context.MyProjects_Ar.ToListAsync(),
                Experience_Ar = await _context.Experience_Ar.ToListAsync(),
                Current_Work_Ar = await _context.Current_Work_Ar.ToListAsync(),
                Education_Ar = await _context.Education_Ar.ToListAsync(),
                Personal_Info_Ar = await _context.Personal_Info_Ar.ToListAsync(),
                Social_Media = await _context.Social_Media.ToListAsync(),
               

            };
            return View(IndexVM);
        }

        public async Task<IActionResult> IndexEn()
        {
            var IndexVM = new IndexVM
            {
                Programming_Skills_En = await _context.Programming_Skills_En.ToListAsync(),
                General_Skills_En = await _context.General_Skills_En.ToListAsync(),
                MyProjects_En = await _context.MyProjects_En.ToListAsync(),
                Experience_En = await _context.Experience_En.ToListAsync(),
                Current_Work_En = await _context.Current_Work_En.ToListAsync(),
                Education_En = await _context.Education_En.ToListAsync(),
                Personal_Info_En = await _context.Personal_Info_En.ToListAsync(),
                Social_Media = await _context.Social_Media.ToListAsync(),


            };
            return View(IndexVM);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IndexVM IndexVM2)
        {
            
            if (!ModelState.IsValid) return View("Index");

            try
            {
                
                MailMessage mail = new MailMessage();
                // you need to enter your mail address
                mail.From = new MailAddress("Your_Sender_Email@gmail.com");

                //To Email Address - your need to enter your to email address
                mail.To.Add("Your_Receiver_Email@gmail.com");

                mail.Subject = IndexVM2.Subject;



                mail.IsBodyHtml = true;

                string content = "Name : " + IndexVM2.Name;
                content += "<br/> Email : " + IndexVM2.Email;
                content += "<br/> Phone Number : " + IndexVM2.PhoneNumber;
                content += "<br/> Subject : " + IndexVM2.Subject;
                content += "<br/> Message : " + IndexVM2.Message;

                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("Your_Sender_Email@gmail.com", "Pass Of Sender Email");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; // this is default port number - you can also change this
                smtpClient.EnableSsl = true; // if ssl required you need to enable it
                smtpClient.Send(mail);



                // now i need to create the from 
                ModelState.Clear();

               

            }
            catch (Exception ex)
            {
               
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> IndexEn(IndexVM IndexVM2)
        {

            if (!ModelState.IsValid) return View("IndexEn");

            try
            {

                MailMessage mail = new MailMessage();
                // you need to enter the sender  mail address
                mail.From = new MailAddress("Your_Sender_Email@gmail.com");

                //To Email Address - your need to enter your Receiver email address
                mail.To.Add("Your_Receiver_Email@gmail.com");

                mail.Subject = IndexVM2.Subject;



                mail.IsBodyHtml = true;

                string content = "Name : " + IndexVM2.Name;
                content += "<br/> Email : " + IndexVM2.Email;
                content += "<br/> Phone Number : " + IndexVM2.PhoneNumber;
                content += "<br/> Subject : " + IndexVM2.Subject;
                content += "<br/> Message : " + IndexVM2.Message;

                mail.Body = content;


                //create SMTP instant

                //you need to pass mail server address and you can also specify the port number if you required
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                //Create nerwork credential and you need to give from email address and password
                NetworkCredential networkCredential = new NetworkCredential("Your_Sender_Email@gmail.com", "Pass Of Sender Email");
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = networkCredential;
                smtpClient.Port = 587; // this is default port number - you can also change this
                smtpClient.EnableSsl = true; // if ssl required you need to enable it
                smtpClient.Send(mail);

                


                // now i need to create the from 
                ModelState.Clear();



            }
            catch (Exception ex)
            {
               
            }
            return RedirectToAction(nameof(IndexEn));
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
