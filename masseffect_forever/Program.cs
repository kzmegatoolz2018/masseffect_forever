using masseffect_forever.Services;
using masseffect_forever.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MassEffectContext>(opt => opt.UseInMemoryDatabase("MassEffectDb"));
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IPlotFlagService, PlotFlagService>();
builder.Services.AddScoped<IRomanticInterestService, RomanticInterestService>();
builder.Services.AddScoped<IBiographyService, BiographyService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Заполнение базы данных начальными данными
DataSeeder.SeedData(app);

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();