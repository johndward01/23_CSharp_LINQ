using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Linq_Demo
{
    class Program
    {


        static void Main(string[] args)
        {


            List<string> stringList = new List<string>()
            {
                "K 9",
                "Brian Griffin",
                "Scooby Doo",
                "Old Yeller",
                "Rin Tin Tin",
                "Rambo",
                "Lassie",
                "Snoopy"
            };

            var dogs = stringList.ToArray();

            //var dogsWithSpaces = dogs.Where(dog => dog.Contains(" ")).OrderBy(dog => dog);

            //foreach (var dog in dogsWithSpaces)
            //{
            //    Console.WriteLine(dog);
            //}

            //var dogsWithSpaces = from dog in dogs
            //                     where dog.Contains(" ") 
            //                     orderby dog descending 
            //                     select dog;

            //foreach (var dog in dogsWithSpaces)
            //{
            //    Console.WriteLine(dog);
            //}

            //var hasSpace = stringList.Contains(" ");
            //Console.WriteLine(hasSpace);





            //Query Syntax
            //var dogsWithSpaces = from dog in dogs
            //                     where dog.Contains('S') || dog.Contains('s')
            //                     orderby dog descending
            //                     select dog;

            //foreach (var dog in dogsWithSpaces)
            //{
            //    Console.WriteLine(dog);
            //}


            // Method Syntax
            //var dogsWithNoSpaces = dogs.Where(dog => !dog.Contains(" ")).OrderBy(dog => dog);
            //var dogsWithSpaces = dogs.Where(x => x.Contains(" ")).OrderByDescending(dog => dog);

            //foreach (var dog in dogsWithSpaces)
            //{
            //    Console.WriteLine(dog);
            //}




            //var employeeID = from emp in employeeList
            //                 orderby emp.ID
            //                 select emp;

            //var employeeLastName = employeeList.OrderBy(x => x.LastName);

            //foreach (var employee in employeeLastName)
            //{
            //    employee.PrintInfo();
            //}













            //var ordered = empList.OrderBy(x => x);

            //var add2Years = empList.Select(x => x.YearsOfExperience + 2);
            //foreach (var employee in ordered)
            //{
            //    Console.WriteLine(employee);
            //}
            var emp1 = new Employee("John", "Ward", 101, 43, 10);
            var emp2 = new Employee("Jon", "Brown", 102, 30, 9);
            var emp3 = new Employee("Jon", "Jon", 103, 28, 4);
            var emp4 = new Employee("Jack", "Smith", 201, 22, 11);

            var employeeList = new List<Employee>();
            employeeList.Add(emp1);
            employeeList.Add(emp2);
            employeeList.Add(emp3);
            employeeList.Add(emp4);


            var newEmployees = employeeList.Where(x => x.ID < 200 && x.ID >= 100 && x.YearsOfExperience > 10);
            foreach (var employee in newEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
            }

            //var over10Years = empList.Where(employee => employee.YearsOfExperience >= 10 && employee.FirstName != "John");

            var add1Year = employeeList.Where(x => x.YearsOfExperience < 10).Select(x => x.YearsOfExperience + 1);


            foreach (var employee in add1Year)
            {
                Console.WriteLine(employee);
            }

            // Method Syntax
            //List<string> animalNames = new List<string> { "fawn", "gibbon", "heron", "ibex", "jackalope" };

            //var birdNames = animalNames.Where(x => x.Contains('o'));

            //foreach (var bird in birdNames)
            //{
            //    Console.WriteLine(bird);
            //}

            //IEnumerable<int> intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //var sum = intList.Average();
            //Console.WriteLine(sum);




            //double[] doubleArray = new double[] { .001, .293, .887, .233, .922, .909, .534 };


            //IList<string> strList = new List<string>() { "Mary", "Patrick", "Timothy", "Alan", "Tracy", "Cindy", "Robert", "Mike" };

            //var names = strList.Where(x => x.StartsWith("M"));

            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}


            //int[] multiples = new[] { 1, 2, 2, 3, 1, 4, 5, 2, 9, 2 };







        }
    }
}
