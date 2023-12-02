using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AppointmentEntityTypeConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.Property<int>("Id")
                .HasColumnName("TimeSlot_Id");

            builder.HasOne(a => a.Patient)
                .WithMany(p => p.Appointments);
        }
    } 
}
