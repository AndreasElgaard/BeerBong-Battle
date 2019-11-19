using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt4.EFCore;
using projekt4.Model;

namespace projekt4.Repositories
{
    public class LeaderBoardRepository : Repository<LeaderBoard>, ILeaderBoardRepository
    {
        public LeaderBoardRepository(BBMContext context) : base(context)
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

        public BBMContext BBMContext
        {
            get { return _context as BBMContext; }
        }
    }
}
