using INSAT._4I4U.TryShare.Core.Exceptions;
using INSAT._4I4U.TryShare.Core.Interfaces.Repository;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Services.Microcontroller
{
    public class MicrocontrollerService : IMicrocontrollerService
    {
        private readonly IRepository<Tricycle> _repository;

        public MicrocontrollerService(IRepository<Tricycle> repository)
        {
            this._repository = repository;
        }
        
        public async Task UpdateTricycleInfoAsync(TricycleMicrocontrollerDto tricycleDto)
        {
            var currentTricycle = await _repository.GetByIdAsync(tricycleDto.Id);
            if (currentTricycle is null)
                throw new TricycleNotFoundException();

            // Set the changed values from the DTO
            currentTricycle.BatteryPercentage = tricycleDto.BatteryPercentage;
            currentTricycle.LastKnownLatitude = tricycleDto.Latitude;
            currentTricycle.LastKnownLongitude = tricycleDto.Longitude;

            await _repository.UpdateAsync(currentTricycle);
        }
    }
}
