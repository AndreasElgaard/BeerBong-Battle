using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt4.EFCore;
using projekt4.Model;

namespace projekt4.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(DbContext context) : base(context)
        {
        }

        public BBMContext BBMContext
        {
            get { return _context as BBMContext; }
        }
    }
}
