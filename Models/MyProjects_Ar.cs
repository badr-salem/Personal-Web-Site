﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BadrBinHomeed_NEW.Models
{
    public class MyProjects_Ar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string BuiltBy { get; set; }
        public string Description { get; set; }
        public string Github_Url { get; set; }
        public string Live_Url { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string ImageName { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }


    }
}
