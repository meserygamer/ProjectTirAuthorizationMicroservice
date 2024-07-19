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

            builder.Property(u => u.Login)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.Property(u => u.UserName)
                .IsRequired();

            builder.Property(u => u.UserSurname)
                .IsRequired();

            builder.HasMany(u => u.OpenSessions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
