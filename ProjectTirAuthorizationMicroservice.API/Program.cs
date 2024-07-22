using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using ProjectTirAuthorizationMicroservice.API.Contracts.Registration;
using ProjectTirAuthorizationMicroservice.API.SwaggerSchemas;
using ProjectTirAuthorizationMicroservice.Database;

namespace ProjectTirAuthorizationMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "APIDoc.xml");
                options.IncludeXmlComments(xmlPath);

                options.MapType<RegisterUserRequest>(new RegisterRequestSchemaFactory().CreateSchema);
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
