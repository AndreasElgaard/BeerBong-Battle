using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projekt4.EFCore;
using projekt4.Model;

namespace projekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaderBoardController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;

        public LeaderBoardController(IUnitOfWork unitOfWork)
        {
            unitOfWork_ = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<LeaderBoard> GetAll()
        {
            var LeaderBoarde = unitOfWork_.LeaderBoard.GetAll();

            return LeaderBoarde;
        }

        [HttpGet("{id}")]
        public LeaderBoard Get(int id)
        {
            var LeaderBoard = unitOfWork_.LeaderBoard.Get(id);

            return LeaderBoard;
        }

        [HttpPost]
        public void Post(LeaderBoard LeaderBoard)
        {
            unitOfWork_.LeaderBoard.Add(LeaderBoard);
            unitOfWork_.Complete();
        }

        [Route("AddRange")]
        [HttpPost]
        public void PostRange(IEnumerable<LeaderBoard> LeaderBoards)
        {
            unitOfWork_.LeaderBoard.AddRange(LeaderBoards);
            unitOfWork_.Complete();
        }

        [HttpDelete]
        public void Delete(LeaderBoard LeaderBoard)
        {
            unitOfWork_.LeaderBoard.Remove(LeaderBoard);
            unitOfWork_.Complete();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public void DeleteRange(IEnumerable<LeaderBoard> LeaderBoards)
        {
            unitOfWork_.LeaderBoard.RemoveRange(LeaderBoards);
            unitOfWork_.Complete();
        }
    }
}