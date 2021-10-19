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
    public class KdOcurrencesRepliesController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public KdOcurrencesRepliesController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/KdOcurrencesReplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KdOcurrencesReply>>> GetKdOcurrencesReplies()
        {
            return await _context.KdOcurrencesReplies.ToListAsync();
        }

        // GET: api/KdOcurrencesReplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KdOcurrencesReply>> GetKdOcurrencesReply(int id)
        {
            var kdOcurrencesReply = await _context.KdOcurrencesReplies.FindAsync(id);

            if (kdOcurrencesReply == null)
            {
                return NotFound();
            }

            return kdOcurrencesReply;
        }

        //// PUT: api/KdOcurrencesReplies/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutKdOcurrencesReply(int id, KdOcurrencesReply kdOcurrencesReply)
        //{
        //    if (id != kdOcurrencesReply.KdOcRpId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(kdOcurrencesReply).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!KdOcurrencesReplyExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/KdOcurrencesReplies
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<KdOcurrencesReply>> PostKdOcurrencesReply(KdOcurrencesReply kdOcurrencesReply)
        //{
        //    _context.KdOcurrencesReplies.Add(kdOcurrencesReply);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetKdOcurrencesReply", new { id = kdOcurrencesReply.KdOcRpId }, kdOcurrencesReply);
        //}

        //// DELETE: api/KdOcurrencesReplies/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteKdOcurrencesReply(int id)
        //{
        //    var kdOcurrencesReply = await _context.KdOcurrencesReplies.FindAsync(id);
        //    if (kdOcurrencesReply == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.KdOcurrencesReplies.Remove(kdOcurrencesReply);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool KdOcurrencesReplyExists(int id)
        {
            return _context.KdOcurrencesReplies.Any(e => e.KdOcRpId == id);
        }
    }
}
