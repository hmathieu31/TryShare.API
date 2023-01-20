using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Interfaces.Evaluation
{
    public interface IEvaluationService
    {
        /// <summary>
        /// Computes the new overall rating when a tricycle is posted (Request Booking / Leaving). 
        /// </summary>
        /// <param name="currentRating">Current rating for the tricycle</param>
        /// <param name="newRating">Rating for the new tricycle</param>
        /// <returns></returns>
        public int ComputeNewOverallRating(int currentRating, int newRating);
    }
}
