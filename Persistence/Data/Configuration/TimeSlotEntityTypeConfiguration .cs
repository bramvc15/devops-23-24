using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Persistence.Data.Configuration
{
    public class TimeSlotEntityTypeConfiguration : IEntityTypeConfiguration<TimeSlot>
    {
        public void Configure(EntityTypeBuilder<TimeSlot> builder)
        {
            builder.HasOne(t => t.Appointment)
                .WithOne(a => a.TimeSlot)
                .HasForeignKey<Appointment>(a => a.Id)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}