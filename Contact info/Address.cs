/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Address
    {
        private string addressName;
        private string cityName;
        private string zipCode;
        private string country;



        public Address(string addressName) : this(addressName,"", "","")
        {
            this.addressName = addressName;


        }

        public Address(string addressName, string cityName):this(addressName, cityName, "", "")
        {
            this.addressName = addressName;
            this.cityName = cityName;


        }

        public Address(string addressName, string cityName, string zipCode, string country)
        {
            this.addressName = addressName;
            this.cityName = cityName;
            this.zipCode = zipCode;
            this.country = country;
        }

        public string AddressName { get => addressName; set => addressName = value; }
        public string CityName { get => cityName; set => cityName = value; }
        public string ZipCode { get => zipCode; set => zipCode = value; }
        public string Country { get => country; set => country = value; }
    }
}
