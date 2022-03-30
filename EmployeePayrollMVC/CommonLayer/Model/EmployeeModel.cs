using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Model
{
  public class EmployeeModel
    {// <input asp-for="profileImage" class="form-control" /> <input asp-for="Gender" class="form-control" />
        public int  EmployeeId { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string profileImage { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string notes { get; set; }
    }
}
