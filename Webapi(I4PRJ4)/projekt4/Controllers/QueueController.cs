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
    public class QueueController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;

        public QueueController(IUnitOfWork unitOfWork)
        {
            unitOfWork_ = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Queue> GetAll()
        {
            var Queuee = unitOfWork_.Queue.GetAll();

            return Queuee;
        }

        [HttpGet("{id}")]
        public Queue Get(int id)
        {
            var Queue = unitOfWork_.Queue.Get(id);

            return Queue;
        }

        [HttpPost]
        public void Post(Queue Queue)
        {
            unitOfWork_.Queue.Add(Queue);
            unitOfWork_.Complete();
        }

        [Route("AddRange")]
        [HttpPost]
        public void PostRange(IEnumerable<Queue> Queues)
        {
            unitOfWork_.Queue.AddRange(Queues);
            unitOfWork_.Complete();
        }

        [HttpDelete]
        public void Delete(Queue Queue)
        {
            unitOfWork_.Queue.Remove(Queue);
            unitOfWork_.Complete();
        }

        [Route("AddRange")]
        [HttpDelete]
        public void DeleteRange(IEnumerable<Queue> Queues)
        {
            unitOfWork_.Queue.RemoveRange(Queues);
            unitOfWork_.Complete();
        }
    }
}