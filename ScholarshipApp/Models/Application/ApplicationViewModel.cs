using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScholarshipApp.Models.Application
{
    public class ApplicationViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birthdate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "National Id")]
        public Int64 NationalId { get; set; }

        [Required]
        [Display(Name = "University")]
        public string University { get; set; }

        [Required]
        [Display(Name = "Major")]
        public string Major { get; set; }

        [Required]
        [Display(Name = "GPA")]
        public float GPA { get; set; }


        //[Required]
        //[FileExtensions(Extensions = "pdf", ErrorMessage = "Only files with pdf extensions are allowed.")]
        public HttpPostedFileBase Resume { get; set; }
    }
}