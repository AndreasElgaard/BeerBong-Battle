using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;

namespace WebApiProjekt4.Repositories
{
    public class StatsRepository : Repository<Stats>, IStatsRepository
    {
        public StatsRepository(DataContext context) : base(context)
        {
        }


        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }
    }
}
