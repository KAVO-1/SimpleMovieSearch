using Microsoft.EntityFrameworkCore;
using SimpleMovieSearch.Domain.Entity;

namespace SimpleMovieSearch.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            //Database.EnsureCreated(); //Add database
        } 

        public DbSet<Movie> Movie { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
