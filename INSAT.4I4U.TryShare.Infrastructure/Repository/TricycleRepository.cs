using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Models.Base;
using INSAT._4I4U.TryShare.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Infrastructure.Repository
{
    public class TricycleRepository : IRepository<Tricycle>
    {
        private readonly ApplicationDbContext _context;

        public TricycleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Tricycle entity)
        {
            if (_context.Tricycles is null)
                throw new NullDbSetException(nameof(_context.Tricycles));

            _context.Tricycles.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Tricycle entity)
        {
            if (_context.Tricycles is null)
                throw new NullDbSetException(nameof(_context.Tricycles));

            var tricyle = await _context.Tricycles.FindAsync(entity.Id);
            if (tricyle is null)
                throw new EntityNotFoundException(nameof(Tricycle), entity.Id.ToString());

            _context.Tricycles.Remove(tricyle);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tricycle>> GetAllAsync()
        {
            if (_context.Tricycles is null)
                throw new NullDbSetException(nameof(_context.Tricycles));

            return await _context.Tricycles.ToListAsync();
        }

        public async Task<Tricycle?> GetByIdAsync(int id)
        {
            if (_context.Tricycles is null)
                throw new NullDbSetException(nameof(_context.Tricycles));

            var tricyle = await _context.Tricycles.FindAsync(id);

            return tricyle;
        }

        public async Task UpdateAsync(Tricycle entity)
        {
            if (_context.Tricycles is null)
                throw new NullDbSetException(nameof(_context.Tricycles));

            if (!TricycleExists(entity.Id))
                throw new EntityNotFoundException(nameof(Tricycle), entity.Id.ToString());

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        private bool TricycleExists(int id) =>
             (_context.Tricycles?.Any(e => e.Id == id)).GetValueOrDefault();

    }
}
