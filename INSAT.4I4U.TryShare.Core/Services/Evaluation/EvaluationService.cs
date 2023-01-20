using INSAT._4I4U.TryShare.Core.Interfaces.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Services.Evaluation
{
    public class EvaluationService : IEvaluationService
    {
        public int ComputeNewOverallRating(int currentRating, int newRating)
        {
            return (currentRating + newRating) / 2;
        }
    }
}
