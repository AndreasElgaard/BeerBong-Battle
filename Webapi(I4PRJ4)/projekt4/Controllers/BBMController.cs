using Microsoft.AspNetCore.Mvc;
using projekt4.Model;
using projekt4.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projekt4.Controllers
{
    [Route("api/[controller")]
    [ApiController]
    public abstract class BBMController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {

        protected readonly TRepository _repository;

        public BBMController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetOne(int id)
        {
            var model = await _repository.GetById(id);

            if(model == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity entity)
        {
            if(id != entity.Id)
            {
                return BadRequest();
            }

            await _repository.Update(entity);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity entity)
        {
            await _repository.Add(entity);
            return CreatedAtAction("Get", new { id = entity.Id }, entity);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if(entity == null)
            {
                return NotFound();
            }

            return entity;
        }

    }
}
