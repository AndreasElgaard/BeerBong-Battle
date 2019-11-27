using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Repositories;
using WebApiProjekt4.Services;


namespace WebApiProjekt4.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddScoped<IStatsRepository, StatsRepository>();
            services.AddScoped<IQueueRepository, QueueRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
