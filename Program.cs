using MongoDB.Driver;
using CarnivalBuddyApi.Models;
using CarnivalBuddyApi.Middleware;
using CarnivalBuddyApi.Services;
using CarnivalBuddyApi.Repositories.Interfaces;
using CarnivalBuddyApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDbSettings>(
builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoClient, MongoClient>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped<ICarnivalService, CarnivalService>();

builder.Services.AddScoped<ICarnivalRepository, CarnivalRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
