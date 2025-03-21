using ASIST_UMG_api.Data;
using ASIST_UMG_api.Mappers.Marcajes;
using ASIST_UMG_api.Mappers.Personas;
using ASIST_UMG_api.Mappers.SedesCentros;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs;
using ASIST_UMG_api.Repository;
using ASIST_UMG_api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conexion a base de datos
//Conexion a la base de datos
builder.Services.AddDbContext<UmgContext>(options =>
    // options.UseMySQL(builder.Configuration.GetConnectionString("ConnMysql"), new MysqlServerVersion("8.0.32"));
    options.UseNpgsql(builder.Configuration.GetConnectionString(name: "Conn_local")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;  // Header info for clients to see the supported versions
});
builder.Services.AddSwaggerGen();

//Repositorios
builder.Services.AddScoped<iSedesCentros, cSedesCentrosRepo>();
builder.Services.AddScoped<iPersonas, PersonaRepo>();
builder.Services.AddScoped<iMarcajes, MarcajeRepo>();



//Automapper
builder.Services.AddAutoMapper(typeof(cMarcajeMapper));
builder.Services.AddAutoMapper(typeof(cPersonaMapper));
builder.Services.AddAutoMapper(typeof(cSedesCentrosMapper));




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
