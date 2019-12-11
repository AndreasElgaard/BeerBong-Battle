using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Repositories;

namespace WebApiProjekt4.Data.EFCore
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaderBoardRepository LeaderBoard { get; set; }
        IQueueRepository Queue { get; set; }
        IStatsRepository Stats { get; set; }
        IGameRepository Game { get; set; }
        IPlayerRepository Player { get; set; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
