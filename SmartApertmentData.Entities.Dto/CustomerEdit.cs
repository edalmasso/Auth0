using System;
using System.Collections.Generic;
using System.Text;

namespace SmartApartmentData.Entities.Dto
{
    public class CustomerEdit
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int CustomerNumber { get; set; }

        public string PhoneNumber { get; set; }
    }
}
