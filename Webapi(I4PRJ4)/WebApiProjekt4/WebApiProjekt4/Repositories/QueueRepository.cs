using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Data.Dto;

namespace WebApiProjekt4.Repositories
{
    public class QueueRepository : Repository<Queue>, IQueueRepository
    {
        public QueueRepository(DataContext context) : base(context)
        {
        }


        public async Task<Queue> AddUser(int PlayerId)
        {
            var Updatequeue = await DataContext.Queues.Include(q => q.Players).FirstAsync();

            if(Updatequeue == null)
            { return null; }

            var player = await DataContext.Players.FindAsync(PlayerId);

            if(player == null)
            { return null; }

            Updatequeue.Players.Add(player);

            return Updatequeue;
        }

        public async Task<GetFirstPlayerResult> GetUser()
        {
            var queue = await DataContext.Queues
                .Include(q => q.Players)
                    .ThenInclude(p => p.identityUser)
                .SingleAsync();

            if(queue.Players == null)
            {
                return null;
            }

            var player = queue.Players.Select(p => 
                new GetFirstPlayerResult
                {
                    PlayerId = p.PlayerId,
                    BrugerNavn = p.identityUser.UserName

                }).First();

            return player;
        }

        public async Task<Queue> RemovePlayer(int playerId)
        {
            var updatedqueue = await DataContext.Queues
                .Include(q => q.Players).FirstAsync();

            if(updatedqueue == null)
            {
                return null;
            }


            var player = await DataContext.Players.FindAsync(playerId);

            if(player == null)
            {
                return null;
            }

            updatedqueue.Players.Remove(player);

            return updatedqueue;
        }

        public DataContext DataContext
        {
            get { return _context as DataContext; }
        }


    }
}
