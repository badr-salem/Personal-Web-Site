using System;
using System.Collections.Generic;
using System.Text;
using BadrBinHomeed_NEW.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BadrBinHomeed_NEW.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyProjects_Ar> MyProjects_Ar { get; set; }
        public DbSet<MyProjects_En> MyProjects_En { get; set; }
        public DbSet<Experience_Ar> Experience_Ar { get; set; }
        public DbSet<Experience_En> Experience_En { get; set; }
        public DbSet<Programming_Skills_Ar> Programming_Skills_Ar { get; set; }
        public DbSet<Programming_Skills_En> Programming_Skills_En { get; set; }
        public DbSet<General_Skills_Ar> General_Skills_Ar { get; set; }
        public DbSet<General_Skills_En> General_Skills_En { get; set; }
        public DbSet<Current_Work_Ar> Current_Work_Ar { get; set; }
        public DbSet<Current_Work_En> Current_Work_En { get; set; }
        public DbSet<Education_Ar> Education_Ar { get; set; }
        public DbSet<Education_En> Education_En { get; set; }
        public DbSet<Social_Media> Social_Media { get; set; }
        public DbSet<Personal_Info_Ar> Personal_Info_Ar { get; set; }
        public DbSet<Personal_Info_En> Personal_Info_En { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
