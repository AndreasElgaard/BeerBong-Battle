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
    public class ParticipantsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork_;

        public ParticipantsController(IUnitOfWork unitOfWork)
        {
            unitOfWork_ = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Participant> GetAll()
        {
            var Participante = unitOfWork_.Participant.GetAll();

            return Participante;
        }

        [HttpGet("{id}")]
        public Participant Get(int id)
        {
            var Participant = unitOfWork_.Participant.Get(id);

            return Participant;
        }

        [HttpPost]
        public void Post(Participant Participant)
        {
            unitOfWork_.Participant.Add(Participant);
            unitOfWork_.Complete();
        }

        [Route("AddRange")]
        [HttpPost]
        public void PostRange(IEnumerable<Participant> Participants)
        {
            unitOfWork_.Participant.AddRange(Participants);
            unitOfWork_.Complete();
        }

        [HttpDelete]
        public void Delete(Participant Participant)
        {
            unitOfWork_.Participant.Remove(Participant);
            unitOfWork_.Complete();
        }

        [Route("RemoveRange")]
        [HttpDelete]
        public void DeleteRange(IEnumerable<Participant> Participants)
        {
            unitOfWork_.Participant.RemoveRange(Participants);
            unitOfWork_.Complete();
        }
    }
}