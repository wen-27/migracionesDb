using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.AssignmentRole.Infrastructure.Entity;

public sealed class AssignmentRoleEntityConfiguration : IEntityTypeConfiguration<AssignmentRoleEntity>
{
    public void Configure(EntityTypeBuilder<AssignmentRoleEntity> builder)
    {
        builder.ToTable("assignment_role");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}