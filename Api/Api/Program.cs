using System.Reflection;
using Api.Infrastructures;
using Api.Middlewares;
using Api.Models;
using DbContext.Ticket;
using Domain.IssueRepository;
using Domain.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var section = builder.Configuration.GetSection(nameof(Options));
var options = section.Get<Options>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ticket API"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] { }
        }
    });
});

builder.Services.Configure<Options>(section);

Action<DbContextOptionsBuilder>? logTo = null;
builder.Services.AddDbContextPool<TicketContext>(optionsBuilder =>
{
    logTo?.Invoke(optionsBuilder);
    optionsBuilder.UseSqlServer(options.ConnectionString!);
});

builder.Services.AddScoped<IJwtAuth, JwtAuth>();
builder.Services.AddTransient<IIssueRepository, IssueRepositoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepositoryRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    logTo = optionsBuilder =>
    {
        optionsBuilder.LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information, DbContextLoggerOptions.UtcTime | DbContextLoggerOptions.SingleLine)
            .EnableSensitiveDataLogging();
    };

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandler>();
app.UseMiddleware<JwtHandler>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();