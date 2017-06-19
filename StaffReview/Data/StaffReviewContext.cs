using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StaffReview.Models
{
    public class StaffReviewContext : DbContext
    {
        public StaffReviewContext (DbContextOptions<StaffReviewContext> options)
            : base(options)
        {
        }

        public DbSet<StaffReview.Models.Staff> Staff { get; set; }
    }
}
