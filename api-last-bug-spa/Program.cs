using Microsoft.EntityFrameworkCore;
using api_last_bug_spa.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
//Log

var config = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();
Log.Logger = new LoggerConfiguration()
.ReadFrom.Configuration(config)
.CreateLogger();
// Add services to the container.
Log.Information("Iniciando The Last Bug SPA .Api");
builder.Host.UseSerilog();
builder.Logging.AddSerilog();

builder.Configuration.AddJsonFile("appsettings.json");
var secretkey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretkey);

builder.Services.AddAuthentication(config => { 
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "WebAPI",
        Description = "Product WebAPI"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                }
            },
            new List < string > ()
        }
    });
});
//Serive Layer
//builder.Services.AddScoped<PaisesService>();
//builder.Services.AddScoped<UsuariosService>();
//builder.Services.AddScoped<RegionesService>();
//builder.Services.AddScoped<ComunaService>();
//builder.Services.AddScoped<AyudaSocialService>();
//builder.Services.AddScoped<AsignacionAyudaSocialService > ();

builder.Services.AddDbContext<LastBugSpaContext>(opt=>opt.UseSqlServer(builder.Configuration.GetConnectionString("DbContet-string")));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//CORS PARA CONSUMO DE DOMINIOS
var misReglasCors = "ReglasCors";
builder.Services.AddCors(opt => {
    opt.AddPolicy(name: misReglasCors, builder => {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Product WebAPI");
    });
}

app.UseCors(misReglasCors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
