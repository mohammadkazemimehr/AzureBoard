


using Azure.ToDo.Base.Extentions;
using Azure.ToDo.Base.JsonConverters;
using Azure.ToDo.Repository.Implimation;
using Azure.ToDo.Repository.Implimentation;
using Azure.ToDo.Repository.Implimentation.Implimentation;
using Azure.ToDo.Repository.Interface;
using Azure.ToDo.Service.Implimentation.Implimentation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appSettings.json")
        .Build();

// Add services to the container.
builder.Services.AddRazorPages();

Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine("Azure Board Host run at : " + DateTime.Now);
Console.ResetColor();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
}).AddJsonOptions(opt =>
{
    //opt.JsonSerializerOptions.Converters.Add(new EnumJsonConverter());
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    opt.JsonSerializerOptions.Converters.Add(new GuidJsonConverter());
    opt.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IServiceHolder, ServiceHolder>();
builder.Services.AddScoped<IExceptionLogger, ExceptionLogger>();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Main")));
builder.Services.AddDbContext<LogContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Log")));


var jwtIssuerOptions = new JwtIssuerOptions();
config.GetSection("JwtIssuerOptions").Bind(jwtIssuerOptions);

SymmetricSecurityKey signingKey =
    new SymmetricSecurityKey(
        Encoding.ASCII.GetBytes(jwtIssuerOptions.SecretKey));

// Configure JwtIssuerOptions
builder.Services.Configure<JwtIssuerOptions>(options =>
{
    options.Issuer = jwtIssuerOptions.Issuer;
    options.Audience = jwtIssuerOptions.Audience;
    options.SecretKey = jwtIssuerOptions.SecretKey;
    options.ExpireTimeTokenInMinute = jwtIssuerOptions.ExpireTimeTokenInMinute;
    options.ValidTimeInMinute = jwtIssuerOptions.ValidTimeInMinute;
    options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
});

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = jwtIssuerOptions.Issuer,

    ValidateAudience = true,
    ValidAudience = jwtIssuerOptions.Audience,

    ValidateIssuerSigningKey = true,
    IssuerSigningKey = signingKey,

    RequireExpirationTime = false,
    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, configureOptions =>
{
    configureOptions.ClaimsIssuer = jwtIssuerOptions.Issuer;
    configureOptions.TokenValidationParameters = tokenValidationParameters;
    configureOptions.SaveToken = true;
});


var app = builder.Build().Seed();

app.UseHealthChecks("/api/ResourcesAndExpenses/HealthCheck");
app.UseAuthentication();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseCustomMiddleware();
app.UseAuthorization();
// Configure the HTTP request pipeline.
app.MapControllers();

app.Run();
