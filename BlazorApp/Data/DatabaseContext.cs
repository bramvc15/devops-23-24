using BlazorApp.Models;
using BlazorApp.Pages;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DatabaseContext : DbContext{

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors => Set<Doctor>();

        public DbSet<HomeHeader> HomeHeaders => Set<HomeHeader>();

        public DbSet<Blog> Blogs => Set<Blog>();


        public DbSet<LocationM> Locations => Set<LocationM>();

        public DbSet<ContactM> Contacts => Set<ContactM>();
        public DbSet<ChatBotQuestion> ChatBotQuestions => Set<ChatBotQuestion>();
    }
}
