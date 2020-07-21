using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BadrBinHomeed_NEW.Models
{
    public class Personal_Info_En
    {
        [Key]
        public int Id { get; set; }

        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string Residence { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
