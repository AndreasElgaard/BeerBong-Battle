using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Repositories;

namespace projekt4.EFCore
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaderBoardRepository LeaderBoard { get;}
        IQueueRepository Queue { get; }
        IParticipantRepository Participant { get; }
        IGameRepository Game { get; }
        IBrugerRepository Bruger { get; }

        int Complete();
    }
}
