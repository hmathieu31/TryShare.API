using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INSAT._4I4U.TryShare.Infrastructure;
using INSAT._4I4U.TryShare.Core.Models;

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
        private readonly ApplicationDbContext _context;

        public TricyclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tricycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tricycle>>> GetTricycles()
        {
            if (_context.Tricycles == null)
            {
                return NotFound();
            }
            return await _context.Tricycles.ToListAsync();
        }

        // GET: api/Tricycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tricycle>> GetTricycle(int id)
        {
            if (_context.Tricycles == null)
            {
                return NotFound();
            }
            var tricycle = await _context.Tricycles.FindAsync(id);

            if (tricycle == null)
            {
                return NotFound();
            }

            return tricycle;
        }

        // PUT: api/Tricycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTricycle(int id, Tricycle tricycle)
        {
            if (id != tricycle.ID)
            {
                return BadRequest();
            }

            _context.Entry(tricycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TricycleExists(id))
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
            if (_context.Tricycles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tricycles'  is null.");
            }
            _context.Tricycles.Add(tricycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTricycle", new { id = tricycle.ID }, tricycle);
        }

        // DELETE: api/Tricycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTricycle(int id)
        {
            if (_context.Tricycles == null)
            {
                return NotFound();
            }
            var tricycle = await _context.Tricycles.FindAsync(id);
            if (tricycle == null)
            {
                return NotFound();
            }

            _context.Tricycles.Remove(tricycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TricycleExists(int id)
        {
            return (_context.Tricycles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}