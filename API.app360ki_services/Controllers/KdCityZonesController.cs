﻿using System;
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
    public class KdCityZonesController : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public KdCityZonesController(db_360ki_dataContext context)
        {
            _context = context;
        }

        // GET: api/KdCityZones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KdCityZone>>> GetKdCityZones()
        {
            return await _context.KdCityZones.ToListAsync();
        }

        // GET: api/KdCityZones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KdCityZone>> GetKdCityZone(int id)
        {
            var kdCityZone = await _context.KdCityZones.FindAsync(id);

            if (kdCityZone == null)
            {
                return NotFound();
            }

            return kdCityZone;
        }

    }
}
