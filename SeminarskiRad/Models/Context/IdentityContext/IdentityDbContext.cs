using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SeminarskiRad.Models.IdentityModels;

namespace SeminarskiRad.Models.Context
{
    public class IdentityDbContext: IdentityDbContext<SeminarEmployee, SeminarRole, int, SeminarLogin, SeminarEmployeeRole, SeminarClaim>
    {
        public IdentityDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<IdentityDbContext>(null);
        }

        public static IdentityDbContext Create()
        {
            return new IdentityDbContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SeminarEmployee>().ToTable("Employee");
            modelBuilder.Entity<SeminarRole>().ToTable("Role");
            modelBuilder.Entity<SeminarClaim>().ToTable("Claim");
            modelBuilder.Entity<SeminarLogin>().ToTable("EmployeeLogin");
            modelBuilder.Entity<SeminarEmployeeRole>().ToTable("EmployeeRole");

            modelBuilder.Entity<SeminarEmployee>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SeminarClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<SeminarRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}