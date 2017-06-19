using System.ComponentModel.DataAnnotations;

namespace StaffReview.Models
{
    public class Staff
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public decimal Rating { get; set; }
        public string Review { get; set; }
    }
}