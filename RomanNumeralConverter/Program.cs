using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qualtrax.DevTest.Common;

namespace Qualtrax.DevTest.RomanNumeralConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Just in case something unexpected happens lets catch and log
            try
            {   
                //Validate input against boundary conditions
                string input = Validator.GetValidInput(args);

                //Init RomanNumeral and convert to Decimal
                RomanNumeral romanNumeral = new RomanNumeral(input);
                Decimal result = romanNumeral.ToDecimal();

                //Write the results to standard out.
                Console.WriteLine(result.ToString());
            }
            catch (Exception ex)
            {
                //Log exceptions
                Console.WriteLine(string.Format("Unexepected Exception occured: {0}", ex.Message));
            }
        }
    }
}
