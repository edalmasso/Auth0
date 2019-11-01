using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentData.Api.Controllers
{
    /// <summary>
    /// Example of a not versioned controller.
    /// </summary>
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class NotVersionedController : ControllerBase
    {
        /// <summary>
        /// Show the message of a unsecured GET endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public ActionResult<string> Get()
        {
            return "Public Get for not versioned controller";
        }

        /// <summary>
        /// Returns the claims of the user
        /// </summary>
        /// <returns>List of claims</returns>
        [HttpGet("claims")]
        public IActionResult Claims()
        {
            return Ok(User.Claims.Select(c =>
                new
                {
                    c.Type,
                    c.Value
                }));
        }
    }
}
