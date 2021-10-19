using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.app360ki_services.Models;

namespace API.app360ki_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BsUserResgisteredsController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public BsUserResgisteredsController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/BsUserResgistereds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BsUserResgistered>>> GetBsUserResgistereds()
        {
            return await _context.BsUserResgistereds.ToListAsync();
        }

        // GET: api/BsUserResgistereds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BsUserResgistered>> GetBsUserResgistered(int id)
        {
            var bsUserResgistered = await _context.BsUserResgistereds.FindAsync(id);

            if (bsUserResgistered == null)
            {
                return NotFound();
            }

            return bsUserResgistered;
        }

        // PUT: api/BsUserResgistereds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBsUserResgistered(int id, BsUserResgistered bsUserResgistered)
        {
            if (id != bsUserResgistered.UsrgdId)
            {
                return BadRequest();
            }

            _context.Entry(bsUserResgistered).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BsUserResgisteredExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BsUserResgistereds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BsUserResgistered>> PostBsUserResgistered(BsUserResgistered bsUserResgistered)
        {
            _context.BsUserResgistereds.Add(bsUserResgistered);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBsUserResgistered", new { id = bsUserResgistered.UsrgdId }, bsUserResgistered);
        }

        // DELETE: api/BsUserResgistereds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBsUserResgistered(int id)
        {
            var bsUserResgistered = await _context.BsUserResgistereds.FindAsync(id);
            if (bsUserResgistered == null)
            {
                return NotFound();
            }

            _context.BsUserResgistereds.Remove(bsUserResgistered);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BsUserResgisteredExists(int id)
        {
            return _context.BsUserResgistereds.Any(e => e.UsrgdId == id);
        }
    }
}
