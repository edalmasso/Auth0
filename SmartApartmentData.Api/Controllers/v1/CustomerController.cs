using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SmartApartmentData.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Unsecured endpoint indicanting all the related companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string[]> CustomerCompanies()
        {
            return new string[] {
                "Smart Apartment Data",
                "Qualcom",
                "Endavours United"
            } ;
        }
    }
}
