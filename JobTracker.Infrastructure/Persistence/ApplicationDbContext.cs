using JobTracker.Domain.Entities;
using JobTracker.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>()
                .HasMany(c => c.Jobs)
                .WithOne(j => j.Company)
                .HasForeignKey(j => j.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Job>()
                .Property(j => j.SalaryMin)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Job>()
                .Property(j => j.SalaryMax)
                .HasColumnType("decimal(18,2)");

            // Indexes for faster lookups
            builder.Entity<Company>()
                .HasIndex(c => c.Name);
        }
    }
}
