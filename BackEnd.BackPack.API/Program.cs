using BackEnd.BackPack.Infraestruture.DI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddRepositories();
builder.Services.AddApplicationLayer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseAuthorization();

app.MapControllers();

app.Run();