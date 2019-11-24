using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProjekt4.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApiProjekt4.Data;
using WebApiProjekt4.options;
using Microsoft.Extensions.Options;

namespace WebApiProjekt4.Data.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;

            LeaderBoard = new LeaderBoardRepository(_context);
            Game = new GameRepository(_context);
            Queue = new QueueRepository(_context);
            Stats = new StatsRepository(_context);
            Player = new PlayerRepository(_context);
        }

        public ILeaderBoardRepository LeaderBoard { get; private set; }
        public IGameRepository Game { get; private set; }
        public IQueueRepository Queue { get; private set; }
        public IStatsRepository Stats { get; private set; }
        public IPlayerRepository Player { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
