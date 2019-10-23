using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projekt4.Data;
using projekt4.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

//namespace projekt4.Repositories
//{
//    public class RegisterRepository : IRegisterRepository
//    {
//        private readonly BBMContext _Context;
//        public RegisterRepository(BBMContext context)
//        {
//            _Context = context ?? throw new ArgumentNullException(nameof(context));
//        }

//        public Task<ActionResult<Register>> CreateAsync(Register register)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<Register>> DeleteAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ActionResult<Register>> GetOneRegisterAsync(int id)
//        {
//            var register = _Context.Register.Find(id);

//            if (register == null)
//                return null;

//            return register;
//        }

//        public Task<IEnumerable<Register>> GetRegisterAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<bool> IsRegisterExitsAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IActionResult> UpdateAsync(Register register)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
