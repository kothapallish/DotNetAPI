using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    // Domain/Models/Person.cs
    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public Person(string name, string address)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Address = address;
        }
    }

}
