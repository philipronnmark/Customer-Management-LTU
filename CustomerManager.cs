/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class CustomerManager
    {
        private List<Customer> customers = new List<Customer>();

        public CustomerManager()
        {
            this.Customers = customers;
        }

        internal List<Customer> Customers { get => customers; set => customers = value; }


        public void AddCustomer(Customer cust)
        {
            customers.Add(cust);
        }

        public void deleteCustomer(int i)
        {
            customers.RemoveAt(i);
        }
        public Customer getCustomer(int i)
        {
            return customers[i];
        }
    }
}
