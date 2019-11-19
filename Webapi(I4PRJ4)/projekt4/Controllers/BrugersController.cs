using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekt4.EFCore;
using projekt4.Model;

namespace projekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BrugersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;

        public BrugersController(IUnitOfWork unitOfWork)
        {
            unitOfWork_ = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Bruger>> GetAll()
        {
            var brugere = unitOfWork_.Bruger.GetAll();

            if(brugere == null)
            {
                return NotFound();
            }

            return Ok(brugere);
        }

        [HttpGet("{id}")]
        public ActionResult<Bruger> Get(int id)
        {
            var bruger = unitOfWork_.Bruger.Get(id);

            if(bruger == null)
            {
                return BadRequest(new { message = "Userid does not exist" });
            }

            return bruger;
        }

        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody]Bruger bruger)
        {
            try
            {
                unitOfWork_.Bruger.Add(bruger);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "username or password allraedy exist" });
            }
            

            return Ok(bruger);
        }

        [Route("AddRange")]
        [HttpPost]
        public IActionResult PostRange(IEnumerable<Bruger> brugers)
        {
            try
            {
                unitOfWork_.Bruger.AddRange(brugers);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "username or password allraedy exist" });
            }


            return Ok(brugers);
            
        }

        [HttpDelete]
        public IActionResult Delete(Bruger bruger)
        {
            try
            {
                unitOfWork_.Bruger.Remove(bruger);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Bruger does not exsist" });
            }

            return Ok(bruger);
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public IActionResult DeleteRange(IEnumerable<Bruger> brugers)
        {

            try
            {
                unitOfWork_.Bruger.RemoveRange(brugers);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Bruger does not exsist" });
            }

            return Ok(brugers);
           
        }

        
        [HttpPost("Authenticate")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromBody]Bruger bruger)
        {
            var user = unitOfWork_.Bruger.Authenticate(bruger.UserName, bruger.PassWord);
            unitOfWork_.Complete();

            if (user == null)
                return BadRequest(new { message = "Username or Password is incorrect" });

            return Ok(user);
        }

        [HttpPut]
        public IActionResult Update(int id, Bruger bruger)
        {
            var exist = unitOfWork_.Bruger.Get(id);

            if(exist == null)
            {
                return BadRequest(new { message = "Bruger with that Id does not exist" });
            }

            unitOfWork_.Bruger.Update(bruger);
            unitOfWork_.Complete();

            return Ok();
        }

    }
}