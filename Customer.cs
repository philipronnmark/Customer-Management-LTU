/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Customer
    {
        private Contact contact;

        public Customer(Contact contact)
        {
            this.Contact = contact;
        }

        internal Contact Contact { get => contact; set => contact = value; }

        /// <summary>
        /// Shortens the GUID, or any string
        /// Source: https://newbedev.com/can-maximum-number-of-characters-be-defined-in-c-format-strings-like-in-c-printf
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string MaxLength(string input, int length)
        {
            if (input == null) return null;
            return input.Substring(0, Math.Min(length, input.Length));
        }
        public override string ToString()
        {
          
            return string.Format("{0}",  MaxLength(contact.Id.ToString(), 3)).PadRight(9) + " " + contact.FirstName.PadRight(15) + " " + contact.Phone.CellPhone.PadRight(19) + " " + contact.Email.BusinessEmail.PadRight(19); 
        }
    }
}
