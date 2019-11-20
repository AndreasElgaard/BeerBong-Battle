using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using projekt4.Model;
using projekt4.EFCore;
using projekt4.Repositories;
using projekt4.options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity;

namespace projekt4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var appsettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appsettingsSection);

            var appSettings = appsettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddSingleton<AppSettings>();

            services.AddDbContext<BBMContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("Defaultconnection")));

            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<BBMContext>()
                .AddDefaultTokenProviders();

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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
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





            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddScoped<IParticipantRepository, ParticipantRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IBrugerRepository, BrugerRepository>();

            
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:5000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
                


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BBM SIS API v1");
                c.RoutePrefix = string.Empty; //launch swagger from root
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
