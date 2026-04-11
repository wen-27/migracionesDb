using DerTransporte.Modules.AssignmentRole.Infrastructure.Entity;
using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.TripAssignments.Infrastructure.Entity;

public class TripAssignmentsEntityConfiguration : IEntityTypeConfiguration<TripAssignmentsEntity>
{
    public void Configure(EntityTypeBuilder<TripAssignmentsEntity> builder)
    {
        builder.ToTable("trip_assignments");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired();

        builder.Property(x => x.personid)
            .HasColumnName("person_id")
            .IsRequired();

        builder.Property(x => x.assignmentroleid)
            .HasColumnName("assignment_role_id")
            .IsRequired();

        builder.Property(x => x.isactive)
            .HasColumnName("is_active")
            .IsRequired();

        builder.Property(x => x.assignedat)
            .HasColumnName("assigned_at")
            .IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Person)
            .WithMany()
            .HasForeignKey(x => x.personid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AssignmentRole)
            .WithMany()
            .HasForeignKey(x => x.assignmentroleid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}