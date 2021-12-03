/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Email
    {
        private string privateEmail;
        private string businessEmail;

        public Email(string privateEmail, string businessEmail)
        {
            this.PrivateEmail = privateEmail;
            this.BusinessEmail = businessEmail;
        }

        public string PrivateEmail { get => privateEmail; set => privateEmail = value; }
        public string BusinessEmail { get => businessEmail; set => businessEmail = value; }
    }
}
