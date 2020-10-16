using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ScholarshipApp.DataAccess
{
    public class Application
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public Int64 NationalId { get; set; }
        public string University { get; set; }
        public string Major { get; set; }
        public float GPA { get; set; }
        public string  ResumeFileName { get; set; }
        public int?  IsAccepted { get; set; }
    }

    public class ApplicationMap : EntityTypeConfiguration<Application>
    {
        public ApplicationMap()
        {
            ToTable("applications");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.UserId).IsRequired();
            Property(p => p.FirstName).IsRequired();
            Property(p => p.LastName).IsRequired();
            Property(p => p.BirthDate).IsRequired();
            Property(p => p.NationalId).IsRequired();
            Property(p => p.University).IsRequired();
            Property(p => p.Major).IsRequired();
            Property(p => p.GPA).IsRequired();
            Property(p => p.ResumeFileName).IsRequired();
            Property(p => p.IsAccepted).IsOptional();
        }
    }
}