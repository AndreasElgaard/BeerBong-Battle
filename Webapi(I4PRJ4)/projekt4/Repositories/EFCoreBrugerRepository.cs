using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Data;
using projekt4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace projekt4.Repositories
{
    public class EFCoreBrugerRepository : EFCoreRepository<Bruger, BBMContext>
    {
        public EFCoreBrugerRepository(BBMContext context) : base(context)
        {

        }
    }
}
