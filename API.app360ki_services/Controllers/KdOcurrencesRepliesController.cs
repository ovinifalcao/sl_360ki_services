using System.Collections.Generic;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KdOcurrencesReply>>> GetKdOcurrencesReplies()
        {
            return await _context.KdOcurrencesReplies.ToListAsync();
        }

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
    }
}
