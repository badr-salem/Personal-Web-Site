using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BadrBinHomeed_NEW.Models
{
    public class Social_Media
    {
        [Key]
        public int Id { get; set; }

        
        public string Github_Url { get; set; }
        public string Insta_Url { get; set; }
        public string Linkedin_Url { get; set; }
        public string Twitter_Url { get; set; }
        public string CV_Url { get; set; }
    }
}
