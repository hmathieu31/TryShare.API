using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Interfaces.Services
{
    public interface IMicrocontrollerService
    {
        /// <summary>
        /// Update the tricycleDto position and battery percentage
        /// <see cref="TricycleMicrocontrollerDto"/>
        /// </summary>
        /// <param name="tricycleDto"></param>
        /// <returns></returns>
        Task UpdateTricycleInfoAsync(TricycleMicrocontrollerDto tricycleDto);
    }
}
