using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.Core.Mappers
{
    public static class TricycleApplicationMapper
    {
        /// <summary>
        /// Model a new Tricycle model from a Application DTO. 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static Tricycle ToModel(this TricycleApplicationDto dto)
        {
            return new Tricycle
            {
                Id = dto.Id,
                LastKnownLatitude = dto.LastKnownLatitude,
                LastKnownLongitude = dto.LastKnownLongitude,
                Rating = dto.Rating
            };
        }
    }
}
