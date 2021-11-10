using Domain.Common;
using System;

namespace Domain.Customers
{
    public class Address : ValueObject
    {
        public Address(string state, string city, string town, string postalCode)
        {
            if (string.IsNullOrEmpty(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));

            State = state;
            City = city;
            Town = town;
            PostalCode = postalCode;
        }

        public string State { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
    }
}

