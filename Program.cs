
using Microsoft.EntityFrameworkCore;
using PatientManagementApi.Data;
using PatientManagementApi.Repositories;
using PatientManagementApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dapr
builder.Services.AddDaprClient();

var patientInfoConnectionString = builder.Configuration.GetConnectionString("PatientInfoConnection");
var patientDetailsConnectionString = builder.Configuration.GetConnectionString("PatientDetailsConnection");

if (string.IsNullOrEmpty(patientInfoConnectionString))
{
    Console.WriteLine("PatientInfoConnection connection string is null or empty.");
}
if (string.IsNullOrEmpty(patientDetailsConnectionString))
{
    Console.WriteLine("PatientDetailsConnection connection string is null or empty.");
}

// Add DbContext

builder.Services.AddDbContext<PatientInfoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PatientInfoConnection")));
builder.Services.AddDbContext<PatientDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PatientDetailsConnection")));


    // Add Repositories and Services
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPatientDetailRepository, PatientDetailRepository>();
builder.Services.AddScoped<IPatientDetailService, PatientDetailService>();


Console.WriteLine(builder.Configuration.GetConnectionString("PatientInfoConnection")+"Test1");
Console.WriteLine(builder.Configuration.GetConnectionString("PatientDetailsConnection"));

var app = builder.Build();
/*
// apply auto migration 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var patientInfoContext = services.GetRequiredService<PatientInfoContext>();
        patientInfoContext.Database.Migrate();

        var patientDetailsContext = services.GetRequiredService<PatientDetailsContext>();
        patientDetailsContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}
*/
// Configure the HTTP request pipeline.
app.MapControllers();
app.UseRouting();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
