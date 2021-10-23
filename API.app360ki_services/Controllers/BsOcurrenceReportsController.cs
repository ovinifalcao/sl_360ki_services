using System.Collections.Generic;
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
    public class BsOcurrenceReportsController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public BsOcurrenceReportsController(db_360ki_dataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Models.Application.ReportsAppInfo>>> GetBsOcurrenceReports()
        {
            //await _context.BsOcurrenceReports.ToListAsync();
            var reports = await _context.BsOcurrenceReports.ToListAsync();
            var replies = await (from rp in _context.BsOcurrencesReplies
                                 group rp by rp.RptFk into rp_Gp
                                 select new
                                 {
                                     Report_Id = rp_Gp.Key,
                                     Replies = new List<Models.Application.RepliesAppInfo>()
                                     {
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 1,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 1)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 2,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 2)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 3,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 3)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 4,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 4)
                                         }
                                     }
                                 }).ToListAsync();
            return (from rpt in reports
                    join rpl in replies
                    on rpt.RptId equals rpl.Report_Id
                    select new Models.Application.ReportsAppInfo
                    {
                        Report = rpt,
                        Replies = rpl.Replies
                    }).ToList();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Models.Application.ReportsAppInfo>> GetBsOcurrenceReport(int id)
        {
            var bsOcurrenceReport = await _context.BsOcurrenceReports.FindAsync(id);
            if (bsOcurrenceReport == null) return NotFound();


            var replies = await (from rp in _context.BsOcurrencesReplies
                                 where rp.RptFk == id
                                 group rp by rp.RptFk into rp_Gp
                                 select new List<Models.Application.RepliesAppInfo>()
                                 {
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 1,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 1)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 2,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 2)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 3,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 3)
                                         },
                                         new Models.Application.RepliesAppInfo()
                                         {
                                            Reply_Type = 4,
                                            Reply_Quantity = rp_Gp.Count(g => g.KindId == 4)
                                         }
                                 }).ToListAsync();

            return new Models.Application.ReportsAppInfo
            {
                Report = bsOcurrenceReport,
                Replies = replies.FirstOrDefault()
            };
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<BsOcurrenceReport>> PostBsOcurrenceReport(BsOcurrenceReport bsOcurrenceReport)
        {
            _context.BsOcurrenceReports.Add(bsOcurrenceReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBsOcurrenceReport", new { id = bsOcurrenceReport.RptId }, bsOcurrenceReport);
        }

        [HttpDelete("{id},{userId}")]
        [Authorize]
        public async Task<IActionResult> DeleteBsOcurrenceReport(int id, int userId)
        {
            var bsOcurrenceReport = await _context.BsOcurrenceReports.FindAsync(id);
            if (bsOcurrenceReport == null && bsOcurrenceReport.UsrgdOwnerFk == userId)
            {
                return NotFound();
            }

            _context.BsOcurrenceReports.Remove(bsOcurrenceReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
