namespace PrimeAPIClone.Data
{
    public interface IRepository
    {
        bool IsPrimeNumber(string input);

        string CountPrimes(string start, string end);
    }
}