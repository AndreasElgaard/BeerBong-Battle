using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;

namespace WebApiProjekt4.Repositories
{
    public class LeaderBoardRepository : Repository<LeaderBoard>, ILeaderBoardRepository
    {
        public LeaderBoardRepository(DataContext context) : base(context)
        {
        }

        public IEnumerable<LeaderBoard> GetLeaderboardWithUsers(int leaderboardId, int NumberofUsers)
        {
            throw new NotImplementedException();  
        }

        public IEnumerable<LeaderBoard> GetTopOnLeaderboard(int count)
        {
            throw new NotImplementedException();
        }

        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }
    }
}
