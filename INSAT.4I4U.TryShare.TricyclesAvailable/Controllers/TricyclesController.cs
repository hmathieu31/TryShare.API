using Microsoft.AspNetCore.Mvc;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Exceptions;
using INSAT._4I4U.TryShare.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Controllers
{
    /// <summary>
    /// Controller exposing the Tricycles API.
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TricyclesController : ControllerBase
    {
        private readonly ITricyleService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TricyclesController"/> class.
        /// </summary>
        /// <param name="service">The service operating on Tricycles.</param>
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
        [Produces("application/json")]
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
        [HttpPost("{id}/requestBooking", Name = nameof(RequestTricycleBooking))]
        public async Task<ActionResult> RequestTricycleBooking(int id)
        {
            var tricycle = await _service.GetByIdAsync(id);
            if (tricycle is null)
                return NotFound(id);

            try
            {
                await _service.RequestTricycleBookingAsync(tricycle);
                return Ok();
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

        /// <summary>
        /// Signals the tricycle entering a danger zone.
        /// </summary>
        /// <param name="id">The ID of the tricycle.</param>
        /// <returns></returns>
        [HttpPost("{id}/signalDanger", Name = nameof(SignalEnteringDangerZone))]
        public async Task<ActionResult> SignalEnteringDangerZone(int id)
        {
            var tricycle = await _service.GetByIdAsync(id);
            if (tricycle is null)
                return NotFound(id);

            try
            {
                await _service.SignalEnteringDangerZoneAsync(tricycle);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound(id);
            }
        }

        /// <summary>
        /// Signals the tricycle is leaving a danger zone.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}/signalDangerEnd", Name = nameof(SignalLeavingDangerZone))]
        public async Task<ActionResult> SignalLeavingDangerZone(int id)
        {
            var tricycle = await _service.GetByIdAsync(id);
            if (tricycle is null)
                return NotFound(id);

            try
            {
                await _service.SignallLeavingDangerZoneAsync(tricycle);
                return Ok();
            }
            catch (EntityNotFoundException)
            {
                return NotFound(id);
            }
        }

        /// <summary>
        /// Updates the tricycle.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns></returns>
        /// <remarks>Test method to be deleted</remarks>
        [HttpPut("{id}", Name = nameof(UpdateTricycle))]
        public async Task<IActionResult> UpdateTricycle(int id, Tricycle tricycle)
        {
            if (id != tricycle.Id)
                return BadRequest();

            try
            {
                await _service.UpdateAsync(tricycle);
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _service.GetByIdAsync(id) is null)
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