using INSAT._4I4U.TryShare.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Interfaces.Services
{
    public interface ITricyleService
    {
        /// <summary>
        /// Get all currently available tricycles.
        /// </summary>
        /// <returns></returns>
        Task<List<Tricycle>> GetAvailableTricyclesAsync();
        /// <summary>
        /// Gets the tricycle by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Tricycle?> GetByIdAsync(int id);
        /// <summary>
        /// Requests the tricycle booking for a user
        /// </summary>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns></returns>
        Task RequestTricycleBookingAsync(Tricycle tricycle);
        /// <summary>
        /// Requests the end of booking.
        /// </summary>
        /// <returns></returns>
        Task RequestEndOfBookingAsync(Tricycle tricycle);
        /// <summary>
        /// Signals that the tricycle is entering danger zone.
        /// </summary>
        /// <param name="tricycle">The tricycle entering a danger zone.</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException" />
        Task SignalEnteringDangerZoneAsync(Tricycle tricycle);
        /// <summary>
        /// Signals that the tricycle is leaving a danger zone
        /// </summary>
        /// <param name="tricycle">The tricycle leaving the danger zone.</param>
        /// <returns></returns>
        Task SignallLeavingDangerZoneAsync(Tricycle tricycle);

        Task UpdateAsync(Tricycle tricycle);

    }
}
