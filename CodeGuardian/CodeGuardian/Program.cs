using CodeGuardian.API.Controllers;
using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.DOMAINE.Services;
using CodeGuardian.INFRA;
using CodeGuardian.INFRA.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
string value = Environment.GetEnvironmentVariable("env");

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

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IAdministratorRepo, AdministratorRepo>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IApplicationRepo, ApplicationRepo>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPermissionRepo, PermissionRepo>();
builder.Services.AddScoped<ILicenceService, LicenceService>();
builder.Services.AddScoped<ILicenceRepo, LicenceRepo>();

if (value == "stage")
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseSqlServer("Server=10.4.1.38,1433;Database=CodeGuardianDataBase;User id=sa;Pwd=yourStrong@0Password!;TrustServerCertificate=True"));
}
else if (value == "prod" || builder.Environment.IsProduction())
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseSqlServer("Server=10.4.1.39,1433;Database=CodeGuardianDataBase;User id=sa;Pwd=yourStrong@0Password!;TrustServerCertificate=True"));
}
else
{
    builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseInMemoryDatabase("CodeGuardianDb"));
}

builder.Services.AddDbContext<CodeGuardianDbContext>(options => options.UseSqlServer("Server=10.4.1.38,1433;Database=CodeGuardianDataBase;User id=sa;Pwd=yourStrong@0Password!;TrustServerCertificate=True"));

//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // ...
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeGuardianTestUI", Description = "Descritpiotn de l'api" ,Version = "v1" });
   
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


// Configure the HTTP request pipeline.
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
