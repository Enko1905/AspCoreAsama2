using Demo.Persistence;
using Demo.Application;
using Demo.Infrastructure;
using Demo.Mapper;
using Microsoft.OpenApi.Models;
using Demo.Application.Features.Auth.Rules;
using Demo.Infrastructure.RedisCache;
using MediatR;
using Demo.Application.Beheviors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddPersistence(builder.Configuration);

//Delete
//builder.Services.AddTransient(typeof(IRedisCacheService), typeof(RedisCacheService));
//builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehavior<,>));


builder.Services.AddApplication();
builder.Services.AddCustomMapper();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aþama 2 Proje", Version = "v1" });

    // JWT Bearer config
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header. \r\n\r\n 'Bearer {token}' þeklinde giriniz."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
