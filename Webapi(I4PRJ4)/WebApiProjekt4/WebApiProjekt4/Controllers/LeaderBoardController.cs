using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiProjekt4.Controllers.Responses;

namespace we.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LeaderBoardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;
        private readonly IMapper _mapper;

        public LeaderBoardController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unitOfWork_ = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<LeaderBoard>>> GetAll()
        {
            var LeaderBoards = await unitOfWork_.LeaderBoard.GetAll();

            if(LeaderBoards == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<LeaderBoardResponse>>(LeaderBoards));
        }

        [HttpGet("Get/{Id}")]
        public async Task<ActionResult<LeaderBoard>> Get(int id)
        {
            var LeaderBoard = await unitOfWork_.LeaderBoard.Get(id);

            if(LeaderBoard == null)
            {
                return BadRequest(new { message = "Id does not exist" });
            }

            return Ok(_mapper.Map<LeaderBoardResponse>(LeaderBoard));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post(LeaderBoard LeaderBoard)
        {
            try
            {
                await unitOfWork_.LeaderBoard.Add(LeaderBoard);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "LeaderBoard Allready exsist" });
            }


            return Ok(LeaderBoard);
        }

        [Route("AddRange")]
        [HttpPost]
        public async Task<IActionResult> PostRange(IEnumerable<LeaderBoard> LeaderBoards)
        {
            try
            {
                await unitOfWork_.LeaderBoard.AddRange(LeaderBoards);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Players already exsist" });
            }


            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Delete(int LeaderBoardId)
        {
            try
            {
                unitOfWork_.LeaderBoard.Remove(LeaderBoardId);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Players already exsist" });
            }


            return Ok();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public IActionResult DeleteRange(IEnumerable<LeaderBoard> LeaderBoards)
        {
            try
            {
                unitOfWork_.LeaderBoard.RemoveRange(LeaderBoards);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Players already exsist" });
            }


            return Ok();
        }

        [Route("GetTopTimes")]
        [HttpGet]
        public IActionResult GetTopTimes()
        {

            return Ok();
        }

        [Route("InsertTopTimes")]
        [HttpPatch]
        public IActionResult InsertTopTimes(int Time)
        {


            return Ok();
        }
    }
}