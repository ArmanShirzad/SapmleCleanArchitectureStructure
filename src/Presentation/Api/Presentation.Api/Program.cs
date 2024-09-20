using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Core.Application.Extentions;
using Infrastructure.Persistence.Extentions;
using Presentation.Api.Extentions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllers(options =>
{
    options.AddDefaultResultConvention();
        //.AddResultConvention(resultStatusMap => resultStatusMap
        //.AddDefaultMap()
        //.For(ResultStatus.Ok, HttpStatusCode.OK)
        //.For(ResultStatus.NotFound, HttpStatusCode.NotFound));
});
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationApiServices();

//
var app = builder.Build();
//

// request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.DocumentTitle = "Sample Clean Architecture";
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    });


}
app.MapControllers();
app.UseLogMiddleware();
app.UseExceptionHandlerMiddleware();

app.Run();
