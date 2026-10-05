using System.Text.Json.Serialization;
using StudentAPI.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
string? ConnectionStringMySQL = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<StudentAPI.Context.AppDbContext>(options =>
    options.UseMySql(
        ConnectionStringMySQL,
        ServerVersion.AutoDetect(ConnectionStringMySQL)
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.DocumentTitle = "Student API";
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
