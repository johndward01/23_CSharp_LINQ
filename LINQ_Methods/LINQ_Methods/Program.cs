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
            int[] scoresCopy = scores;
            Memory<int> destinationArray = new int[100];
            List<Student> studentList = new()
            {
                new Student() { StudentID = 1, StudentName = "John", StandardID = 1 },
                new Student() { StudentID = 2, StudentName = "Moin", StandardID = 1 },
                new Student() { StudentID = 3, StudentName = "Bill", StandardID = 2 },
                new Student() { StudentID = 4, StudentName = "Ram", StandardID = 2 },
                new Student() { StudentID = 5, StudentName = "Ron" }
            };
            List<Standard> standardList = new List<Standard>()
            {
                new Standard(){ StandardID = 1, StandardName="Standard 1"},
                new Standard(){ StandardID = 2, StandardName="Standard 2"},
                new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                { 1, "John" },
                { 2, "Jack" },
                { 3, "Joe" }
            };
            IList<Student> iStudentList = new List<Student>()
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                new Student() { StudentID = 2, StudentName = "Steve",  Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Abram" , Age = 21 }
            };

            #region Select() & SelectMany() Implementation
            IEnumerable<Person> people = new List<Person>();

            // Select gets a list of lists of phone numbers
            IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);

            // SelectMany flattens it to just a list of phone numbers.
            IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

            // And to include data from the parent in the result: 
            // pass an expression to the second parameter (resultSelector) in the overload:
            var directory = people
               .SelectMany(p => p.PhoneNumbers,
                           (person, phoneNumber) => new { person.Name, phoneNumber.Number }); // base is a keyword so use an @sign in front of it

            foreach (var x in directory)
            {
                Console.WriteLine($"Name: {x.Name}");
                Console.WriteLine($"Phone Number: {x.Number}");
            }
            #endregion
            #region Query Syntax
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
            #endregion

            DecimalAverage del1 = GetDecimalAverge; // Delegate
            Func<int, bool> passing = (p => p >= 80); // Func
            Action<int[]> avg = x => Math.Floor(x.Average()); // Action
            Predicate<int[]> failed = x => x.Average() < 65; // Predicate

            var excellent = scores.Where(x => x >= 90);
            var seventyFives = scores.Where(x => x == 75);

            var tester = scores;
            #region var scores_Aggregate = scores.Aggregate((a, b) => a + b);

            var scores_Aggregate = scores.Aggregate((a, b) => a + b);
            Console.WriteLine(scores_Aggregate);

            #endregion
            # region var scores_All = scores.All(p => p >= 80);

            var scores_All = scores.All(p => p >= 80);
            Console.WriteLine(scores_All);

            #endregion
            #region var scores_Any = scores.Any();

            var scores_Any = scores.Any();
            Console.WriteLine(scores_Any);

            #endregion
            #region var scores_Append = scores.Append(67);

            var scores_Append = scores.Append(67);
            foreach (var score in scores_Append)
            {
                Console.WriteLine(score);
            }

            #endregion
            #region var scores_AsEnumerable = scoreSet1.AsEnumerable();

            var scores_AsEnumerable = scoreSet1.AsEnumerable();
            foreach (var score in scores_AsEnumerable)
            {
                Console.WriteLine(score);
            }

            #endregion
            #region var scores_AsMemory = scores.AsMemory();

            var scores_AsMemory = scores.AsMemory();
            var span = scores_AsMemory.Span;
            var spanEnumerator = span.GetEnumerator();
            Console.WriteLine(spanEnumerator.MoveNext());
            Console.WriteLine(spanEnumerator.Current);

            #endregion
            #region var scores_AsParallel = scores.AsParallel();

            var scores_AsParallel = scores.AsParallel();
            foreach (var item in scores_AsParallel)
            {
                Console.WriteLine(item);
            }

            #endregion
            #region var scores_AsQueryable = scores.AsQueryable();

            var scores_AsQueryable = scores.AsQueryable();
            foreach (var q in scores_AsQueryable)
            {
                Console.WriteLine(q);
            }

            #endregion
            #region var scores_AsSpan = scores.AsSpan();

            var scores_AsSpan = scores.AsSpan();
            foreach (var item in scores_AsSpan)
            {
                Console.WriteLine(item);
            }

            #endregion
            #region var scores_Average1 = scores.Average();

            var scores_Average1 = scores.Average();

            #endregion
            #region var scores_Case = scores.Cast<decimal>();

            var scores_Case = scores.Cast<decimal>();
            foreach (var score in scores_Case)
            {
                Console.WriteLine($"Score: {score}");
                Console.WriteLine($"Type: {score.GetType()}");
            }

            #endregion
            #region var scores_Clone = scores.Clone();

            var scores_Clone = scores.Clone();
            Console.WriteLine(scores_Clone);

            #endregion
            #region var scores_Concatenate = scores.Concat(scoreSet1);

            var scores_Concatenate = scores.Concat(scoreSet1);
            var scores_Contains = scores.Contains(79);

            #endregion
            #region scores.CopyTo(destinationArray);

            scores.CopyTo(destinationArray);

            #endregion
            #region var scores_Count = scores.Count();

            var scores_Count = scores.Count();
            Console.WriteLine(scores_Count);

            #endregion
            #region var scores_DefaultOrEmpty = scores.DefaultIfEmpty();

            var scores_DefaultOrEmpty = scores.DefaultIfEmpty();
            foreach (var score in scores_DefaultOrEmpty)
            {
                Console.WriteLine(score);
            }

            #endregion
            #region var scores_Distinct = scores.Distinct();

            var scores_Distinct = scores.Distinct();
            foreach (var score in scores_Distinct)
            {
                Console.WriteLine(score);
            }

            #endregion
            #region var scores_ElementAt = scores.ElementAt(10);
            try
            {
                var scores_ElementAt = scores.ElementAt(3); // will throw exception
            }
            catch (ArgumentNullException n)
            {
                Console.WriteLine(n.Message);
            }
            catch (ArgumentOutOfRangeException r)
            {
                Console.WriteLine(r.Message);
            }
            #endregion
            #region var scores_ElementAtOrDefault = scores.ElementAtOrDefault(3);

            var scores_ElementAtOrDefault = scores.ElementAtOrDefault(3);
            Console.WriteLine(scores_ElementAtOrDefault);

            #endregion
            var scores_Equals = scores.Equals(scoresCopy);
            var scores_Except = scores.Except(seventyFives);
            var scores_First = scores.First();
            var scores_FirstOrDefault = scores.FirstOrDefault();
            #region var scores_GroupBy = scores.GroupBy(x => x);
            var scores_GroupBy = scores.GroupBy(x => x);
            foreach (var score in scores_GroupBy)
            {
                foreach (var x in score)
                {
                    Console.WriteLine(x);
                }
                Console.WriteLine();
            }
            #endregion
            #region var scores_GroupJoin = standardList.GroupJoin(studentList...)            
            var scores_GroupJoin = standardList.GroupJoin(studentList,
                                                    standard => standard.StandardID,
                                                    student => student.StandardID,
                                                    (standard, studentGroup) => new
                                                    {
                                                        StudentGroup = studentGroup,
                                                        StandardFullName = standard.StandardName
                                                    });

            foreach (var x in scores_GroupJoin)
            {
                Console.WriteLine(x.StandardFullName);

                foreach (var y in x.StudentGroup)
                {
                    Console.WriteLine(y.StudentName);
                }
            }
            #endregion
            var scores_Intersect = scores.Intersect(scoreSet1);
            #region var scores_Join = studentList.Join(standardList...)
            var scores_Join = studentList.Join(standardList,
                                               stud => stud.StudentID,
                                               stand => stand.StandardID,
                                               (stud, stand) => stud);
            foreach (var student in scores_Join)
            {
                Console.WriteLine($"{student.StudentName} {student.StudentID}");
            }
            #endregion
            var scores_Last = scores.Last();
            var scores_LastOrDefault = scores.LastOrDefault();
            var scores_LongCount = scores.LongCount();
            var scores_Max = scores.Max();
            var scores_Min = scores.Min();
            var scores_OfType = scores.OfType<int>();
            var scores_OrderBy = scores.OrderBy(x => x);
            var scores_OrderByDescending = scores.OrderByDescending(x => x);
            var scores_Prepend = scores.Prepend(100);
            var scores_Reverse = scores.Reverse();
            var scores_Select = studentList.Select(x => x.Age);
            #region var scores_SelectMany = people.SelectMany(...)
            var scores_SelectMany = people.SelectMany(x => x.PhoneNumbers, (x, y) => new { x.Name, y.Number });
            foreach (var item in scores_SelectMany)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Phone Number: {item.Number}");
            }
            #endregion
            var scores_SequenceEqual = scores.SequenceEqual(scoreSet2);
            #region var scores_Single = scores.Single(x => x == 80);
            try
            {
                var scores_Single = scores.Single(x => x == 80); // will throw exception
            }
            catch (ArgumentNullException n)
            {
                Console.WriteLine(n.Message);
            }
            catch (InvalidOperationException i)
            {
                Console.WriteLine(i.Message);
            }
            #endregion
            #region var scores_SingleOrDefault = scores.SingleOrDefault(x => x == 80);
            try
            {
                var scores_SingleOrDefault = scores.SingleOrDefault(x => x == 80); // will throw exception
            }
            catch (ArgumentNullException n)
            {
                Console.WriteLine(n.Message);
            }
            catch (InvalidOperationException i)
            {
                Console.WriteLine(i.Message);
            }
            #endregion
            #region var scores_Skip = scores.Skip(2);
            var scores_Skip = scores.Skip(2);
            foreach (var score in scores_Skip)
            {
                Console.WriteLine(score);
            }
            #endregion
            #region var scores_SkipLast = scores.SkipLast(2);
            var scores_SkipLast = scores.SkipLast(2);
            foreach (var score in scores_SkipLast)
            {
                Console.WriteLine(score);
            }
            #endregion
            var scores_SkipWhile = studentList.SkipWhile(x => x.StudentName != "John");
            var scores_Sum = scores.Sum();
            var scores_Take = scores.Take(6);
            var scores_TakeWhile = scores.TakeWhile(x => x <= 75);
            var scores_ToArray = scores.ToArray();
            #region var scores_ToDictionary = scores.ToDictionary(x => x < 3);
            var scores_ToDictionary = scores.ToDictionary(x => x < 3);
            foreach (var entry in scores_ToDictionary)
            {
                Console.WriteLine($"Key: {entry.Key}");
                Console.WriteLine($"Value: {entry.Value}");
                Console.WriteLine();
                Console.WriteLine();
            }
            #endregion
            var scores_ToHashSet = scores.ToHashSet();
            var scores_ToList = scores.ToList();
            #region var scores_ToLookup = iStudentList.ToLookup(x => x.Age);
            var scores_ToLookup = iStudentList.ToLookup(x => x.Age);
            foreach (var lookUpGroup in scores_ToLookup)
            {
                var i = 1;
                Console.WriteLine($"Group{i}: {lookUpGroup.Key}");
                i++;
                foreach (var name in lookUpGroup)
                {
                    Console.WriteLine(name.StudentName);
                }
                Console.WriteLine();
            }
            #endregion
            #region var scores_Union = scores.Union(scoresSet1);
            var scores_Union = scores.Union(scoreSet1);
            foreach (var score in scores_Union)
            {
                Console.WriteLine(score); // returns the distinct elements of the 2 collections
            }
            #endregion
            var scores_Where = studentList.Where(x => x.StudentName[0] == char.ToUpper(x.StudentName[0]));
            #region var scores_Zip = names.Zip(scores);
            var scores_Zip = names.Zip(scores);
            foreach (var combined in scores_Zip)
            {
                Console.WriteLine(combined);
            }
            #endregion

            // TODO: Finish the rest of the LINQ Methods similar to above

        }
    }
}
