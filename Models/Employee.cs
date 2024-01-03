using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }


    }
}