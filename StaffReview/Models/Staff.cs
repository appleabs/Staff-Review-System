using System.ComponentModel.DataAnnotations;

namespace StaffReview.Models
{
    public class Staff
    {
        public int ID { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Job Title")]
        [Required]
        public string JobTitle { get; set; }

        [Range(0, 10)]
        public decimal Rating { get; set; }

        [Required]
        public string Review { get; set; }
    }
}