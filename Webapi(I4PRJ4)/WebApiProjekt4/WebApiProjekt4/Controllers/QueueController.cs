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
using WebApiProjekt4.Data.Dto;

namespace we.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class QueueController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;
        private readonly IMapper _mapper;

        public QueueController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            unitOfWork_ = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Queue>>> GetAll()
        {
            var Queuee = await unitOfWork_.Queue.GetAll();

            if(Queuee == null)
            {
                return BadRequest(new { message = "No players Exsist" });
            }

            return Ok(_mapper.Map<List<QueueResponse>>(Queuee));
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Queue>> Get(int id)
        {
            var Queue = await unitOfWork_.Queue.Get(id);

            if(Queue == null)
            {
                return BadRequest(new { message = "Id is wrong" });
            }

            return Ok(_mapper.Map<QueueResponse>(Queue));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Post(Queue Queue)
        {
            try
            {
                await unitOfWork_.Queue.Add(Queue);
                await unitOfWork_.CompleteAsync();
            }
            catch
            {
                return BadRequest(new { message = "Player already exsist" });
            }


            return Ok(Queue);
        }


        [HttpDelete("Remove")]
        public IActionResult Delete(int queueid)
        {
            try
            {
                unitOfWork_.Queue.Remove(queueid);
                unitOfWork_.Complete();
            }
            catch
            {
                return BadRequest(new { message = "Player already exsist" });
            }

            return Ok();
        }

        [HttpPost("AddPlayer")]
        public async Task<IActionResult> AddUser(int PlayerId)
        {
            var updatedqueue = await unitOfWork_.Queue.AddUser(PlayerId);

            if(updatedqueue == null)
            {
                return BadRequest(new { message = "Player Id doesn't exsist" });
            }

            
            unitOfWork_.Queue.Update(updatedqueue);
            await unitOfWork_.CompleteAsync();

            return Ok(_mapper.Map<QueueResponse>(updatedqueue));
        }

        [HttpGet("GetFirstPlayer")]
        public async Task<ActionResult<GetFirstPlayerResult>> GetPlayers()
        {
            var Players = await unitOfWork_.Queue.GetUser();

            if(Players == null)
            {
                return BadRequest(new { message = "No Players in Queue" });
            }

            return Ok(Players);
        }

        [HttpPut("RemovePlayer")]
        public async Task<IActionResult> RemovePlayer(int playerId)
        {
            var updatedQueue = await unitOfWork_.Queue.RemovePlayer(playerId);

            if(updatedQueue == null)
            {
                return BadRequest(new { message = "Something Went Wrong" });
            }

            unitOfWork_.Queue.Update(updatedQueue);
            await unitOfWork_.CompleteAsync();

            return Ok(_mapper.Map<QueueResponse>(updatedQueue));
        }
    }
}