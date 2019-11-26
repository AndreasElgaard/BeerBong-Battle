using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.EFCore;

namespace WebApiProjekt4.Repositories
{
    public interface IStatsRepository : IRepository<Stats>
    {
    }
}
