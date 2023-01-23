using INSAT._4I4U.TryShare.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace INSAT._4I4U.TryShare.Core.Models
{
    /// <summary>
    /// A connected tricyle.
    /// </summary>
    public class Tricycle : EntityBase
    {
        private const int MaximumPercentage = 100;

        public double LastKnownLatitude { get; set; }
        public double LastKnownLongitude { get; set; }

        [Range(0, MaximumPercentage, ErrorMessage = "The value must be a whole percentage")]
        public int BatteryPercentage { get; set; }
        public bool IsAvailable { get; set; }

        [Range(0, 5, ErrorMessage = "The value must be a whole number between 0 and 5")]
        public int Rating { get; set; }
        public bool IsInDangerZone { get; set; }
    }
}