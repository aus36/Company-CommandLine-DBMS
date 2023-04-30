//Table for Retiree, which contains the RetirementDate, and PersonID
using System.ComponentModel.DataAnnotations;

namespace CSCI428_SQLProject.Models
{
    public class Retiree
    {
        //Properties
        [Key]
        public int ID { get; set; }

        public string? RetirementProgram { get; set; }

        public DateTime RetirementDate { get; set; }

        public Person Person { get; set; } = null!;
    }
}

