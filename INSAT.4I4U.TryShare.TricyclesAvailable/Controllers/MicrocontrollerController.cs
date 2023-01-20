using INSAT._4I4U.TryShare.Core.Exceptions;
using INSAT._4I4U.TryShare.Core.Interfaces.Services;
using INSAT._4I4U.TryShare.Core.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace INSAT._4I4U.TryShare.TricyclesAvailable.Controllers
{
    /// <summary>
    /// Controller exposing enpoints dedicated to the embedded micocontroller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MicrocontrollerController : ControllerBase
    {
        private readonly IMicrocontrollerService _service;

        /// <summary>
        /// Instantiates the service
        /// </summary>
        /// <param name="service"></param>
        public MicrocontrollerController(IMicrocontrollerService service)
        {
            this._service = service;
        }

        /// <summary>
        /// Indicates updated information about the tricycle
        /// </summary>
        /// <param name="id">ID of the tricycle.</param>
        /// <param name="tricycle">The new information about the tricycle.</param>
        /// <returns></returns>
        [HttpPost("{id}/updateTricycleInformation", Name = nameof(UpdateTricycleInformation))]
        public async Task<ActionResult> UpdateTricycleInformation(int id, TricycleMicrocontrollerDto tricycle)
        {
            if (tricycle.Id != id)
                return BadRequest("The tricycle ID in the URL and the body do not match.");

            try
            {
                await _service.UpdateTricycleInfoAsync(tricycle);
            }
            catch (TricycleNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
