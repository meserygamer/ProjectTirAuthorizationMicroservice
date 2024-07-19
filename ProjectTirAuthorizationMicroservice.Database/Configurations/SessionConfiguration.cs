using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ProjectTirAuthorizationMicroservice.Database.Entities;

namespace ProjectTirAuthorizationMicroservice.Database.Configurations
{
    internal class SessionConfiguration : IEntityTypeConfiguration<SessionEntity>
    {
        public void Configure(EntityTypeBuilder<SessionEntity> builder)
        {
            builder.ToTable("Sessions")
                .HasKey(x => x.Id);

            builder.Property(u => u.UserId)
                .IsRequired();

            builder.Property(u => u.StartDate)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithMany(u => u.OpenSessions)
                .HasForeignKey(s => s.UserId);
        }
    }
}
