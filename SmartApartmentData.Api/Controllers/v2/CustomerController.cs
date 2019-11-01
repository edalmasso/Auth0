using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartApartmentData.Entities;
using SmartApartmentData.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartApartmentData.Api.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="customerCreate">Customer object with the required data.</param>
        /// <returns>Returns the created customer with aditional data</returns>
        [HttpPost]
        [Authorize(Policy = "create:customers")]
        public ActionResult<Customer> Create(CustomerCreate customerCreate)
        {
            // Real code should use a service to create the customer.
            var customer = new Customer()
            {
                Created = DateTime.Now,
                Company = customerCreate.Company,
                CustomerNumber = 100,
                Id = 10,
                FirstName = customerCreate.FirstName,
                LastUpdated = DateTime.Now,
                PhoneNumber = customerCreate.PhoneNumber,
                Surname = customerCreate.Surname
            };
            
            // Returns a customer with the aditional data generated after creation. Could also return only the new Id.
            return customer;
        }
    }
}
