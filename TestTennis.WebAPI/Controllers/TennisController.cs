using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTennis.Application.DTOs;
using TestTennis.Application.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestTennis.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TennisController : Controller
    {
        private readonly IReadOnlyTennisRepository _readOnlyTennisRepository;
        private readonly IWriteOnlyTennisRepository _writeOnlyTennisRepository;

        public TennisController(IReadOnlyTennisRepository readOnlyTennisRepository,
                                IWriteOnlyTennisRepository writeOnlyTennisRepository)
        {
            _readOnlyTennisRepository = readOnlyTennisRepository;
            _writeOnlyTennisRepository = writeOnlyTennisRepository;
        }

        /// <summary>
        /// Gets all players
        /// </summary>
        /// <returns>Players</returns>
        /// <response code="20O">Returns players</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> Get()
        {
            return await _readOnlyTennisRepository.FindAll();
        }

        /// <summary>
        /// Gets specific player
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Player</returns>
        /// <response code="20O">Returns player</response>
        /// <response code="404">If player doesn't exist</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> Get(int id)
        {
            var player = await _readOnlyTennisRepository.FindById(id);
            if (player == null)
                return NotFound();

            return await _readOnlyTennisRepository.FindById(id);
        }

        /// <summary>
        /// Deletes a specific player.
        /// </summary>
        /// <param name="id"></param>
        /// <response code="20O">OK</response>
        /// <response code="404">If player doesn't exist</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _writeOnlyTennisRepository.Delete(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
