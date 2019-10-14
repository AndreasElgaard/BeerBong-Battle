using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt4.Model;
using projekt4.Data;

namespace projekt4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrugersController : ControllerBase
    {
        private readonly IBrugerService _brugerService;

        public BrugersController(IBrugerService brugerService)
        {
            _brugerService = brugerService ?? throw new ArgumentNullException(nameof(brugerService)); // Hvis der gives et null med castes vores exception
        }


        [HttpGet]

        public void CoolMethod()
        {
            _brugerService.DoSomething();
        }


        // GET: api/Brugers
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<Bruger>>> GetBruger()
        //        {
        //            return await _context.Bruger.ToListAsync();
        //        }

        //        // GET: api/Brugers/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Bruger>> GetBruger(int id)
        //        {
        //            var bruger = await _context.Bruger.FindAsync(id);

        //            if (bruger == null)
        //            {
        //                return NotFound();
        //            }

        //            return bruger;
        //        }

        //        // PUT: api/Brugers/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //        // more details see https://aka.ms/RazorPagesCRUD.
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutBruger(int id, Bruger bruger)
        //        {
        //            if (id != bruger.Id)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(bruger).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BrugerExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Brugers
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //        // more details see https://aka.ms/RazorPagesCRUD.
        //        [HttpPost]
        //        public async Task<ActionResult<Bruger>> PostBruger(Bruger bruger)
        //        {
        //            _context.Bruger.Add(bruger);
        //            await _context.SaveChangesAsync();

        //            return CreatedAtAction("GetBruger", new { id = bruger.Id }, bruger);
        //        }

        //        // DELETE: api/Brugers/5
        //        [HttpDelete("{id}")]
        //        public async Task<ActionResult<Bruger>> DeleteBruger(int id)
        //        {
        //            var bruger = await _context.Bruger.FindAsync(id);
        //            if (bruger == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Bruger.Remove(bruger);
        //            await _context.SaveChangesAsync();

        //            return bruger;
        //        }

        //        private bool BrugerExists(int id)
        //        {
        //            return _context.Bruger.Any(e => e.Id == id);
        //        }
    }
}
