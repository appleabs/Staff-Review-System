using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace StaffReview.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StaffReviewContext(
                serviceProvider.GetRequiredService<DbContextOptions<StaffReviewContext>>()))
            {
                // Look for any movies.
                if (context.Staff.Any())
                {
                    return;   // DB has been seeded
                }

                context.Staff.AddRange(
                     new Staff

                     {
                         FirstName = "John",
                         JobTitle = "Marketing manager",
                         LastName = "Smith",
                         Rating = 5,
                         Review = "Works hard!" 
                     },

                     new Staff

                     {
                         FirstName = "Anna",
                         JobTitle = "HR intern",
                         LastName = "Johnson",                        
                         Rating = 4,
                         Review ="Tries hard but needs more commitment."
                     },
                       
                     new Staff

                       {
                           FirstName = "Adam",
                           JobTitle = "Coal Miner",
                           LastName = "Jacobs",
                           Rating = 7,
                           Review = "Excellent skills!"
                       }

                ); 
                context.SaveChanges();
            }
        }
    }
}