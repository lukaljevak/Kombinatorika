using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombinatorika
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] digits = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var permutations = GetPermutations(digits, digits.Length);

            foreach (var perm in permutations)
            {
                var numberArray = perm.ToArray();
                int number = int.Parse(string.Join("", numberArray));
                if (IsValid(numberArray))
                {
                    Console.WriteLine("Tražen broj je:" + number);
                    Console.ReadLine();
                    return;
                   
                }
            }
            Console.ReadKey();
        }
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(T[] list, int length)
        {
            if (length == 1)
                return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                            (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        static bool IsValid(int[] numberArray)
        {
            
            for (int i = numberArray.Length; i > 0; i--)
            {
                int currentNumber = int.Parse(string.Join("", numberArray.Take(i)));
                if (currentNumber % i != 0)
                    return false;
            }
            return true;
        }
    }
}
