﻿using RestSharp;
using System;

namespace PrimeNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Is Prime");
            Console.WriteLine("2) Count Primes");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine()) 
            {
                case "1":
                    isPrime();
                    return true;
                case "2":
                    countPrimes();
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
            
        }

        private static void isPrime()
        {
            Console.Clear();
            Console.WriteLine("Enter a number to check if prime: Type Quit to Quit.");
            string number;
            while ((number = Console.ReadLine()) != "Quit") 
            {
                var isPrime = getPrime(number);
                if (isPrime == "true")
                {
                    Console.WriteLine("Is Prime" + " " + number);
                }
                else
                {
                    Console.WriteLine("Is not Prime" + " " + number);
                }
            }
        }

        private static string getPrime(string number)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44361/primes/");
            var request = new RestRequest(number.ToString(), Method.GET);
            var response = c.Execute(request);
            var isPrime = response.Content.ToString();
            return isPrime;
        }

        private static void countPrimes()
        {
            Console.Clear();
            Console.WriteLine("Enter two numbers to get primes between the numbers: Type q to Quit");
            while (true) 
            {
                string startNumber;
                string endNumber;
                Console.Write("Enter The Start Number:");
                startNumber = (Console.ReadLine());
                if (startNumber.Contains("q"))
                {
                    break;
                }
                Console.Write("Enter the End Number : ");
                endNumber = (Console.ReadLine());
                if (endNumber.Contains("q"))
                {
                    break;
                }
                var NumOfPrims = getPrimes(startNumber, endNumber);
                Console.WriteLine("Number of primes between:" + " " + startNumber + " " + endNumber + " = " + NumOfPrims);
            }
        }        
        private static string getPrimes(string startNumber, string endNumber)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44361/primes/");
            var request = new RestRequest("{entity}={entity1}").AddUrlSegment("entity", startNumber).AddUrlSegment("entity1", endNumber);
            var response = c.Execute(request);
            var numberOfPrimes = response.Content.ToString();
            return numberOfPrimes;
        }
    }
}
