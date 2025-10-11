using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Domain.ValueObjects
{
    public class AddressVO
    {
        public AddressVO(string zipCode, string street, string number, string neighborhood, string complement, string city, string state, string country, string hemisphere, string xCoordinate, string yCoordinate)
        {
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            Complement = complement;
            City = city;
            State = state;
            Country = country;
            Hemisphere = hemisphere;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }
        public string? ZipCode { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighborhood { get; set; }
        public string? Complement { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? Hemisphere { get; set; }
        public string? XCoordinate { get; set; }
        public string? YCoordinate { get; set; }
    }
}
