using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSCI428_SQLProject.Models
{
    public class Person
    {
        //Properties
        public int ID { get; set; }

        public PersonType Type { get; set; } = null!;

        public string WorkerType { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime EmploymentDate { get; set; }
    }
}

