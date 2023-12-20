using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data.Configuration;

namespace Persistence.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        // Domain Tables
        public DbSet<Doctor> Doctors {  get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<ScheduleTimeSlot> ScheduleTimeSlots { get; set; }
        public DbSet<Message> Messages { get; set; }

        // CMS Tables
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ChatBotQuestion> ChatBotQuestions { get; set; }
        public DbSet<HomeHeader> HomeHeaders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Note> Notes { get; set; }
        

        // ModelChanges on persist
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DoctorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSlotEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentEntityTypeConfiguration());
        }
    }
}