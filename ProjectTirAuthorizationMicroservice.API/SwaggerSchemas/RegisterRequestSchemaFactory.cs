using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace ProjectTirAuthorizationMicroservice.API.SwaggerSchemas
{
    public class RegisterRequestSchemaFactory : ISwaggerSchemaFactory
    {
        public OpenApiSchema CreateSchema()
        {
            return new OpenApiSchema
            {
                Example = new OpenApiObject()
                {
                    ["login"] = new OpenApiString("login"),
                    ["password"] = new OpenApiString("password"),
                    ["userName"] = new OpenApiString("userName"),
                    ["userSurname"] = new OpenApiString("userSurname"),
                    ["userPatronymic"] = new OpenApiString("userPatronymic"),
                    ["userEmail"] = new OpenApiString("email@gmail.com"),
                    ["userPhone"] = new OpenApiString("+78005553535"),
                    ["userBirthdayDate"] = new OpenApiString("01-01-2000")
                }
            };
        }
    }
}
