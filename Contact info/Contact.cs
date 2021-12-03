/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A5
{
    class Contact
    {
        private Guid id;
        private string firstName;
        private string lastName;
        private Phone phone;
        private Email email;
        private Address address;

        
        public Contact( string firstName, string lastName, Phone phone, Email email, Address address)
        {
            if (CheckData(firstName, lastName, address))
            {

                Id = Guid.NewGuid();
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Phone = phone;
                this.Email = email;
                this.Address = address;
            } else { throw new ArgumentException("Parameter cannot be null"); }
        }

        /// <summary>
        /// Returns true if fields contain data
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool CheckData(string firstName, string lastName, Address address)
        {
            if((!string.IsNullOrEmpty(firstName) || !string.IsNullOrEmpty(lastName)) && !string.IsNullOrEmpty(address.CityName) && !string.IsNullOrEmpty(address.Country))
            {
                return true;
            }

            return false;
                
        }
        /// <summary>
        /// Write method Contact Class CheckData()
        /// </summary>
        public Guid Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        internal Phone Phone { get => phone; set => phone = value; }
        internal Email Email { get => email; set => email = value; }
        internal Address Address { get => address; set => address = value; }
    }
}
