using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Shared.Models
{
    /// <summary>
    /// A connected tricyle.
    /// LastKnownLocation is determined by LastKnownLongitude and LastKnownLatitude.
    /// </summary>
    public class Tricycle
    {
        public required int ID { get; set; }
        public required double LastKnownLatitude { get; set; }
        public required double LastKnownLongitude { get; set; }
        
        [Range(0, 100, ErrorMessage = "The value must be a whole percentage")]
        public required int BatteryPercentage { get; set; }
        public required bool IsAvailable { get; set; }
    }
}
