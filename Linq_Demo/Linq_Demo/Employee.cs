using System;
using System.Collections.Generic;
using System.Text;

namespace Linq_Demo
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }
        public double YearsOfExperience { get; set; }

        public Employee(string first, string last, int id, int age, double yearsOfExperience)
        {
            FirstName = first;
            LastName = last;
            ID = id;
            Age = age;
            YearsOfExperience = yearsOfExperience;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"FirstName: {FirstName}");
            Console.WriteLine($"LastName: {LastName}");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"YearsOfExperience: {YearsOfExperience}");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
