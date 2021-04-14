using PrimeDataHelper;
using PrimeDataHelper.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PrimeNumber
{
    class Program
    {
        private static PrimeDBContext con = new PrimeDBContext();
        private static GetPrimeData gpd = new GetPrimeData(con);
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
            Console.WriteLine("3) Get single prime");
            Console.WriteLine("4) Get all primes");
            Console.WriteLine("5) Get single prime range");
            Console.WriteLine("6) Get all prime ranges");
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
                    getSinglePrime();
                    return true;
                case "4":
                    getAllPrimes();
                    return true;
                case "5":
                    getSingleRange();
                    return true;
                case "6":
                    getAllRanges();
                    return true;
                case "7":
                    return false;
                default:
                    return true;
            }
            
        }

        private static void getAllRanges()
        {
            throw new NotImplementedException();
        }

        private static void getSingleRange()
        {
            Console.Clear();
            Console.WriteLine("Enter input 1");
            int input1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter input 2");
            int input2 = int.Parse(Console.ReadLine());
            PrimeRange res = gpd.GetBySingleRange(input1, input2);
            Console.WriteLine(res.Input1.ToString() + " " + res.Input2.ToString() + " " + res.NumOfPrimes.ToString() + " " + res.Occurrences.ToString());
            Console.ReadLine();
        }

        private static void getAllPrimes()
        {
            Console.Clear();
            List<Prime> allprime = gpd.GetAllSingleInput();

            foreach (var primes in allprime)
            {
                Console.WriteLine(primes.Input.ToString() +" - "+ primes.IsPrime.ToString());
            }
        }

        private static void getSinglePrime()
        {
            Console.Clear();
            Console.WriteLine("Enter a number");
            int input = int.Parse(Console.ReadLine());
            Prime res = gpd.GetByInput(input);
            Console.WriteLine(res.Input.ToString() + " " + res.IsPrime.ToString() + " " + res.Occurrences.ToString());
            Console.ReadLine();
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

        private static string getPrime(string number)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44391/");
            var request = new RestRequest(number.ToString(), Method.GET);
            var response = c.Execute(request);
            var isPrime = response.Content.ToString();
            return isPrime;
        }

        private static string getPrimes(string startNumber, string endNumber)
        {
            RestClient c = new RestClient();
            c.BaseUrl = new Uri("https://localhost:44391/");
            var request = new RestRequest("{entity}={entity1}").AddUrlSegment("entity", startNumber).AddUrlSegment("entity1", endNumber);
            var response = c.Execute(request);
            var numberOfPrimes = response.Content.ToString();
            return numberOfPrimes;
        }
    }
}
