using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.app360ki_services.Models;
using Microsoft.AspNetCore.Authorization;

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

        [HttpPut("{id}")]
        [Authorize]
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

        [HttpPost]
        [Authorize]
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

        [HttpDelete("{id}")]
        [Authorize]
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
