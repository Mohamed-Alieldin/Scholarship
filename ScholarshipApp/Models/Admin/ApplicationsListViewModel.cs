using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Models.Admin
{
    public class ApplicationsListViewModel
    {
        public List<ApplicationEntry> Applications { get; set; }
    }

    public class ApplicationEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string University { get; set; }
        public string Major { get; set; }
        public float GPA { get; set; }
        public string  ResumeFileName { get; set; }

        public int? IsAccepted { get; set; }
    }
}