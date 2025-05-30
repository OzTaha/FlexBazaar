using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = builder.Configuration["IdentityServerUrl"];
        // oluþturulan tokenlerle hangi sayfalara eriþileceðini belirler
        opt.Audience = "ResourceOcelot";
        // http kullanmak için. fakat canlýya alacaðýn zaman yorum satýrýna al. 
        opt.RequireHttpsMetadata = false;
    });

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();
