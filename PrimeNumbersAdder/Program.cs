using System;
using System.IO;
using PrimeNumbersAdder.Configuration;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace PrimeNumbersAdder
{
    class Program
    {
        static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build().Get<AppConfiguration>();

            var inputTextToScan = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "inputToScan.txt"));

            var primeNumbers = PrimeNumbersFinder.FindWithoutDuplicates(inputTextToScan, config.PrimeNumberLength, config.PrimeNumbersMaxCount);
            if (primeNumbers.Count < config.PrimeNumbersMaxCount)
            {
                Console.WriteLine($"Alert! Found only {primeNumbers.Count} prime numbers in provided string");
            }
            var sumOfPrimes = primeNumbers.Sum(p => (long)p);
            Console.WriteLine($"Sum of prime numbers: {sumOfPrimes}");
        }
    }
}
