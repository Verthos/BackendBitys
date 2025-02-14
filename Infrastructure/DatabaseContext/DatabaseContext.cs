using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DatabaseContext
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
