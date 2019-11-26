using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProjekt4.Controllers.Responses;
using WebApiProjekt4.Data.EFCore;
using WebApiProjekt4.Data;
using WebApiProjekt4.Extensions;
using WebApiProjekt4.Services;

namespace WebApiProjekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlayersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;
        private readonly IMapper _mapper;

        public PlayersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unitOfWork_ = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Player>>> GetAll()
        {
            var Playere = await unitOfWork_.Player.GetAll();

            if(Playere == null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<PlayerResponse>>(Playere));
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var Player = await unitOfWork_.Player.Get(id);

            if(Player == null)
            {
                return BadRequest(new { message = "Id does not exists" });
            }

            return Ok(_mapper.Map<PlayerResponse>(Player));
        }

        
        [HttpPost("Add")]
        public async Task<IActionResult> Post()
        {

            var exists = await unitOfWork_.Player.DoesPlayerExists(HttpContext.GetUserId());

            if (!exists)
            {
                return BadRequest(new { message = "Player, with this login already exists, can't create new player" });
            }

            var newPlayer = new Player
            {
                UserId = HttpContext.GetUserId()
            };

            try
            {
                await unitOfWork_.Player.Add(newPlayer);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Player already exists" });
            }


            return Ok(_mapper.Map<PlayerResponse>(newPlayer));
        }

        [Route("AddRange")]
        [HttpPost]
        public async Task<IActionResult> PostRange(IEnumerable<Player> Players)
        {
            try
            {
                await unitOfWork_.Player.AddRange(Players);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "username or password allraedy exist" });
            }


            return Ok(Players);
            
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Delete(int Playerid)
        {
            var UserOwnsStats = await unitOfWork_.Player.PlayerOwnsStats(Playerid, HttpContext.GetUserId());

            if (!UserOwnsStats)
            {
                return BadRequest(new { message = "Player does now own Stats" });
            }

            try
            {
                unitOfWork_.Player.Remove(Playerid);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Player does not exsist" });
            }

            return Ok();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public IActionResult DeleteRange(IEnumerable<Player> Players)
        {
            try
            {
                unitOfWork_.Player.RemoveRange(Players);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Player does not exsist" });
            }

            return Ok(Players); 
        }

        [Route("AddStats")]
        [HttpPut]
        public async Task<IActionResult> AddStats(int playerId, int statsId)
        {
            var UserOwnsStats = await unitOfWork_.Player.PlayerOwnsStats(playerId, HttpContext.GetUserId());

            if(!UserOwnsStats)
            {
                return BadRequest(new { message = "Player does now own Stats" });
            }

            var updateplayer = await unitOfWork_.Player.AddStats(playerId, statsId);

            if(updateplayer == null)
            {
                return BadRequest(new { message = "PlayerId or StatsId does not exsist" });
            }


            unitOfWork_.Player.Update(updateplayer);
            await unitOfWork_.CompleteAsync();

            return Ok(_mapper.Map<PlayerResponse>(updateplayer));
        }

        [Route("GetStats")]
        [HttpGet]
        public async Task<IActionResult> GetStats(int playerId)
        {
            var UserOwnsStats = await unitOfWork_.Player.PlayerOwnsStats(playerId, HttpContext.GetUserId());

            if (!UserOwnsStats)
            {
                return BadRequest(new { message = "Player does now own Stats" });
            }

            var result = await unitOfWork_.Player.GetStats(playerId);

            if(result == null)
            {
                return BadRequest(new { message = "Player does not exsist" });
            }

            return Ok(result);
        }

    }
}