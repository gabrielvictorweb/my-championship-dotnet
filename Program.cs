using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using my_championship.Application.Validators;
using my_championship.Infrastructure.Data;
using my_championship.Application.UseCases;
using my_championship.Infrastructure.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Controllers + JSON + FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        fv.RegisterValidatorsFromAssemblyContaining<CreateChampionshipValidator>()
    )
    .AddJsonOptions(options =>
    {
        // 🔥 CORREÇÃO PRINCIPAL
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;

        // Opcional (pode remover em produção)
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // HTTP
});

// Repositories
builder.Services.AddScoped<ChampionshipRepository>();
builder.Services.AddScoped<TeamRepository>();
builder.Services.AddScoped<TeamKeyRepository>();

// Use cases
builder.Services.AddScoped<SaveChampionship>();
builder.Services.AddScoped<SaveTeam>();
builder.Services.AddScoped<SaveTeamKey>();

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
