using PrimeDataHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeDataHelper
{
    public class GetPrimeData : IGetPrimeData
    {
        private PrimeDBContext context;

        public GetPrimeData(PrimeDBContext DBContext)
        {
            context = DBContext;
        }

        public List<PrimeRange> GetAllRanges()
        {
            List<PrimeRange> result;
            try
            {
                result = context.NumOfPrimes.ToList();
            } catch (Exception e)
            {
                Console.WriteLine("Exception stacktrace: {0}", e.StackTrace);
                throw;
            }

            if (result == null)
            {
                throw new NullReferenceException("The result was null, no entities  was found in the database");
            }

            return result;
            
        }

        public PrimeRange GetBySingleRange(int input1, int input2)
        {
            PrimeRange result;
            try
            {
                result =  context.NumOfPrimes.FirstOrDefault(range => range.Input1 == input1 && range.Input2 == input2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception stacktrace: {0}", e.StackTrace);
                throw;
            }

            if (result == null)
            {
                throw new NullReferenceException("The result was null, no entities  was found in the database");
            }

            return result;
        }

        public List<Prime> GetAllSingleInput()
        {
            List<Prime> result;
            try
            {
                result = context.IsPrimes.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception stacktrace: {0}", e.StackTrace);
                throw;
            }

            if (result == null)
            {
                throw new NullReferenceException("The result was null, no entities  was found in the database");
            }

            return result;
        }

        public Prime GetByInput(int input)
        {
            Prime result;
            try
            {
                result = context.IsPrimes.FirstOrDefault(prime => prime.Input == input);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception stacktrace: {0}", e.StackTrace);
                throw;
            }

            if (result == null)
            {
                throw new NullReferenceException("The result was null, no entities  was found in the database");
            }

            return result;
        }
    }
}
