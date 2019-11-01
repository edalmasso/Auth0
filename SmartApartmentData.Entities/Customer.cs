using System;

namespace SmartApartmentData.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int CustomerNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string Company { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
