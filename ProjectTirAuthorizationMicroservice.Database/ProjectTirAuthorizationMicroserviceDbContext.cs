using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectTirAuthorizationMicroservice.Database.Entities;

namespace ProjectTirAuthorizationMicroservice.Database
{
    public class ProjectTirAuthorizationMicroserviceDbContext : DbContext
    {
        public ProjectTirAuthorizationMicroserviceDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private readonly IConfiguration _configuration;


        public DbSet<UserEntity> Users { get; set; }
        public DbSet<SessionEntity> Sessions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PostgreDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProjectTirAuthorizationMicroserviceDbContext).Assembly);
        }
    }
}
