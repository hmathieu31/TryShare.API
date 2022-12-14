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
        Task<List<Tricycle>> GetAllAsync();
        /// <summary>
        /// Requests the tricycle booking for a user
        /// </summary>
        /// <param name="tricycle">The tricycle.</param>
        /// <returns></returns>
        Task RequestTricycleBooking(Tricycle tricycle);
        Task RequestEndOfBooking();
    }
}
