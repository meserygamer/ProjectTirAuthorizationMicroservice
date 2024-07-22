using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectTirAuthorizationMicroservice.Database.Entities;


namespace ProjectTirAuthorizationMicroservice.Database.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users")
                .HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.HasIndex(u => u.Login)
                .IsUnique();

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsRequired();

            builder.Property(u => u.Surname)
                .IsRequired();

            builder.HasMany(u => u.OpenSessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
