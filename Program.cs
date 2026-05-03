using AttineosCurrency.Data;
using AttineosCurrency.Repositories;
using AttineosCurrency.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=attineos.db"));

builder.Services.AddScoped<IAttineosCurrencyRepository, AttineosCurrencyRepository>();
builder.Services.AddScoped<IAttineosCurrencyService, AttineosCurrencyService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/", () => "API running");

app.Run();