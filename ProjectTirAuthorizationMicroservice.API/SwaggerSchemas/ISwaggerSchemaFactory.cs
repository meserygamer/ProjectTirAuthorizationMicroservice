using Microsoft.OpenApi.Models;

namespace ProjectTirAuthorizationMicroservice.API.SwaggerSchemas
{
    public interface ISwaggerSchemaFactory
    {
        OpenApiSchema CreateSchema();
    }
}
