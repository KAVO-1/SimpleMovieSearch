using Microsoft.EntityFrameworkCore;
using SimpleMovieSearch.Domain.Entity;

namespace SimpleMovieSearch.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        } 

        public DbSet<Movie> Movie { get; set; }


    }
}
