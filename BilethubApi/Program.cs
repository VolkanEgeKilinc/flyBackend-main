using System.Reflection;
using System.Text;
using BilethubApi.Api.DbOperations;
using BilethubApi.Core.Extensions;
using BilethubApi.Core.Services.Logger;
using BilethubApi.Core.Services.Firebase;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.Configuration.SetBasePath("//var/www/bilethub-api");
}


var firebaseApp = FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
});

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        ClockSkew = TimeSpan.Zero
    };
});

//Database
builder.Services.AddDbContext<BilethubDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "BilethubDb"));
builder.Services.AddScoped<IBilethubDbContext>(service => service.GetService<BilethubDbContext>()!);

//AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Logger
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

//Notification
builder.Services.AddSingleton<INotificationService, NotificationService>();
builder.Services.AddHostedService<ReminderService>();

//Default
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCustomException();

app.Run();
