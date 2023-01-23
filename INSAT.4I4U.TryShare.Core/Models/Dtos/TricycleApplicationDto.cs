using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Models.Dtos
{
    public class TricycleApplicationDto
    {
        public int Id { get; set; }

        public double LastKnownLatitude { get; set; }

        public double LastKnownLongitude { get; set; }

        [Range(0, 5, ErrorMessage = "The rating must be between 0 and 5")]
        public int Rating { get; set; }
    }
}
