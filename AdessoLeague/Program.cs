using AdessoLeague.Business.Contract;
using AdessoLeague.Business.Service;
using AdessoLeague.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MainContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"], o =>
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    });
});
builder.Services.AddScoped<MainContext>();
builder.Services.AddScoped<IGroupCreator, FourGroupCreator>();
builder.Services.AddScoped<IGroupCreator, EigthGroupCreator>();
builder.Services.AddScoped<GroupCreatorContext>();

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
