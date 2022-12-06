using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INSAT._4I4U.TryShare.Infrastructure;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Infrastructure.Exceptions;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;

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
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetTricycle))]
        public async Task<ActionResult<Tricycle>> GetTricycle(int id)
        {
                var tri = await _service.GetByIdAsync(id);
                if (tri is null)
                    return NotFound();

                return tri;
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754        
        /// <summary>
        /// Updates the tricycle.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns></returns>
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Tricycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = nameof(PostTricycle))]
        public async Task<ActionResult<Tricycle>> PostTricycle(Tricycle tricycle)
        {
            try
            {
                await _service.CreateAsync(tricycle);
            }
            catch (NullDbSetException)
            {
                return Problem("Entity set 'ApplicationDbContext.Tricycles'  is null.");
            }

            return CreatedAtAction("GetTricycle", new { id = tricycle.Id }, tricycle);
        }

        // DELETE: api/Tricycles/5
        [HttpDelete("{id}", nameof(DeleteTricycle)]
        public async Task<IActionResult> DeleteTricycle(int id)
        {
            try
            {
                var tri = await _service.GetByIdAsync(id);
                if (tri is null)
                    return NotFound();

                await _service.DeleteAsync(tri);
            }
            catch (NullDbSetException)
            {
                return NotFound();
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}