using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DatabaseContext : DbContext{

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors => Set<Doctor>();

        public DbSet<HomeHeader> HomeHeaders => Set<HomeHeader>();

        

    }
}
