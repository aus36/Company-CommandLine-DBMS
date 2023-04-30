//Table for PersonType, which contains 3 different types of people: PreHire, Employee, and Retiree
using System.ComponentModel.DataAnnotations;

namespace CSCI428_SQLProject.Models
{
    public class PersonType
    {
        [Key]
        public string PType { get; set; } = null!;
    }
}