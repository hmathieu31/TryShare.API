using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using INSAT._4I4U.TryShare.Core.Exceptions;

namespace INSAT._4I4U.TryShare.Core.Services.Tricycles
{
    public class TricyclesService : ITricyleService
    {
        private readonly IRepository<Tricycle> _tricycleRepository;

        public TricyclesService(IRepository<Tricycle> tricycleRepository)
        {
            _tricycleRepository = tricycleRepository;
        }

        public async Task<List<Tricycle>> GetAvailableTricyclesAsync()
        {
            return (await _tricycleRepository.GetAllAsync())
                .Where(t => t.IsAvailable)
                .ToList();
        }

        public async Task<Tricycle?> GetByIdAsync(int id)
        {
            return await _tricycleRepository.GetByIdAsync(id);
        }

        public Task RequestTricycleBookingAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            if (!tricycle.IsAvailable)
                throw new TricycleNotAvailableException();

            return RequestTricycleBookingInternalAsync(tricycle);
        }

        private async Task RequestTricycleBookingInternalAsync(Tricycle tricycle)
        {
            tricycle.IsAvailable = false;
            await _tricycleRepository.UpdateAsync(tricycle);
        }

        public Task RequestEndOfBookingAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            if (tricycle.IsAvailable)
                throw new TricycleNotAvailableException();

            return RequestTricycleEndOfBookingInternalAsync(tricycle);
        }

        private async Task RequestTricycleEndOfBookingInternalAsync(Tricycle tricycle)
        {
            tricycle.IsAvailable = true;
            await _tricycleRepository.UpdateAsync(tricycle);
        }

        public Task SignalEnteringDangerZoneAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            return SignalEnteringDangerZoneInternalAsync(tricycle);
        }

        private async Task SignalEnteringDangerZoneInternalAsync(Tricycle tricycle)
        {
            tricycle.IsInDangerZone = true;
            await _tricycleRepository.UpdateAsync(tricycle);
        }

        public Task SignallLeavingDangerZoneAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            return SignalLeavingDangerZoneInternalAsync(tricycle);
        }

        private async Task SignalLeavingDangerZoneInternalAsync(Tricycle tricycle)
        {
            tricycle.IsInDangerZone = false;
            await _tricycleRepository.UpdateAsync(tricycle);
        }

        public async Task UpdateAsync(Tricycle tricycle)
        {
            await _tricycleRepository.UpdateAsync(tricycle);
        }
    }
}
