using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using INSAT._4I4U.TryShare.Core.Exceptions;
using INSAT._4I4U.TryShare.Core.Interfaces.Evaluation;

namespace INSAT._4I4U.TryShare.Core.Services.Tricycles
{
    public class TricyclesService : ITricyleService
    {
        private readonly IRepository<Tricycle> _tricycleRepository;
        private readonly IEvaluationService _evaluationService;

        public TricyclesService(IRepository<Tricycle> tricycleRepository, IEvaluationService evaluationService)
        {
            _tricycleRepository = tricycleRepository;
            this._evaluationService = evaluationService;
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
            var tricycleDb = await _tricycleRepository.GetByIdAsync(tricycle.Id);
            if (tricycleDb is null)
                throw new TricycleNotFoundException();

            tricycleDb.IsAvailable = false;
            tricycleDb.Rating = _evaluationService.ComputeNewOverallRating(tricycleDb.Rating, tricycle.Rating);

            await _tricycleRepository.UpdateAsync(tricycleDb);
        }

        public Task RequestEndOfBookingAsync(Tricycle tricycle)
        {
            if (tricycle is null)
                throw new ArgumentNullException(nameof(tricycle));

            if (tricycle.IsAvailable)
                throw new InvalidOperationException("Tricycle is already available");

            return RequestTricycleEndOfBookingInternalAsync(tricycle);
        }

        private async Task RequestTricycleEndOfBookingInternalAsync(Tricycle tricycle)
        {
            var tricycleDb = await _tricycleRepository.GetByIdAsync(tricycle.Id);
            if (tricycleDb is null)
                throw new TricycleNotFoundException();

            tricycleDb.IsAvailable = true;
            tricycleDb.Rating = _evaluationService.ComputeNewOverallRating(tricycleDb.Rating, tricycle.Rating);

            await _tricycleRepository.UpdateAsync(tricycleDb);
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
