using Microsoft.CodeAnalysis;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EFSamples.Models
{
    #region OneToOne
    public class PropertyUnit
    {
        public int Id { get; set; }
        public string UnitNumber { get; set; }
        public string DisplayName { get; set; }
        public Address Address { get; set; }

    }

    public class Address
    {
        #region Public Properties

        public int Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }

        public int AddressOfPropertyUnitId { get; set; }
        public PropertyUnit PropertyUnit { get; set; }

        #endregion Public Properties
    }
    #endregion

    #region OneToMany
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<EmployeesInProject> EmployeesInProject { get; set; }

    }
    #endregion

    #region ManyToMany
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeesInProject> EmployeesInProject { get; set; }
    }
    public class EmployeesInProject
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime AssignedOn { get; set; }

    }
    #endregion

}
