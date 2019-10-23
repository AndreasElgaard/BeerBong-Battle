using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt4.Model;
using projekt4.Data;
using projekt4.Repositories;

namespace projekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugersController : BBMController<Bruger, EFCoreBrugerRepository>
    {
        public BrugersController(EFCoreBrugerRepository repository) : base(repository)
        {
        }

    }
}
