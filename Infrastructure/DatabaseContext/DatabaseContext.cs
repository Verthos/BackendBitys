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


        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
