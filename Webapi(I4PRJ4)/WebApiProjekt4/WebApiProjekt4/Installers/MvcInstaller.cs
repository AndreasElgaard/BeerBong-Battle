using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using WebApiProjekt4.options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using System.Text;
using AutoMapper;
using WebApiProjekt4.Services;
using WebApiProjekt4.Repositories;
using WebApiProjekt4.Data.EFCore;


namespace WebApiProjekt4.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddScoped<IStatsRepository, StatsRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddScoped<IIdentityService, IdentityService>();

            

            var AppSettings = new AppSettings();
            Configuration.Bind(nameof(AppSettings), AppSettings);

            services.AddSingleton(AppSettings);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BBMSIMS", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                     {"Bearer", new string[0]}
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header usinger the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT"
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
                        new string[]{}
                    }

                });
            });
        }
    }
}
