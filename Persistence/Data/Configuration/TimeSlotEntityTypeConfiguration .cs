using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class TimeSlotEntityTypeConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            builder.HasOne(t => t.Appointment)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
