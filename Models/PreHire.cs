using System;
using System.ComponentModel.DataAnnotations;

namespace CSCI428_SQLProject.Models
{
    public class PreHire
    {
        //Properties
        [Key]
        public int ID { get; set; }

        public DateTime OfferExtendedDate { get; set; }
        
        public DateTime OfferAcceptedDate { get; set; }

        public Person Person { get; set; } = null!;
    }
}

