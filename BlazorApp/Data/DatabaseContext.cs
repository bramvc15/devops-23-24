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
            // ignore Ref_Id in Doctor (don't persist)
            modelBuilder.Entity<Doctor>().Ignore(d => d.Ref_Id);

            // ignore Ref_Id in Patient (don't persist)
            modelBuilder.Entity<Patient>().Ignore(p => p.Ref_Id);

            // relation Patient One-To-Many Appointment
            modelBuilder.Entity<Appointment>()
                .Property<int>("Ref_Id")
                .HasColumnName("Patient_Id");

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.Ref_Id)
                .HasConstraintName("FK_Appointment_Patient");

            // relation Doctor One-To-Many TimeSlot
            modelBuilder.Entity<TimeSlot>()
                .Property<int>("Ref_Id")
                .HasColumnName("Doctor_Id");

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.TimeSlots)
                .WithOne()
                .HasForeignKey(d => d.Ref_Id)
                .HasConstraintName("FK_Doctor_TimeSlot");

            // relation TimeSlot One-To-One Appointment
            modelBuilder.Entity<Appointment>()
                .Property<int>("Id")
                .HasColumnName("TimeSlot_Id");

            modelBuilder.Entity<TimeSlot>()
                .HasOne(t => t.Appointment)
                .WithOne(a => a.TimeSlot)
                .HasForeignKey<Appointment>(t => t.Id)
                .IsRequired(false);

            // relation Doctor One-To-Many ScheduleTimeSlot
            modelBuilder.Entity<ScheduleTimeSlot>()
                .Property<int>("Ref_Id")
                .HasColumnName("Doctor_Id");

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.ScheduleTimeSlots)
                .WithOne()
                .HasForeignKey(d => d.Ref_Id)
                .HasConstraintName("FK_Doctor_ScheduleTimeSlot");
        }
    }
}