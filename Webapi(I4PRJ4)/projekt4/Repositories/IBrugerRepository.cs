using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.EFCore;
using projekt4.Model;
namespace projekt4.Repositories
{
    public interface IBrugerRepository : IRepository<Bruger>
    {
        Bruger Authenticate(string username, string passward);
    }
}
