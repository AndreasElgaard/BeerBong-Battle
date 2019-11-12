using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using projekt4.Model;

namespace projekt4.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BBMContext _context;

        public UnitOfWork(BBMContext context)
        {
            _context = context;
            LeaderBoard = new LeaderBoardRepository(_context);
            Game = new GameRepository(_context);
            Queue = new QueueRepository(_context);
            Participant = new ParticipantRepository(_context);
        }

        public ILeaderBoardRepository LeaderBoard { get; private set; }
        public IGameRepository Game { get; private set; }
        public IQueueRepository Queue { get; private set; }
        public IParticipantRepository Participant { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
