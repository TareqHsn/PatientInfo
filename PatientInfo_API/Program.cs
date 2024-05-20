using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Repositories;
using PatientInfo_API.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure the DbContext with the connection string from the configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("Api")["ConnectionString"]));

builder.Services.AddScoped<IPatientService, PatientRepository>();
builder.Services.AddScoped<IDiseaseInfoServices, DiseaseDetailsRepository>();
builder.Services.AddScoped<IAllergiesServices, AllergyRepository>();
builder.Services.AddScoped<INCDCServices, NCDRepository>();

builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(name: "PatientInfo_WEB",
            policy => policy.WithOrigins("https://localhost:7290/")
            .AllowAnyHeader()
            .AllowAnyMethod()
        );
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PatientInfo_WEB");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



