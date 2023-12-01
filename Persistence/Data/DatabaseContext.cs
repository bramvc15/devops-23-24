using Domain;
using Shared;
using Microsoft.EntityFrameworkCore;

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

        // CMS Tables
        public DbSet<CMSBlog> Blogs { get; set; }
        public DbSet<CMSChatBotQuestion> ChatBotQuestions { get; set; }
        public DbSet<CMSContact> Contacts { get; set; }
        public DbSet<CMSHomeHeader> HomeHeaders { get; set; }
        public DbSet<CMSLocation> Locations { get; set; }
        public DbSet<CMSTreatment> Treatments { get; set; }

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
                .HasConstraintName("FK_Doctor_TimeSlot")
                .OnDelete(DeleteBehavior.Cascade);

            // relation TimeSlot One-To-One Appointment
            modelBuilder.Entity<Appointment>()
                .Property<int>("Id")
                .HasColumnName("TimeSlot_Id");

            modelBuilder.Entity<TimeSlot>()
                .HasOne(t => t.Appointment)
                .WithOne(a => a.TimeSlot)
                .HasForeignKey<Appointment>(t => t.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // relation Doctor One-To-Many ScheduleTimeSlot
            modelBuilder.Entity<ScheduleTimeSlot>()
                .Property<int>("Ref_Id")
                .HasColumnName("Doctor_Id");

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.ScheduleTimeSlots)
                .WithOne()
                .HasForeignKey(d => d.Ref_Id)
                .HasConstraintName("FK_Doctor_ScheduleTimeSlot")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}