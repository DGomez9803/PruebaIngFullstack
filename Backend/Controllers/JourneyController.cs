using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class JourneyController : Controller
    {

        private IJourney _process;

        private readonly ILogger<JourneyController> _logger;

        public JourneyController(IJourney process, ILogger<JourneyController> logger)
        {
            _logger = logger;
            _process = process;
        }
        [HttpGet("GetJourney/{origin}/{destination}")]
        [ProducesResponseType(typeof( JourneyDto ), StatusCodes.Status200OK)]
        [ProducesResponseType( StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult< JourneyDto > GetJourney(string origin, string destination)
        {
            try
            {
                var Journey = _process.GetJourney(origin, destination);

                if (Journey != null)
                {
                    return Ok(Journey);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                Random random = new Random();
                int id = random.Next();
                _logger.LogError("Error consuming service id=" + id, ex) ;
                return StatusCode(500, "Error consuming service id=" + id);
            }
        }
    }
}
