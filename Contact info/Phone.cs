/// Philip Rönnmark 990513-4392 2021-12-01
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5
{
    class Phone
    {
        private string homePhone;
        private string cellPhone;

        public Phone(string homePhone, string cellPhone)
        {
            this.homePhone = homePhone;
            this.cellPhone = cellPhone;
        }

        public string HomePhone { get => homePhone; set => homePhone = value; }
        public string CellPhone { get => cellPhone; set => cellPhone = value; }
    }

}