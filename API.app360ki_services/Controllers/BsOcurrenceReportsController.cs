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
    public class BsOcurrenceReportsController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public BsOcurrenceReportsController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/BsOcurrenceReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BsOcurrenceReport>>> GetBsOcurrenceReports()
        {
            return await _context.BsOcurrenceReports.ToListAsync();
        }

        // GET: api/BsOcurrenceReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BsOcurrenceReport>> GetBsOcurrenceReport(int id)
        {
            var bsOcurrenceReport = await _context.BsOcurrenceReports.FindAsync(id);

            if (bsOcurrenceReport == null)
            {
                return NotFound();
            }

            return bsOcurrenceReport;
        }

        // PUT: api/BsOcurrenceReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBsOcurrenceReport(int id, BsOcurrenceReport bsOcurrenceReport)
        {
            if (id != bsOcurrenceReport.RptId)
            {
                return BadRequest();
            }

            _context.Entry(bsOcurrenceReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BsOcurrenceReportExists(id))
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

        // POST: api/BsOcurrenceReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BsOcurrenceReport>> PostBsOcurrenceReport(BsOcurrenceReport bsOcurrenceReport)
        {
            _context.BsOcurrenceReports.Add(bsOcurrenceReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBsOcurrenceReport", new { id = bsOcurrenceReport.RptId }, bsOcurrenceReport);
        }

        // DELETE: api/BsOcurrenceReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBsOcurrenceReport(int id)
        {
            var bsOcurrenceReport = await _context.BsOcurrenceReports.FindAsync(id);
            if (bsOcurrenceReport == null)
            {
                return NotFound();
            }

            _context.BsOcurrenceReports.Remove(bsOcurrenceReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BsOcurrenceReportExists(int id)
        {
            return _context.BsOcurrenceReports.Any(e => e.RptId == id);
        }
    }
}
