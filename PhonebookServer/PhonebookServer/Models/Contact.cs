using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhonebookServer.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public override string ToString()
            => " Name: " + Name + " PhoneNumber: " + PhoneNumber + " ";

    }

}
