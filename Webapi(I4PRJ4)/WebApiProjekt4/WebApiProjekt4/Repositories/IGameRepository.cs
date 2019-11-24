using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<Game> AddUserToGame(int id, int player1Id, int player2Id);
        Task<IEnumerable<GameWinnerResult>> Winner(int Gameid);
    }
}
