using System;
using System.Collections.Generic;
using PrimeAPIClone.Data;

namespace PrimeAPIClone.Data
{
    public class Repository : IRepository
    {
        public bool IsPrimeNumber(string input)
        {
            var number = int.Parse(input);
            var isPrime = true;

            for (var i = 2; i < number / 2; i++)
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }

            return isPrime;
        }

        public string CountPrimes(string start, string end)
        {
            int startNumber = int.Parse(start);
            int endNumber = Convert.ToInt32(end);
            var primeNumbers = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                int counter = 0;
                for (int j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        counter++;
                        break;
                    }
                }
                if(counter == 0 && i != 1)
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers.Count.ToString();
        }
    }
}