using DerTransporte.Modules.Persons.Infrastructure.Entity;
using DerTransporte.Modules.Trips.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.Ratings.Infrastructure.Entity;

public class RatingsEntityConfiguration : IEntityTypeConfiguration<RatingsEntity>
{
    public void Configure(EntityTypeBuilder<RatingsEntity> builder)
    {
        builder.ToTable("ratings");

        builder.HasKey(x => x.id);

        builder.Property(x => x.id)
            .HasColumnName("id");

        builder.Property(x => x.tripid)
            .HasColumnName("trip_id")
            .IsRequired();

        builder.Property(x => x.evaluatorid)
            .HasColumnName("evaluator_id")
            .IsRequired();

        builder.Property(x => x.evaluatedid)
            .HasColumnName("evaluated_id")
            .IsRequired();

        builder.Property(x => x.score)
            .HasColumnName("score")
            .IsRequired();

        builder.Property(x => x.comment)
            .HasColumnName("comment")
            .HasColumnType("TEXT")
            .IsRequired();

        builder.Property(x => x.createdat)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany()
            .HasForeignKey(x => x.tripid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Evaluator)
            .WithMany()
            .HasForeignKey(x => x.evaluatorid)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Evaluated)
            .WithMany()
            .HasForeignKey(x => x.evaluatedid)
            .OnDelete(DeleteBehavior.Restrict);
    }
}