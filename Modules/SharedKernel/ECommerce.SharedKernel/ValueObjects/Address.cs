using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedKernel.ValueObjects
{
    public class Address
    {
        public string Country { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }

        private Address() { }
        public Address(string country, string city, string street, string zipCode)
        {
            if(string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is required.", nameof(country));
            if(string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required.", nameof(city));

            Country = country;
            City = city;
            Street = street;
            ZipCode = zipCode;
        }
        public override string ToString() => $"{Street}, {City}, {ZipCode}, {Country}";
        public override bool Equals(object? obj)
        {
            if (obj is not Address other) return false;
            return Country == other.Country && City == other.City && Street == other.Street && ZipCode == other.ZipCode;
        }

        public override int GetHashCode() => HashCode.Combine(Country, City, Street, ZipCode);

    }
}
