using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Qualtrax.DevTest.Common
{
    public class Validator
    {
        /// <summary>
        /// Validates boundary conditions. Checks args is not null and holds only 1 value
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>FileName retrieved from input args</returns>
        /// <exception cref="System.ArgumentException"></exception>
        private static string ValidateInput(string[] args) 
        {
            //Validate inputs then pass work off to manipulator, need at least 2 lines
            if (args != null && args.Length == 1)
                return args[0];

            throw new FormatException("Invalid input detected.  Must pass in only 1 value. No more no less.");
        }


        /// <summary>
        /// Gets the valid input from file after validating boundary conditions
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static string GetValidInput(string[] args)
        {
            string fileName = ValidateInput(args);
            if (File.Exists(fileName))
            {
                //Let any exceptions bubble up to main exception handler
                string firstLine = File.ReadLines(fileName).First<string>();

                return firstLine;
            }

            throw new ArgumentException("Expected input file not found. Please provide the full path of standard text file providing the input.");
        }
    }
}
