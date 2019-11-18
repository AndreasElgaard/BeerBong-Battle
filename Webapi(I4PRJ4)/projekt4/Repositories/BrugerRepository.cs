using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projekt4.EFCore;
using projekt4.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using projekt4.options;
using Microsoft.Extensions.Options;

namespace projekt4.Repositories
{
    public class BrugerRepository : Repository<Bruger>, IBrugerRepository
    {
        public BrugerRepository(BBMContext context, AppSettings appsettings) : base(context)
        {
            _appsettings = appsettings;
        }

        private readonly AppSettings _appsettings;

        public Bruger Authenticate(string username, string password)
        {
            var bruger = BBMContext.Brguers.SingleOrDefault(x => x.UserName == username && x.PassWord == password);

            if (bruger == null)
                return null;

            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, bruger.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", bruger.BrugerId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenhandler.CreateToken(tokenDescriptor);
            bruger.Token = tokenhandler.WriteToken(token);

            return bruger;
        }

        public BBMContext BBMContext
        {
            get { return _context as BBMContext; }
        }

        
    }
}
