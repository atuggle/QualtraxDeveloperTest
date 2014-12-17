using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qualtrax.DevTest.Common;


namespace Qualtrax.DevTest.PokerHandScoreCalculator
{
    class Program
    {
        /// <summary>
        /// Console application starting point.
        /// </summary>
        /// <remarks>This application expects command line arguments to be passed in.</remarks>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            //Just in case something unexpected happens lets catch and log
            try
            {
                //Validate input against boundary conditions
                string input = Validator.GetValidInput(args);

                //Init Poker Hand and calculate its score
                Hand hand = new Hand(input);

                //Actually calculate the hands score
                string result = hand.GetHandScore();

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
