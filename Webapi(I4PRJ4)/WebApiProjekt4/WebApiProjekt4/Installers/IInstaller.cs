using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProjekt4.Installers
{
    public interface IInstaller
    {
        void InstallServices(IConfiguration Configuration, IServiceCollection services);
    }
}
