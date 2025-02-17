using CRUD_Tarefas.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    swaggerGenConfiguration =>
    {
        var assembly = System
            .Reflection
            .Assembly
            .GetExecutingAssembly()
            ;
        var assemblyName = assembly
            .GetName()
            .Name
            ;
        var xmlFile = $"{assemblyName}.xml";
        var xmlPath = Path.Combine(
            AppContext.BaseDirectory,
            xmlFile
        );

        swaggerGenConfiguration.IncludeXmlComments(
            xmlPath
        );
    }
);

var connectionStringMysql = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseMySql(
    connectionStringMysql, 
    ServerVersion.Parse("8.0.41-mysql")
    )
    );


builder.Services.AddCors(); // Make sure you call this previous to AddMvc
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    options => options.WithOrigins("http://localhost:3001", "http://localhost:3002", "http://localhost:3003","http://localhost:3004").AllowAnyMethod().AllowAnyHeader()
);

app.UseMvc();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
