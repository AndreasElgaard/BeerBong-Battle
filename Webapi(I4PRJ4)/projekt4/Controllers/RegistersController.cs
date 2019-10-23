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
    public class RegistersController : BBMController<Register, EFCoreRegisterRepository>
    {
       public RegistersController(EFCoreRegisterRepository repository) : base(repository)
        {

        }

    }
}
