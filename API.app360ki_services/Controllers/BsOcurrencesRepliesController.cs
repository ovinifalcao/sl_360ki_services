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
    public class BsOcurrencesRepliesController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public BsOcurrencesRepliesController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/BsOcurrencesReplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BsOcurrencesReply>>> GetBsOcurrencesReplies()
        {
            return await _context.BsOcurrencesReplies.ToListAsync();
        }

        // GET: api/BsOcurrencesReplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BsOcurrencesReply>> GetBsOcurrencesReply(int id)
        {
            var bsOcurrencesReply = await _context.BsOcurrencesReplies.FindAsync(id);

            if (bsOcurrencesReply == null)
            {
                return NotFound();
            }

            return bsOcurrencesReply;
        }

        // PUT: api/BsOcurrencesReplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBsOcurrencesReply(int id, BsOcurrencesReply bsOcurrencesReply)
        {
            if (id != bsOcurrencesReply.RptFk)
            {
                return BadRequest();
            }

            _context.Entry(bsOcurrencesReply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BsOcurrencesReplyExists(id))
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

        // POST: api/BsOcurrencesReplies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BsOcurrencesReply>> PostBsOcurrencesReply(BsOcurrencesReply bsOcurrencesReply)
        {
            _context.BsOcurrencesReplies.Add(bsOcurrencesReply);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BsOcurrencesReplyExists(bsOcurrencesReply.RptFk))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBsOcurrencesReply", new { id = bsOcurrencesReply.RptFk }, bsOcurrencesReply);
        }

        // DELETE: api/BsOcurrencesReplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBsOcurrencesReply(int id)
        {
            var bsOcurrencesReply = await _context.BsOcurrencesReplies.FindAsync(id);
            if (bsOcurrencesReply == null)
            {
                return NotFound();
            }

            _context.BsOcurrencesReplies.Remove(bsOcurrencesReply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BsOcurrencesReplyExists(int id)
        {
            return _context.BsOcurrencesReplies.Any(e => e.RptFk == id);
        }
    }
}
