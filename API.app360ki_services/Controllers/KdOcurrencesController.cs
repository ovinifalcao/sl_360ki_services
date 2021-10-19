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
    public class KdOcurrencesController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public KdOcurrencesController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/KdOcurrences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KdOcurrence>>> GetKdOcurrences()
        {
            return await _context.KdOcurrences.ToListAsync();
        }

        // GET: api/KdOcurrences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KdOcurrence>> GetKdOcurrence(int id)
        {
            var kdOcurrence = await _context.KdOcurrences.FindAsync(id);

            if (kdOcurrence == null)
            {
                return NotFound();
            }

            return kdOcurrence;
        }

    }
}
