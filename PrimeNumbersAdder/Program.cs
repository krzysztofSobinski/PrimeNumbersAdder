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
            if (config.PrimeNumberLength > Int32.MaxValue.ToString().Length)
            {
                Console.WriteLine($"Parameter {nameof(config.PrimeNumberLength)} value is too big. Max value is {Int32.MaxValue.ToString().Length}");
                Environment.Exit(0);
            }

            var inputTextToScan = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "inputToScan.txt"));
            var primeNumbers = PrimeNumbersFinder.FindWithoutDuplicates(inputTextToScan, config.PrimeNumberLength, config.PrimeNumbersMaxCount);
            if (primeNumbers.Count < config.PrimeNumbersMaxCount)
            {
                Console.WriteLine($"Alert! Found only {primeNumbers.Count} prime numbers in provided string.");
            }
            var sumOfPrimes = primeNumbers.Sum(p => (long)p);
            Console.WriteLine($"Prime numbers: {string.Join(", ", primeNumbers)}");
            Console.WriteLine($"Sum of prime numbers: {sumOfPrimes}");
        }
    }
}
