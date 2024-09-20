using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Presentation.Api.common
{
    public class AddFileParamTypes : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var fileUploadMime = "multipart/form-data";
            if (operation.RequestBody !=  null)
            {

            foreach (var request in operation.RequestBody?.Content)
            {
                if (request.Key.Equals(fileUploadMime, StringComparison.InvariantCultureIgnoreCase))
                {
                    operation.RequestBody.Content[fileUploadMime] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties =
                        {
                            ["image"] = new OpenApiSchema
                            {
                                Type = "string",
                                Format = "binary"
                            }
                        },
                            Required = new HashSet<string> { "image" }
                        }
                    };
                }
            }
            }
        }
    }
}
