using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoREST.Models;

namespace TodoREST.Data
{
   public interface IRestServicePlayer
    {
        Task AddPlayer(Player player);

        Task RemovePlayerQueue();

        Task<int> GetPlayerId(Player player);
    }
}
