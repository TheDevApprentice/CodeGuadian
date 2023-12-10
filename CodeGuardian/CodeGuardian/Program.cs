using CodeGuardian.DOMAINE.Interfaces;
using CodeGuardian.DOMAINE.Services;
using CodeGuardian.INFRA;
using CodeGuardian.INFRA.Repos;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
string value = Environment.GetEnvironmentVariable("env");

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).AddJsonOptions(option => option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAdministratorService, AdministratorService>();
builder.Services.AddScoped<IAdministratorRepo, AdministratorRepo>();

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
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
