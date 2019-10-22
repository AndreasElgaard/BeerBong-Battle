using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Model;

namespace projekt4.Data
{
    public interface IRegisterService
    {
        Task<IEnumerable<Register>> GetRegisterAsync();
        Task<Register> GetOneRegisterAsync(int id);

        Task<bool> IsRegisterExitsAsync(int id);

        Task<Register> CreateAsync(Register register);

        Task<Register> UpdateAsync(Register register, int id);

        Task<Register> DeleteAsync(int id);
    }
}
