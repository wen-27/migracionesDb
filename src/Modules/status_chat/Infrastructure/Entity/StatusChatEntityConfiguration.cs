using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerTransporte.Modules.StatusChat.Infrastructure.Entity;

public sealed class StatusChatEntityConfiguration : IEntityTypeConfiguration<StatusChatEntity>
{
    public void Configure(EntityTypeBuilder<StatusChatEntity> builder)
    {
        builder.ToTable("status_chat");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.Description).HasMaxLength(255);

        builder.HasIndex(x => x.Name).IsUnique();
    }
}