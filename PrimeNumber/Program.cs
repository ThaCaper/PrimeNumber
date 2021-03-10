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
            Console.WriteLine("Enter a number to check if prime:");
            string number = (Console.ReadLine());           
            Console.ReadLine();
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
