//using Microsoft.EntityFrameworkCore;
//using PatientInfo_API.Data;
//using PatientInfo_API.Halper;
//using PatientInfo_API.Repositories;
//using PatientInfo_API.Services;


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
//builder.Services.AddAutoMapper(typeof(MappingConfig));

//builder.Services.AddScoped<IAllergiesServices, AllergiesRepository>(); 
//builder.Services.AddScoped<INDCServices, NDCRepository>(); 
//builder.Services.AddScoped<IDiseaseInfoServices, DiseaseInfoRepository>(); 
//builder.Services.AddScoped<INCDDetailServices, NCDDetailRepository>(); 
//builder.Services.AddScoped<IAllergyDetailServices, AllergyDetailRepository>(); 
//builder.Services.AddScoped<IPatientService, PatientRepository>(); 

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using Microsoft.EntityFrameworkCore;
using PatientInfo_API.Data;
using PatientInfo_API.Halper;
using PatientInfo_API.Repositories;
using PatientInfo_API.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddScoped<IAllergiesServices, AllergiesRepository>();
builder.Services.AddScoped<INDCServices, NDCRepository>();
builder.Services.AddScoped<IDiseaseInfoServices, DiseaseInfoRepository>();
builder.Services.AddScoped<INCDDetailServices, NCDDetailRepository>();
builder.Services.AddScoped<IAllergyDetailServices, AllergyDetailRepository>();
builder.Services.AddScoped<IPatientService, PatientRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.MaxDepth = 64; 
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();



