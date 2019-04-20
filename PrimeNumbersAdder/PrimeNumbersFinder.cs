using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumbersAdder
{
    public static class PrimeNumbersFinder
    {
        public static List<int> FindWithoutDuplicates(string inputToScan, int primeNumberLenght, int primeNumbersMaxCount)
        {
            var primeNumbers = new List<int>(primeNumbersMaxCount);

            for (int i = 0; i <= inputToScan.Length - primeNumberLenght; i++)
            {
                var candidate = Int32.Parse(inputToScan.Substring(i, primeNumberLenght));

                if (!IsPrime(candidate) || primeNumbers.Contains(candidate))
                {
                    continue;
                }

                primeNumbers.Add(candidate);
                if (primeNumbers.Count >= primeNumbersMaxCount)
                {
                    break;
                }
            }

            return primeNumbers;
        }

        private static bool IsPrime(int candidate)
        {
            if (candidate <= 1 || candidate % 2 == 0)
            {
                return false;
            }
            if (candidate == 2)
            {
                return true;
            }

            candidate = (int)Math.Floor(Math.Sqrt(candidate));

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
