using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Model;

namespace projekt4.Repositories
{
    public interface ILeaderBoardRepository : IRepository<LeaderBoard>
    {
        IEnumerable<LeaderBoard> GetTopOnLeaderboard(int count);
        IEnumerable<LeaderBoard> GetLeaderboardWithUsers(int leaderboardId, int NumberofUsers);
    }
}
