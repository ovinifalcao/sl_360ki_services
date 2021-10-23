using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<ActionResult<BsUserResgistered>> PostBsUserResgistered(Models.Application.UserCreationAppInfo userCreationAppInfo)
        {
            _context.BsUserResgistereds.Add(userCreationAppInfo.bsUserResgistered);
            await _context.SaveChangesAsync();

            userCreationAppInfo.opUserService.UsrgdFk = userCreationAppInfo.bsUserResgistered.UsrgdId;
            _context.OpUserServices.Add(userCreationAppInfo.opUserService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBsUserResgistered", new { id = userCreationAppInfo.bsUserResgistered.UsrgdId }, userCreationAppInfo.bsUserResgistered);
        }

        private bool BsUserResgisteredExists(int id)
        {
            return _context.BsUserResgistereds.Any(e => e.UsrgdId == id);
        }
    }
}
