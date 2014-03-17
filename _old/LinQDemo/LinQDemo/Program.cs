using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinQDemo
{
    public class Program
    {

        // http://msdn.microsoft.com/en-us/vcsharp/aa336746
        
        public static void demoRestriction01()
        {
            System.Console.WriteLine("\n# demoRestriction01");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            System.Console.WriteLine("Low Numbers:");
            IEnumerable<int> lowNumbers = from n in numbers where n < 5 select n;
            foreach (int element in lowNumbers)
            {
                Console.Write(element + " ");
            }
            System.Console.WriteLine("\nLow Numbers (with variable):");
            var variableLowNumbers = from n in numbers where n < 5 select n;
            foreach (var variableElement in variableLowNumbers) {
                Console.Write(variableElement + " ");
            }        
        }

        public static void demoRestriction02()
        {
            System.Console.WriteLine("\n# demoRestriction02");
            List<Person> list = new List<Person>();
            list.Add(new Person("Alma",10,Gender.WOMAN));
            list.Add(new Person("Korte", 20, Gender.MAN));
            list.Add(new Person("Szilva", 30, Gender.WOMAN));
            
            System.Console.WriteLine("\nAdultPeople:");
            IEnumerable<Person> adultPeople = from p in list where p.Age > 18 select p;
            foreach (Person element in adultPeople)
            {
                Console.Write(element + " ");
            }

            System.Console.WriteLine("\nAdultPeople:");
            var variableAdultPeople = from p in list where p.Age > 18 select p;
            foreach (var variableElement in variableAdultPeople)
            {
                Console.Write(variableElement + " ");
            }

            Console.WriteLine("\nWoman:");

            var women = from p in list where p.Gender == Gender.WOMAN select p;
            foreach (var x in women)
            {
                Console.Write(x + " ");
            }

        }

        // Projection
        public static void demoProjection01()
        {
            System.Console.WriteLine("\n# demoProjection01");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            System.Console.WriteLine("Plus one numbers: ");

            IEnumerable<int> numsPlusOne = from n in numbers select n + 1;
            foreach (int i in numsPlusOne)
            {
                Console.Write(i + " ");
            }
        }

        public static void demoProjection02()
        {
            System.Console.WriteLine("\n# demoProjection02");

            List<Person> list = new List<Person>();
            list.Add(new Person("Alma", 10, Gender.WOMAN));
            list.Add(new Person("Korte", 20, Gender.MAN));
            list.Add(new Person("Szilva", 30, Gender.WOMAN));

            System.Console.WriteLine("\nonly names: ");

            IEnumerable<string> onlyNames = from p in list select p.Name;
            // names2.Take(3); Skip(2); TakeWhile(); SkipWhile();

            foreach (string x in onlyNames)
            {
                Console.Write(x + " ");
            }

            System.Console.WriteLine("\nonly names (with variable): ");
            var names = from p in list select p.Name;
            foreach (var x in names)
            {
                Console.Write(x + " ");
            }
        }

        public static void anonymousTypes()
        {
            System.Console.WriteLine("\n# anonymousTypes");
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = from w in words select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            foreach (var ul in upperLowerWords)
            {
                Console.WriteLine("Uppercase: {0}, Lowercase: {1}", ul.Upper, ul.Lower);
            }
        }

        public static void compound()
        {
            System.Console.WriteLine("\n# Compound");

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = from a in numbersA from b in numbersB where a < b select new { a, b };
            
            Console.WriteLine("Pairs where a < b:");

            foreach (var pair in pairs)
            {
                Console.WriteLine("{0} is less than {1}", pair.a, pair.b);
            }
        }

        public static void orderBy()
        {
            System.Console.WriteLine("\n# OrderBy");

            string[] words = { "cherry", "apple", "blueberry" };

            IEnumerable<string> sortedWords = from w in words orderby w select w;
            // sortedWords.OrderBy();
            Console.WriteLine("\nThe sorted list of words:");
            foreach (string w in sortedWords)
            {
                Console.Write(w + " ");
            }

            Console.WriteLine("\nSort by lenght (desc):");
            var sortByLengthDesc = from w in words orderby w.Length descending select w;
            foreach (var w in sortByLengthDesc)
            {
                Console.Write(w + " ");
            }
        }

        public static void groupBy()
        {
            System.Console.WriteLine("\n# GroupBy");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numberGroups = from n in numbers group n by n % 5 into g select new { Remainder = g.Key, Numbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.Numbers)
                {
                    Console.WriteLine(n);
                }
            }
        }


        public static void Main(string[] args)
        {
            Program.demoRestriction01();
            Program.demoRestriction02();
            Program.demoProjection01();
            Program.demoProjection02();
            Program.anonymousTypes();
            Program.compound();
            Program.orderBy();
            Program.groupBy();
        }
    }
}
