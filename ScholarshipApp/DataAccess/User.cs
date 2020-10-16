using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ScholarshipApp.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("users");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Email).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.Role).IsRequired();
        }

    }
}