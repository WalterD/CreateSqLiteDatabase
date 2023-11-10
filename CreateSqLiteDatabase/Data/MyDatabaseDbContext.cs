using CreateSqLiteDatabase.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CreateSqLiteDatabase.Data
{
    public class MyDatabaseDbContext : DbContext
    {
        public MyDatabaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
