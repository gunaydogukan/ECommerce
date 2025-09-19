using ECommerce.Core.Exceptions;
using ECommerce.Core.Extensions;
using ECommerce.DataAccess;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Service Registrations
builder.Services.AddProjectServices(builder.Configuration);
//builder.Services.AddDataAccess(builder.Configuration);

builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000") // Next.js frontend adresi
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();


// JWT Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.MapScalarApiReference(options =>
{
    options.Title = "ECommerce API";
    options.EndpointPathPrefix = "scalar";
    options.OpenApiRoutePattern = "swagger/v1/swagger.json";
});

app.Run();