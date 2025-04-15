using ASIST_UMG_api.Data;
using ASIST_UMG_api.Mappers.Curso;
using ASIST_UMG_api.Mappers.Facultad;
using ASIST_UMG_api.Mappers.Marcajes;
using ASIST_UMG_api.Mappers.Personas;
using ASIST_UMG_api.Mappers.SedesCentros;
using ASIST_UMG_api.Models;
using ASIST_UMG_api.Models.DTOs;
using ASIST_UMG_api.Repository;
using ASIST_UMG_api.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conexion a la base de datos
builder.Services.AddDbContext<UmgContext>(options =>
    // options.UseMySQL(builder.Configuration.GetConnectionString("ConnMysql"), new MysqlServerVersion("8.0.32"));
     options.UseNpgsql(builder.Configuration.GetConnectionString(name: "Conn_local")));
    //  options.UseNpgsql(builder.Configuration.GetConnectionString(name: "Conn_cloud")));

//Configuracion CORS
builder.Services.AddCors(p => p.AddPolicy("CORS", options =>
{
    options.WithOrigins("http://localhost:5019",
                        "http://46.202.93.199:5019/",
                        "http://46.202.93.199:5019"
                       ).WithMethods("PATCH", "PUT", "GET", "POST").AllowAnyHeader();

}));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
// Add API versioning
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;  // Header info for clients to see the supported versions
    //options.ApiVersionReader = ApiVersionReader.Combine(
        //new QueryStringApiVersionReader("api-version"),
        //new HeaderApiVersionReader("X-Version"));
        //new MediaTypeApiVersionReader("ver"));
});
/*builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});*/
builder.Services.AddSwaggerGen();

//Repositorios
builder.Services.AddScoped<iFacultades, cFacultadesRepo>();
builder.Services.AddScoped<iCurso, cCursoRepo>();
builder.Services.AddScoped<iSedesCentros, cSedesCentrosRepo>();
builder.Services.AddScoped<iPersonas, PersonaRepo>();
builder.Services.AddScoped<iMarcajes, MarcajeRepo>();


//Automapper
builder.Services.AddAutoMapper(typeof(cFacultadMapper));
builder.Services.AddAutoMapper(typeof(cMarcajeMapper));
builder.Services.AddAutoMapper(typeof(cPersonaMapper));
builder.Services.AddAutoMapper(typeof(cSedesCentrosMapper));
builder.Services.AddAutoMapper(typeof(cCursoMapper));




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORS");
//app.UseHttpsRedirection();
app.UseForwardedHeaders();

app.UseAuthorization();

app.MapControllers();


app.Run();
