using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasMany(d => d.ScheduleTimeSlots)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.TimeSlots)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
