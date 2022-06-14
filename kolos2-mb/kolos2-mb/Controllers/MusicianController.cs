using kolos2_mb.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace kolos2_mb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : ControllerBase
    {
        private readonly IMusicService _service;

        public MusicianController(IMusicService service)
        {
            _service = service;
        }

        [HttpPost("{IdMusician}")]
        public async Task<IActionResult> DeleteMuscian(int IdMusician)
        {
            return Ok();
        }
    }
}
