using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt4.EFCore;
using projekt4.Model;


namespace projekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;

        public GameController(IUnitOfWork unitOfWork)
        {
            unitOfWork_ = unitOfWork;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAll()
        {
            var Games = unitOfWork_.Game.GetAll();

            if(Games == null)
            {
                return NotFound();
            }

            return Ok(Games);
        }

        [HttpGet("{id}")]
        public ActionResult<Game> Get(int id)
        {
            var Game = unitOfWork_.Game.Get(id);

            if(Game == null)
            {
                return BadRequest(new { message = "Userid does not exist" });
            }

            return Game;
        }

        [HttpPost]
        public IActionResult Post(Game Game)
        {
            try
            {
                unitOfWork_.Game.Add(Game);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Duplicate key" });
            }

            return Ok(Game);
        }

        
        [Route("AddRange")]
        [HttpPost]
        public void PostRange(IEnumerable<Game> Games)
        {
            unitOfWork_.Game.AddRange(Games);
            unitOfWork_.Complete();
        }

        [HttpDelete]
        public void Delete(Game Game)
        {
            unitOfWork_.Game.Remove(Game);
            unitOfWork_.Complete();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public void DeleteRange(IEnumerable<Game> Games)
        {
            unitOfWork_.Game.RemoveRange(Games);
            unitOfWork_.Complete();
        }
    }
}