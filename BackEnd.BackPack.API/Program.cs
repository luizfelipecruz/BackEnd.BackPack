using BackEnd.BackPack.API.Middlewares;
using BackEnd.BackPack.Application.DI;
using BackEnd.BackPack.Infrastructure.DI;
using BackEnd.BackPack.Infrastructure.Extensions;
using BackEnd.BackPack.Infrastructure.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira seu token JWT."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddIdentity(builder.Configuration);


builder.Services.AddApplicationLayer();



var app = builder.Build();

await app.Services.InitializeDatabaseAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await CreateRoles(app.Services);

app.Run();


static async Task CreateRoles(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

    foreach (var roleName in Role.Roles)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            var identityRole = new IdentityRole<Guid>(roleName);
            await roleManager.CreateAsync(identityRole);
            await roleManager.AddClaimAsync(identityRole, new Claim(ClaimTypes.Role, roleName));
        }
    }
}