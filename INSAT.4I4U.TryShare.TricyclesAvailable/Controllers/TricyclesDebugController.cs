using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Controllers
{
    /// <summary>
    /// Controller used for debugging purposes of the tricycles
    /// </summary>
    /// <remarks>
    /// No authentication is required for these endpoints
    /// </remarks>
    [Route("api/[controller]")]
    [ApiController]
    public class TricycleDebugController : ControllerBase
    {
        private readonly IRepository<Tricycle> _repository;

        /// <summary>
        /// Create Debug controller using directly the tricycle repository
        /// </summary>
        /// <param name="repository"></param>
        public TricycleDebugController(IRepository<Tricycle> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// DEBUG
        /// Get all tricycles irrespective of any Business logic consideration in the database
        /// </summary>
        /// <returns>A list of tricycles</returns>
        [HttpGet(Name = nameof(DebugGetTricycles))]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Tricycle>>> DebugGetTricycles()
        {
            return (await _repository.GetAllAsync()).ToList();
        }

        /// <summary>
        /// DEBUG
        /// Get the data of the tricycle with given Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A Tricycle or Not Found if no item matching</returns>
        [HttpGet("{id}", Name = nameof(DebugGetTricycle))]
        [Produces("application/json")]
        public async Task<ActionResult<Tricycle>> DebugGetTricycle(int id)
        {
            var tricycle = await _repository.GetByIdAsync(id);
            if (tricycle is null)
                return NotFound();

            return tricycle;
        }

        /// <summary>
        /// DEBUG
        /// Updates the tricycle.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tricycle"></param>
        /// <returns></returns>
        [HttpPut("{id}", Name = nameof(DebugUpdateTricycle))]
        public async Task<IActionResult> DebugUpdateTricycle(int id, Tricycle tricycle)
        {
            if (id != tricycle.Id)
                return BadRequest();

            try
            {
                await _repository.UpdateAsync(tricycle);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repository.GetByIdAsync(id) is null)
                {
                    return NotFound(id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
    }
}
