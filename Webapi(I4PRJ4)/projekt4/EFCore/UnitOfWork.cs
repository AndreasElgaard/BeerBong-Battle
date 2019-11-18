using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using projekt4.Model;
using projekt4.options;
using Microsoft.Extensions.Options;

namespace projekt4.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BBMContext _context;
        private readonly AppSettings _settings;
        public UnitOfWork(BBMContext context, IOptions<AppSettings> settings)
        {
            _context = context;
            _settings = settings.Value;

            LeaderBoard = new LeaderBoardRepository(_context);
            Game = new GameRepository(_context);
            Queue = new QueueRepository(_context);
            Participant = new ParticipantRepository(_context);
            Bruger = new BrugerRepository(_context, _settings);
        }

        public ILeaderBoardRepository LeaderBoard { get; private set; }
        public IGameRepository Game { get; private set; }
        public IQueueRepository Queue { get; private set; }
        public IParticipantRepository Participant { get; private set; }
        public IBrugerRepository Bruger { get; private set; }

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
