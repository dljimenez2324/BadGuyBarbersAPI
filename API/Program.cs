using API.Context;
using API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<BarberService>();
builder.Services.AddScoped<BookingItemService>();
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ServicesItemService>();

//// DataContext and SqlServer
var connectionString = builder.Configuration.GetConnectionString("BadGuyBarbersString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
