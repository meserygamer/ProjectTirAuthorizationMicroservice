using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ProjectTirAuthorizationMicroservice.API.Contracts.Registration;
using ProjectTirAuthorizationMicroservice.Application.Interfaces;
using ProjectTirAuthorizationMicroservice.Application.Services;
using ProjectTirAuthorizationMicroservice.Core.RepositoryInterfaces;
using ProjectTirAuthorizationMicroservice.Database;
using ProjectTirAuthorizationMicroservice.Database.Repositories;
using ProjectTirAuthorizationMicroservice.Infrastructure.HashService;
using ProjectTirAuthorizationMicroservice.Infrastructure.RedisCacheService;

namespace ProjectTirAuthorizationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<UserService>();
            builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
            builder.Services.AddSingleton<IDataCacheService, RedisCacheService>();
            builder.Services.AddTransient<IUserRepository, UserRepositoryPgSQL>();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "APIDoc.xml");
                options.IncludeXmlComments(xmlPath);

                options.MapType<DateOnly>(() => new OpenApiSchema
                {
                    Type = "string",
                    Format = "date"
                });
            });

            builder.Services.AddDbContext<ProjectTirAuthorizationMicroserviceDbContext>(options => { });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
