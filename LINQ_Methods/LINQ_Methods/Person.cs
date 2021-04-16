using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Methods
{
    class Person
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
    }
}
