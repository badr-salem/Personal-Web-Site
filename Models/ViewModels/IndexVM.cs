using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BadrBinHomeed_NEW.Models.ViewModels
{
    public class IndexVM
    {
        public List<Programming_Skills_Ar> Programming_Skills_Ar { get; set; }
        public List<Programming_Skills_En> Programming_Skills_En { get; set; }
        public List<General_Skills_Ar> General_Skills_Ar { get; set; }
        public List<General_Skills_En> General_Skills_En { get; set; }
        public List<MyProjects_Ar> MyProjects_Ar { get; set; }
        public List<MyProjects_En> MyProjects_En { get; set; }
        public List<Experience_Ar> Experience_Ar { get; set; }
        public List<Experience_En> Experience_En { get; set; }
        public List<Current_Work_Ar> Current_Work_Ar { get; set; }
        public List<Current_Work_En> Current_Work_En { get; set; }
        public List<Education_Ar> Education_Ar { get; set; }
        public List<Education_En> Education_En { get; set; }
        public List<Personal_Info_Ar> Personal_Info_Ar { get; set; }
        public List<Personal_Info_En> Personal_Info_En { get; set; }
        public List<Social_Media> Social_Media { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }


    }
}
