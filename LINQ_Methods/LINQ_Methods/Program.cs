using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Methods
{
    class Program
    {
        public delegate decimal DecimalAverage(string[] arr);

        public static decimal GetDecimalAverge(string[] arr)
        {
            decimal avg = 0;
            var count = 0;

            foreach (var item in arr)
            {
                avg += Convert.ToDecimal(item);
                count++; 
            }
            return avg / count;
        }
         
        static void Main(string[] args)
        {
            // Data sources
            string[] names = { "John", "Jack", "joe", "Jeff", "JOHNNY", "Julie", "Jessica", "Jacky", "JILL" };
            int[] scores = { 90, 71, 82, 93, 75, 82, 75, 75, 75 };
            int[] scoreSet1 = { 73, 84, 62 };
            int[] scoreSet2 = { 57, 99, 86 };
            var scoresCopy = scores;
            Memory<int> destinationArray = new int[100];

            // Query Expression
            IEnumerable<int> scoreQuery = //query variable
                from score in scores //required
                where score > 80 // optional
                orderby score descending // optional
                select score; //must end with select or group

            // Execute the query to produce the results
            //foreach (int testScore in scoreQuery)
            //{
            //    Console.WriteLine(testScore);
            //}


            DecimalAverage del1 = GetDecimalAverge; // Delegate
            Func<int, bool> passing = (p => p >= 80); // Func
            Action<int[]> avg = x => Math.Floor(x.Average()); // Action
            Predicate<int[]> failed = x => x.Average() > 65; // Predicate

            var excellent = scores.Where(x => x >= 90);
            var seventyFives = scores.Where(x => x == 75);

            var tester = scores;
            var scores_Aggregate = scores.Aggregate((a, b) => a + b);
            var scores_All = scores.All(p => p >= 80);
            var scores_Any = scores.Any();
            var scores_Append = scores.Append(67);
            var scores_AsEnumerable = scoreSet1.AsEnumerable();
            var scores_AsMemory = scores.AsMemory();
            var scores_AsParallel = scores.AsParallel();
            var scores_AsQueryable = scores.AsQueryable();
            var scores_AsSpan = scores.AsSpan();
            var scores_Average1 = scores.Average();
            var scores_Case = scores.Cast<decimal>();
            var scores_Clone = scores.Clone();
            var scores_Concatenate = scores.Concat(scoreSet1);
            var scores_Contains = scores.Contains(79);
            scores.CopyTo(destinationArray);
            var scores_Count = scores.Count();
            var scores_DefaultOrEmpty = scores.DefaultIfEmpty();
            var scores_Distinct = scores.Distinct();
            var scores_ElementAt = scores.ElementAt(3); // will throw exception
            var scores_ElementAtOrDefault = scores.ElementAtOrDefault(3);
            var scores_Equals = scores.Equals(scoresCopy);
            var scores_Except = scores.Except(seventyFives);
            var scores_First = scores.First();
            var scores_GroupBy = scores.GroupBy(x => x);
            foreach (var score in scores_GroupBy)
            {                
                foreach (var x in score)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine();
            }
            // TODO: Finish the rest of the LINQ Methods similar to above

        }
    }
}
