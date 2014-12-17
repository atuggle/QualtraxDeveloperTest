using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualtrax.DevTest.PokerHandScoreCalculator
{
    public class Card : IComparable
    {
        //Properties for the Card Class
        public Suit MySuit { get; private set; }
        public FaceValue MyFaceValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card" /> class.
        /// </summary>
        /// <param name="cardStr">The card STR.</param>
        public Card(string cardStr)
        {
            try
            {
                //Grab suit from the passed in card value
                char suit = cardStr.LastOrDefault();
                this.MySuit = (Suit)Enum.Parse(typeof(Suit), suit.ToString(), true);

                //Grab face value from passed in card value
                string face = cardStr.Replace(suit.ToString(), "");
                this.MyFaceValue = GetFaceValueFrom(face);
            }
            catch (Exception ex)
            {
                //Catch exception and attempt to return a more informative execption
                string msg = "Individual card was not in expected format.  Please check that Facevalue is first followed by Suit value: (i.e. '5D')";
                throw new ArgumentException(msg, ex);
            }
        }

        private FaceValue GetFaceValueFrom(string face)
        {
            //Lets first attempt to grab the value as a short
            short faceValueInt = 0;
            if (short.TryParse(face, out faceValueInt))
                return (FaceValue)faceValueInt;

            //Looks like its a royal card
            switch (face)
            {
                case ("A"):
                    return FaceValue.Ace;
                case ("J"):
                    return FaceValue.Jack;
                case ("Q"):
                    return FaceValue.Queen;
                case ("K"):
                    return FaceValue.King;
            }

            //If we got this far, something is incorrect
            throw new ArgumentException("Input was not in expected format.  Expected facevalue as int or 'A', 'J', 'Q', 'K'");
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.
        /// </returns>
        int IComparable.CompareTo(object obj)
        {
            //Lets convert the object to the expected type
            Card other = (Card)obj;

            //Compare and report results
            if (this.MyFaceValue < other.MyFaceValue)
                return -1;
            else if (this.MyFaceValue > other.MyFaceValue)
                return 1;

            return 0;
        }
    }
}
