global using WebApi_AP.Data;
global using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var confstring = new ConfigurationBuilder().SetBasePath(builder.Environment.ContentRootPath).AddJsonFile("dbsettings.json").Build();

builder.Services.AddDbContext<PersonalAccDbContext>(options =>
{
    options.UseSqlServer(confstring.GetConnectionString("DefaultConnection"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
