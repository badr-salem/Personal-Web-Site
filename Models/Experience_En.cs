using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BadrBinHomeed_NEW.Models
{
    public class Experience_En
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Company_Name { get; set; }

        [Required]
        public string Role_Name { get; set; }

        public string Description { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
