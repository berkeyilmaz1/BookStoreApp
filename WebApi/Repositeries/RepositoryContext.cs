using Entities.Models;
using Microsoft.EntityFrameworkCore;
 
using WebApi.Repositeries.Config;

namespace WebApi.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
        public DbSet<Book> Books { get; set; }  
    }
}
