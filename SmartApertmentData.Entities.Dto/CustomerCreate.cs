using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartmentData.Entities.Dto
{
    public class CustomerCreate
    {
        public string Company { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
