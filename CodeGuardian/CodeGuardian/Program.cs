using CodeGuardian.API.Controllers;
using CodeGuardian.API.Logger;
using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.DOMAINE.Services;
using CodeGuardian.INFRA;
using CodeGuardian.INFRA.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using DotEnv;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
string value = Environment.GetEnvironmentVariable("ENVIRONMENT");

Auth auth = new Auth();
var result = auth.ExtractConfiguration($"SELECT value FROM SecurityConfiguration WHERE name = 'secretKey'");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(result))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddSingleton(new ExcelLoggerConfiguration
{
    FilePath = Environment.GetEnvironmentVariable("EXCEL_LOGGER_FILE_PATH") ?? "fichier.xlsx"
});

builder.Services.AddLogging(builder =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    builder.AddProvider(new ExcelLoggerProvider(serviceProvider.GetRequiredService<IOptions<ExcelLoggerConfiguration>>()));
});

builder.Services.AddScoped<IExcelLogger, ExcelLogger>();

builder.Services.AddScoped<IDevService, DevService>();
builder.Services.AddScoped<IDevRepo, DevRepo>();
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IAdministratorRepo, AdministratorRepo>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionRepo, PermissionRepo>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();
builder.Services.AddScoped<IOrganisationRepo, OrganisationRepo>();
builder.Services.AddScoped<ILicenceService, LicenceService>();
builder.Services.AddScoped<ILicenceRepo, LicenceRepo>();

if (value == "stage")
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_STAGE")));
}
else if (value == "prod" || builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION_PROD")));
}
else
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseInMemoryDatabase("CodeGuardianDb"));
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    string swaggerDescriptionFileName = $"SwaggerDescription.md";
    string swaggerDescriptionContent = File.ReadAllText(swaggerDescriptionFileName);

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeGuardianTestUI", Description = swaggerDescriptionContent, Version = "v1" });


    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
    options.OperationFilter<JwtTokenOperationFilter>();
});

var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeGuardianTestUI V1");
    });
}

if (value != "stage" || value != "prod")
{
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<CodeGuardianDbContext>();
        dbContext.Database.EnsureCreated();
    }
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
