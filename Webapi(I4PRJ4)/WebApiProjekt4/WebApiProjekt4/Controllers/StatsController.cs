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
using WebApiProjekt4.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiProjekt4.Controllers.Requests;
using WebApiProjekt4.Controllers.Responses;

namespace WebApiProjekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StatsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;
        private readonly IMapper _mapper;
     
        public StatsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unitOfWork_ = unitOfWork;
            _mapper = mapper;
        }
     
     
        [HttpGet("Get")]
        public async Task<IActionResult> GetAll()
        {
            var Statss = await unitOfWork_.Stats.GetAll();
     
            if (Statss == null)
            {
                return NotFound();
            }
     
            return Ok(_mapper.Map<List<StatsResponse>>(Statss));
        }
     
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Stats = await unitOfWork_.Stats.Get(id);
     
            if (Stats == null)
            {
                return BadRequest(new { message = "Userid does not exist" });
            }
     
            return Ok(_mapper.Map<StatsResponse>(Stats));
        }
     
        [HttpPost("Add")]
        public async Task<IActionResult> Post(StatsRequest request)
        {
            try
            {
                var stats = _mapper.Map<Stats>(request);

                await unitOfWork_.Stats.Add(stats);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Player already exsist" });
            }

            return Ok(request);
        }
     
     
        [Route("AddRange")]
        [HttpPost]
        public async Task<IActionResult> PostRange(IEnumerable<Stats> stats)
        {
            try
            {
                await unitOfWork_.Stats.AddRange(stats);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Players already exsist" });
            }


            return Ok();
        }
     
        [HttpDelete("Remove")]
        public IActionResult Delete(int StatsId)
        {
            try
            {
                unitOfWork_.Stats.Remove(StatsId);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Player Didn't exsist" });
            }


            return Ok();
        }
     
        [Route("RemoveRange")]
        [HttpDelete]
        public IActionResult DeleteRange(IEnumerable<Stats> stats)
        {
            try
            {
                unitOfWork_.Stats.RemoveRange(stats);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Player Didn't exsist" });
            }


            return Ok();
        }
    }
}
