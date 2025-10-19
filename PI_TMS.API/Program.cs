using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TMS.Infrastructure;
using TMS.Infrastructure.Data;
using TMS.Infrastructure.OptionsSetup;
using TMS.Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
{
    // Configure Azure Key Vault
    //string keyVaultUrl = "https://pi-tms-kv-2024.vault.azure.net/";
    //builder.Configuration.AddAzureKeyVault(
    //    new Uri(keyVaultUrl),
    //    new DefaultAzureCredential());
    builder.Services.AddControllers()
      .AddNewtonsoftJson(options =>
      {
          options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
      });
    builder.Services.AddInfrastructure();
    builder.Services.AddApplication();

    builder.Services.AddOpenApi();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<ApplicationDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost4200", policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    });
    
    builder.Services.ConfigureOptions<IdentityOptionsSetup>(); 

    builder.Services.AddIdentity<UserModel, IdentityRole<Guid>>()
        .AddEntityFrameworkStores<ApplicationDataContext>()
        .AddDefaultTokenProviders();

    builder.Services.AddAuthentication("Bearer")
        .AddJwtBearer("Bearer", options =>
        {
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings["Key"]))
            };
        });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowLocalhost4200");
         
    app.UseHttpsRedirection();
    
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}