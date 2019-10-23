using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Model;
using Microsoft.EntityFrameworkCore;

namespace projekt4.Data
{
    public class RegisterService : IRegisterService
    {
        private readonly BBMContext _Context;

        public RegisterService(BBMContext context )
        {
            _Context = context?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Register> CreateAsync(Register register)
        {
            _Context.Register.Add(register);

            await _Context.SaveChangesAsync();

            return register;
        }

        public async Task<Register> DeleteAsync(int id)
        {
            var register = await _Context.Register.FindAsync(id);
            if(register == null)
            {
                return null;
            }

            _Context.Register.Remove(register);
            await _Context.SaveChangesAsync();

            return register;
        }

        public async Task<Register> GetOneRegisterAsync(int id)
        {
            var register = await _Context.Register.FindAsync(id);

            if (register == null)
                return null;

            return register;
        }

        public async Task<IEnumerable<Register>> GetRegisterAsync()
        {
            return await _Context.Register.ToListAsync();
        }

        public async Task<bool> IsRegisterExitsAsync(int id)
        {
            var register = await GetOneRegisterAsync(id);
            return register != null;
        }

        public async Task<Register> UpdateAsync(Register register, int id)
        {

            if (id != register.Id)
                return null;

            _Context.Entry(register).State = EntityState.Modified;

            try
            {
                await _Context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if(IsRegisterExitsAsync(id) == null)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return register;
        }
    }
}


