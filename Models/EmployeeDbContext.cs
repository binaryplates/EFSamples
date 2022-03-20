using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSamples.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<PropertyUnit> PropertyUnits { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeesInProject> EmployeesInProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region OneToOne
            modelBuilder.Entity<PropertyUnit>()
                .HasOne(propertyUnit => propertyUnit.Address)
                .WithOne(address => address.PropertyUnit)
                .HasForeignKey<Address>(pu => pu.AddressOfPropertyUnitId)
                .IsRequired();
            #endregion

            #region ManyToMany
            modelBuilder.Entity<EmployeesInProject>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeesInProject>()
                .HasOne(employeesInProject => employeesInProject.Employee)
                .WithMany(employee => employee.EmployeesInProject)
                .HasForeignKey(employeesInProject => employeesInProject.EmployeeId);

            modelBuilder.Entity<EmployeesInProject>()
                .HasOne(employeesInProject => employeesInProject.Project)
                .WithMany(project => project.EmployeesInProject)
                .HasForeignKey(employeesInProject => employeesInProject.ProjectId);
            #endregion


            //modelBuilder.Entity<Employee>()
            //    .HasOne(c => c.Company)
            //    .WithMany(e=>e.Employees)
            //    .IsRequired(false) 
            //    ;


        }
    }
}
