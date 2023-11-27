using Domain;
using Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        // Domain Tables
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<TimeSlot> TimeSlots => Set<TimeSlot>();
        public DbSet<ScheduleTimeSlot> ScheduleTimeSlots => Set<ScheduleTimeSlot>();

        // CMS Tables
        public DbSet<CMSBlog> Blogs => Set<CMSBlog>();
        public DbSet<CMSChatBotQuestion> ChatBotQuestions => Set<CMSChatBotQuestion>();
        public DbSet<CMSContact> Contacts => Set<CMSContact>();
        public DbSet<CMSHomeHeader> HomeHeaders => Set<CMSHomeHeader>();
        public DbSet<CMSLocation> Locations => Set<CMSLocation>();
        public DbSet<CMSTreatment> Treatments => Set<CMSTreatment>();

        // ModelChanges on persist
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<CMSBlog>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CMSChatBotQuestion>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CMSContact>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CMSHomeHeader>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CMSLocation>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<CMSTreatment>()
                .HasKey(e => e.Id);

            /*
             modelBuilder.Entity<ScheduleTimeSlot>()
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(scheduleSlot => scheduleSlot.NameDoctor);

            modelBuilder.Entity<TimeSlot>()
                .HasOne<Doctor>()
                .WithMany()
                .HasForeignKey(timeSlot => timeSlot.NameDoctor);

            modelBuilder.Entity<Appointment>()
                .HasOne<TimeSlot>()
                .WithMany()
                .HasForeignKey(a => a.DateTime);
            */
        }
    }
}