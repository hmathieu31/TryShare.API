using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Models.Dtos
{
    public class TricycleMicrocontrollerDto
    {
        public int Id { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Range(0, 100)]
        public int BatteryPercentage { get; set; }
    }
}
