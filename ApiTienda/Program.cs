using Infraestruture.Data;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using API.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddControllers();
builder.Services.AddAplicacionServices();//----
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());//----


builder.Services.AddDbContext<ApiTiendaContext>(optionsBuilder =>
{
string ? connectionString =
builder.Configuration.GetConnectionString("DefaultConnection");
optionsBuilder.UseMySql(connectionString,
ServerVersion.AutoDetect(connectionString));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
