using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Data;
using projekt4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace projekt4.Data
{
    public interface IRegisterRepository
    {
        Task<IEnumerable<Register>> GetRegisterAsync();
        Task<ActionResult<Register>> GetOneRegisterAsync(int id);

        Task<bool> IsRegisterExitsAsync(int id);

        Task<ActionResult<Register>> CreateAsync(Register register);

        Task<IActionResult> UpdateAsync(Register register);

        Task<ActionResult<Register>> DeleteAsync(int id);
    }
}
