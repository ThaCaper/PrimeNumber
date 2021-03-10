namespace PrimeAPI.Data
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
    }
}