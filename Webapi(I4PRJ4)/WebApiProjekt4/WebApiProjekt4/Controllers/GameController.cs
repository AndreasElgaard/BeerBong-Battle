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
using WebApiProjekt4.Controllers.Responses;

namespace WebApiProjekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;
        private readonly IMapper Mapper_;

        public GameController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unitOfWork_ = unitOfWork;
            Mapper_ = mapper;
        }

        
        [HttpGet("/Get")]
        public async Task<ActionResult<IEnumerable<Game>>> GetAll()
        {
            var Games = await unitOfWork_.Game.GetAll();

            if(Games == null)
            {
                return NotFound();
            }

            return Ok(Mapper_.Map<List<GameResponse>>(Games));
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Game = await unitOfWork_.Game.Get(id);

            if(Game == null)
            {
                return BadRequest(new { message = "Userid does not exist" });
            }

            return Ok(Mapper_.Map<GameResponse>(Game));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post()
        {
            var game = new Game();

            try
            {
                
                await unitOfWork_.Game.Add(game);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Game Already exsist" });
            }


            return Ok(Mapper_.Map<GameResponse>(game));
        }

        
        [Route("AddRange")]
        [HttpPost]
        public async Task<IActionResult> PostRange(IEnumerable<Game> Games)
        {
            try
            {
                await unitOfWork_.Game.AddRange(Games);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Games Already exsist" });
            }


            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Delete(int gameId)
        {
            try
            {
                unitOfWork_.Game.Remove(gameId);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Game Didn't exsist" });
            }


            return Ok();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public IActionResult DeleteRange(IEnumerable<Game> Games)
        {
            try
            {
                unitOfWork_.Game.RemoveRange(Games);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Games doesn't' exists" });
            }


            return Ok();
        }

        [Route("AddPlayerToGame")]
        [HttpPost]
        public async Task<IActionResult> AddUsersToGame(int gameid, int player1id, int player2id)
        {

            var updatedgame = await unitOfWork_.Game.AddUserToGame(gameid, player1id, player2id);

            if(updatedgame == null)
            {
                return BadRequest(new { message = "The Id's don't' exists" });
            }

            unitOfWork_.Game.Update(updatedgame);
            await unitOfWork_.CompleteAsync();


            return Ok(Mapper_.Map<GameResponse>(updatedgame));
        }

        [Route("GetResult")]
        [HttpGet]
        public async Task<IActionResult> GetResult(int gameid)
        {
            var result = await unitOfWork_.Game.Winner(gameid);

            if(result == null)
            {
                return BadRequest(new { message = "Wrong GameId" });
            }

            return Ok(result);
        }
    }
}