using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"];
        // olu�turulan tokenlerle hangi sayfalara eri�ilece�ini belirler
        opt.Audience = "ResourceOcelot";
        // http kullanmak i�in. fakat canl�ya alaca��n zaman yorum sat�r�na al. 
        opt.RequireHttpsMetadata = false;
    });

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
