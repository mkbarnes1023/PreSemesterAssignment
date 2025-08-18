using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreSemesterAssignment.Models;

namespace PreSemesterAssignment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<VolunteerModel> Volunteers { get; set; }
        public DbSet<OpportunityModel> Opportunities { get; set; }
        // If you have an Administrator model, add it here:
        public DbSet<AdministratorModel> Administrators { get; set; }
        public DbSet<VolunteerMatchesModel> VolunteerMatches { get; set; }
    }
}