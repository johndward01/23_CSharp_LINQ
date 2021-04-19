using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            //Console.WriteLine(numbers.Sum());
            //Console.WriteLine(numbers.Average());
            ////------------------------------------------------------------------------------------------------------------------------------------------------

            ////Order numbers in ascending order and decsending order. Print each to console.
            //Console.WriteLine("Method Syntax");

            //var asc = numbers.OrderByDescending(num => num);

            //foreach (var num in asc)
            //{
            //    Console.WriteLine(num);
            //}


            //////Console.WriteLine("Query Syntax");
            //var x = from number in numbers
            //        orderby number descending
            //        select number;

            //foreach (var num in x)
            //{
            //    Console.WriteLine(num);
            //}


            //var desc = numbers.OrderByDescending(num => num);

            //foreach (var num in desc)
            //{
            //    Console.WriteLine(num);
            //}

            ////Console.WriteLine();
            ////------------------------------------------------------------------------------------------------------------------------------------------------

            ////Print to the console only the numbers greater than 6

            //var methodSyntaxExample2 = numbers.Where(x => x > 6);

            //foreach (var num in methodSyntaxExample2)
            //{
            //    Console.WriteLine(num);
            //}


            ////Console.WriteLine("Query Syntax");

            //var querySyntaxExample2 = from num in numbers
            //                          where num > 6
            //                          select num;

            //foreach (var num in querySyntaxExample2)
            //{
            //    Console.WriteLine(num);
            //}
            ////Console.WriteLine();
            ////------------------------------------------------------------------------------------------------------------------------------------------------

            ////Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            //Console.WriteLine("Method Syntax");


            //foreach (var num in numbers.Take(4).OrderBy(x => x))
            //{
            //    Console.WriteLine(num);
            //}



            ////Change the value at index 4 to your age, then print the numbers in decsending order

            //numbers[4] = 30; //This changes the 4th value for both examples 
            //numbers.SetValue(30, 4);
            //var age = numbers.Select((x,i) => i == 4 ? 30 : x);

            //foreach (var num in age)
            //{
            //    Console.WriteLine(num);
            //}


            //Console.WriteLine("Query Syntax");

            //var querySyntaxExample4 = from num in numbers
            //                          orderby num descending
            //                          select num;

            //foreach (var num in querySyntaxExample4)
            //{
            //    Console.WriteLine(num);
            //}
            //Console.WriteLine();
            //------------------------------------------------------------------------------------------------------------------------------------------------

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            ////Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            var firstName = employees.Where(name => (name.FirstName[0] == 'C' || name.FirstName[0] == 'S')).OrderBy(x => x.FirstName);
            //var firstName = employees.Where(name => name.FirstName.Contains('S') || name.FirstName.Contains('C')).OrderBy(x => x.FirstName);
            foreach (var name in firstName)
            {
                Console.WriteLine(name.FullName);
            }


            //------------------------------------------------------------------------------------------------------------------------

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            ////Order this by Age first and then by FirstName in the same result.
            ///
            //var over26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            //foreach (var age in over26)
            //{
            //    Console.WriteLine($"{age.FullName} {age.Age}");
            //}
            //------------------------------------------------------------------------------------------------------------------------




            ////------------------------------------------------------------------------------------------------------------------------

            ////Print the Sum and then the Average of the employees' YearsOfExperience 
            ////if their YOE is less than or equal to 10 AND Age is greater than 35
            //int yrsOfExp = 0;

            //var beginner = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);

            //foreach (var i in beginner)
            //{
            //    yrsOfExp += i.YearsOfExperience;
            //}
            //Console.WriteLine("YearsOfExperience: " + yrsOfExp);
            //Console.WriteLine("Average of YearsOfExperience: " + yrsOfExp / beginner.Count());
            ////------------------------------------------------------------------------------------------------------------------------

            //Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Jacky", "Chan", 11, 11)).ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
            





