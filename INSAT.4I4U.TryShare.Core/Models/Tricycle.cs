using INSAT._4I4U.TryShare.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace INSAT._4I4U.TryShare.Core.Models
{
    /// <summary>
    /// A connected tricyle.
    /// LastKnownLocation is determined by LastKnownLongitude and LastKnownLatitude.
    /// TODO: Add range on latitude and longitude values
    /// </summary>
    public class Tricycle : EntityBase
    {
        public required double LastKnownLatitude { get; set; }
        public required double LastKnownLongitude { get; set; }

        [Range(0, 100, ErrorMessage = "The value must be a whole percentage")]
        public required int BatteryPercentage { get; set; }
        public required bool IsAvailable { get; set; }
    }
}