using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refleksje
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }

        [DisplayProperty("Postac Code")]
        public string PostalCode { get; set; }
    }
}
