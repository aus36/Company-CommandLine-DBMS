using System;
using System.ComponentModel.DataAnnotations;

namespace CSCI428_SQLProject.Models
{
    public class Employee
    {
        //Properties
        [Key]
        public int ID { get; set; }

        public string? JobTitle { get; set; }

        public float MonthlySalary { get; set; }

        public Person Person { get; set; } = null!;
    }
}