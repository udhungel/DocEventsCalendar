using DocEventsAttendanceCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.Domain.Interfaces;
using DocEventsAttendeeCalendar.Repositories;
using DocEventsCalendar.Data;
using DocEventsCalendar.Domain.Interfaces;
using DocEventsCalendar.Domain.Repositories;
using DocEventsCalendar.Domain.Services;
using DoctorCalendarAPI.Repositories;
using DoctorCalendarAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});



builder.Services.AddScoped<IAttendeeService, AttendeeService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IAttendeeRepository, AttendeeRepository>();
builder.Services.AddScoped<IEventAttendeeRepository, EventAttendeeRepository>();
builder.Services.AddScoped<IEventAttendeeService, EventAttendeeService>();


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
