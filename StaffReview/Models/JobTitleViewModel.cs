using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace StaffReview.Models
{
    public class JobTitleViewModel
    {
        public List<Staff> staffs;
        public SelectList JobTitles;
        public string JobTitle { get; set; }
    }
}