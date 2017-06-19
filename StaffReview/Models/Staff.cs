using System;

namespace StaffReview.Models
{
    public class Staff
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
    }
}