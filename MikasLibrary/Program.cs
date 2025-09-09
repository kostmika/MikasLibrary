using Microsoft.EntityFrameworkCore;
using MikasLibrary.Dal;
using MikasLibrary.Interfaces;
using MikasLibrary.Services;
using MikasLibrary.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDBContext>(options =>
    options.UseSqlite("Data Source=library.db"));

builder.Services.AddScoped<IBooksDal, BooksDal>();
builder.Services.AddScoped<IUsersDal, UsersDal>();
builder.Services.AddScoped<IBooksService, BooksService>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddControllers();
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
