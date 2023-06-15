﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {  
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name is mandatory")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is mandatory")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        //public Department Department { get; set; }        //public Department Department { get; set; }
        public string PhotoPath { get; set; }
    }
}
