using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using INSAT._4I4U.TryShare.Infrastructure;
using INSAT._4I4U.TryShare.Core.Models;
using INSAT._4I4U.TryShare.Infrastructure.Exceptions;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Controllers
{
    /// <summary>
    /// Controller exposing the Tricycles API.
    /// </summary>
    /// <remarks>
    /// TODO: Change the endpoints to match the requirements.
    /// </remarks>
    /// <seealso cref="ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class TricyclesController : ControllerBase
    {
        private readonly ITricyleService _service;

        public TricyclesController(ITricyleService service)
        {
            _service = service;
        }

        /// <summary>
        /// Gets all the tricycles. 
        /// </summary>
        /// <returns>A list of all tricycles available</returns>
        [HttpGet(Name = nameof(GetTricycles))]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<Tricycle>>> GetTricycles()
        {
            return await _service.GetAllAsync();
        }




    }
}