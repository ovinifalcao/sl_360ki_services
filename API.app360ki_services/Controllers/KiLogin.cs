using API.app360ki_services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.app360ki_services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KiLogin : ControllerBase
    {
        private readonly db_360ki_dataContext _context;

        public KiLogin(db_360ki_dataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authoziration(string phoneNum, string WSP)
        {
            var usr = await _context.OpUserServices.Where(Op => Op.PhoneNum == int.Parse(phoneNum) && Op.Wsp == WSP).ToListAsync();
            OpUserService serviceUser = usr.FirstOrDefault();
            BsUserResgistered fnUser = await _context.BsUserResgistereds.FindAsync(serviceUser.UsrgdFk);

            if (fnUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = Services.TokenServices.GenerateToken(fnUser);

            return new
            {
                user = fnUser.Name,
                userid = fnUser.UsrgdId,
                token = token
            };

        }
    }
}
