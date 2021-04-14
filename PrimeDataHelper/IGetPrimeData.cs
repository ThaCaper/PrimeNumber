using PrimeDataHelper.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeDataHelper
{
    interface IGetPrimeData
    {
        /**
         * * Should return only one instance of the Prime entity with the result
        * from the DB.
        * If the input is not in the DB return a message stating that no data was found.
        */
        Prime GetByInput(int input);

        /**
        * Should return a list of prime entity with all the relevant data from the DB table.
        * If an error occurs a message should be returned instead.
        */
        List<Prime> GetAllSingleInput();

        /**
        * Should return only one instance of the PrimeRange entity with the data from
        the DB.
        * If no such range exists in the DB, return a message stating that no data was
        found.
        */
        PrimeRange GetBySingleRange(int input1, int input2);

        /**
        * Should return a list of the PrimeRange entity with all the data form the
        relevant DB table.
        * If an error occurs a message should be returned instead.
        */
        List<PrimeRange> GetAllRanges();
    }
}
