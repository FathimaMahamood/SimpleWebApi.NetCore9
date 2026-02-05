using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Data;
using SimpleWebApi.Repository;
using SimpleWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



// To obtain post data on next get
builder.Services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

// For DB query
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApiDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DfaultConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
