using Microsoft.EntityFrameworkCore;
using InitiativesTracker.Models;

namespace InitiativesTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<idealist> Ideatable {  get; set; }

        public DbSet<Comments>CommentsTable { get; set; }
    }
}
