using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;

namespace INSAT._4I4U.TryShare.Core.Services.Tricycles
{
    public class TricyclesService : ITricyleService
    {
        private readonly IRepository<Tricycle> _tricycleRepository;

        public TricyclesService(IRepository<Tricycle> tricycleRepository)
        {
            _tricycleRepository = tricycleRepository;
        }

        public async Task<List<Tricycle>> GetAllAsync()
        {
            return (List<Tricycle>)await _tricycleRepository.GetAllAsync();
        }

        public async Task<Tricycle?> GetByIdAsync(int id)
        {
            return await _tricycleRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Tricycle tricycle)
        {
            await _tricycleRepository.CreateAsync(tricycle);
        }

        public async Task UpdateAsync(Tricycle tricycle)
        {
            await _tricycleRepository.UpdateAsync(tricycle);
        }

        public async Task DeleteAsync(Tricycle tricycle)
        {
            await _tricycleRepository.DeleteAsync(tricycle);
        }
    }
}
