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

        // GET: api/Tricycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tricycle>>> GetTricycles()
        {
            try
            {
                return await _service.GetAllAsync();
            }
            catch (NullDbSetException)
            {
                return NotFound();
            }
        }

        // GET: api/Tricycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tricycle>> GetTricycle(int id)
        {
            try
            {
                var tri = await _service.GetByIdAsync(id);
                if (tri is null)
                    return NotFound();

                return tri;
            }
            catch (NullDbSetException)
            {

                return NotFound();
            }
        }

        // PUT: api/Tricycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTricycle(int id, Tricycle tricycle)
        {
            if (id != tricycle.Id)
                return BadRequest();

            try
            {
                await _service.UpdateAsync(tricycle);
            }
            catch (NullDbSetException)
            {
                return NotFound();
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
        [HttpPost]
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
        [HttpDelete("{id}")]
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