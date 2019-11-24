using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Repositories;

namespace WebApiProjekt4.Data.EFCore
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaderBoardRepository LeaderBoard { get;}
        IQueueRepository Queue { get; }
        IStatsRepository Stats { get; }
        IGameRepository Game { get; }
        IPlayerRepository Player { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
