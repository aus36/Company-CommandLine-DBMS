using System;
using System.ComponentModel.DataAnnotations;

namespace CSCI428_SQLProject.Models
{
    public class PersonType
    {
        [Key]
        public string PType { get; set; } = null!;
    }
}