using DockerAPIDataModels.Context;
using DockerAPIDataModels.Interface;
using DockerAPIDataModels.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//register it as a singleton service 
builder.Services.AddSingleton<DapperContext>();

//register our interface and its implementation as a service 
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

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
