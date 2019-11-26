using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;

namespace WebApiProjekt4.Repositories
{
    public interface IQueueRepository : IRepository<Queue>
    {
        Task<Queue> AddUser(int userid);
        Task<object> GetUser();
        Task<Queue> RemovePlayer(int id);
    }
}
