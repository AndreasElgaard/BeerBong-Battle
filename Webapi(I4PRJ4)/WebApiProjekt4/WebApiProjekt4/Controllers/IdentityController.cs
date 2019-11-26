using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProjekt4.Data.EFCore;
using Microsoft.AspNetCore.Identity;
using WebApiProjekt4.Data.Dto;
using WebApiProjekt4.Services;

namespace WebApiProjekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
            var authresponse = await _identityService.RegisterAsync(userRegistrationRequest.UserName, userRegistrationRequest.PassWord);

            if(!authresponse.Success)
            {
                return BadRequest(authresponse.ErrorMessage);
            }

            return Ok(authresponse);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserRegistrationRequest userRegistrationRequest)
        {
            var authresponse = await _identityService.LoginAsync(userRegistrationRequest.UserName, userRegistrationRequest.PassWord);

            if (!authresponse.Success)
            {
                return BadRequest(authresponse.ErrorMessage);
            }

            return Ok(authresponse);
        }


    }
}
