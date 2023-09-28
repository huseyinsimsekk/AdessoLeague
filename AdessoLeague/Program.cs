using AdessoLeague.Business.Contract;
using AdessoLeague.Business.Service;
using AdessoLeague.Data;
using AdessoLeague.Model;
using AdessoLeague.Validator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options => options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
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
builder.Services.AddSingleton<IValidator<GroupCreateRequestModel>, GroupCreateRequestModelValidator>();

builder.Services.AddScoped<MainContext>();
builder.Services.AddScoped<IGroupCreator, FourGroupCreator>();
builder.Services.AddScoped<IGroupCreator, EigthGroupCreator>();
builder.Services.AddScoped<GroupCreatorContext>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
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
