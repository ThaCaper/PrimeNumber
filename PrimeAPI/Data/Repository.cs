namespace PrimeAPI.Data
{
    public class Repository : IRepository
    {
        public bool IsPrimeNumber(string input)
        {
            int number = int.Parse(input);
            bool isPrime = true;

            for (int i = 2; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }
    }
}