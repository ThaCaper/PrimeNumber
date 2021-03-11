using RestSharp;
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
            Console.WriteLine("Enter two numbers to get primes between the numbers:");
            Console.Write("Enter The Start Number: ");
            string startNumber = (Console.ReadLine());
            Console.Write("Enter the End Number : ");
            string endNumber = (Console.ReadLine());
            Console.ReadLine();
        }
    }
}
