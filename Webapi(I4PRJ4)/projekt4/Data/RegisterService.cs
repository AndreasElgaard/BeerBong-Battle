using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Model;


namespace projekt4.Data
{
    public class RegisterService : IRegisterService
    {
        private IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository ?? throw new ArgumentNullException(nameof(registerRepository));
        }
        public Task<Register> CreateAsync(Register register)
        {
            throw new NotSupportedException();
        }

        public Task<Register> DeleteAsync(int id)
        {
            throw new NotSupportedException();
        }

        public Task<Register> GetOneRegisterAsync(int id)
        {
            return _registerRepository.GetOneRegisterAsync(id);
        }

        public Task<IEnumerable<Register>> GetRegisterAsync()
        {
            return _registerRepository.GetRegisterAsync();
        }

        public async Task<bool> IsRegisterExitsAsync(int id)
        {
            var register = await _registerRepository.GetOneRegisterAsync(id);
            return register != null;
        }

        public Task<Register> UpdateAsync(Register register)
        {
            throw new NotSupportedException();
        }
    }
}
