using Microsoft.AspNetCore.Mvc;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Exceptions;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Controllers
{
    /// <summary>
    /// Controller exposing the Tricycles API.
    /// </summary>
    /// <remarks>
    /// TODO: Change the endpoints to match the requirements.
    /// </remarks>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class TricyclesController : ControllerBase
    {
        private readonly ITricyleService _service;

        public TricyclesController(ITricyleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all the tricycles. 
        /// </summary>
        /// <returns>A list of all tricycles available</returns>
        [HttpGet(Name = nameof(GetTricycles))]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Tricycle>>> GetTricycles()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Gets the tricycle.
        /// </summary>
        /// <param name="id">The ID of the tricycle.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetTricycle))]
        public async Task<ActionResult<Tricycle>> GetTricycle(int id)
        {
            var tricycle = await _service.GetByIdAsync(id);

            if (tricycle is null)
                return NotFound();

            return Ok(tricycle);
        }

        /// <summary>
        /// Requests the start of the booking for a tricycle.
        /// </summary>
        /// <param name="id">The identifier of the tricycle.</param>
        /// <returns></returns>
        [HttpPost("{id}/requestBooking",Name = nameof(RequestTricycleBooking))]
        public async Task<ActionResult> RequestTricycleBooking(int id)
        {
            var tricycle = await _service.GetByIdAsync(id);
            if (tricycle is null)
                return NotFound(id);

            try
            {
                await _service.RequestTricycleBookingAsync(tricycle);
                return Ok(tricycle);
            }
            catch (ArgumentNullException)
            {
                return NotFound(id);
            }
            catch (TricycleNotAvailableException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}