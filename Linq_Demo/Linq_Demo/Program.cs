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



            //Query Syntax
            //var dogsWithSpaces = from dog in stringList
            //                     where dog.Contains(" ")
            //                     orderby dog ascending
            //                     select dog;



            // Method Syntax
            var dogsWithSpaces = stringList.Where(x => x.Contains(" ")).OrderByDescending(x => x);

            foreach (var dog in dogsWithSpaces)
            {
                Console.WriteLine(dog);
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




            double[] doubleArray = new double[] { .001, .293, .887, .233, .922, .909, .534 };


            IList<string> strList = new List<string>() { "Mary", "Patrick", "Timothy", "Alan", "Tracy", "Cindy", "Robert", "Mike" };

            var names = strList.Where(x => x.StartsWith("M"));

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }


            int[] multiples = new[] { 1, 2, 2, 3, 1, 4, 5, 2, 9, 2 };

            





        }
    }
}
