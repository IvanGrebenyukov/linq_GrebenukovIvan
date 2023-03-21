using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_Grebenukov
{
    internal class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public Person(string lastName, string firstName, string middleName, int age, int weight)
        {
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName} {Age} {Weight}";
        }
    }
}
