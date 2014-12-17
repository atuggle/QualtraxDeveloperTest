using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Qualtrax.DevTest.Common;
using System.ComponentModel;

namespace Qualtrax.DevTest.PokerHandScoreCalculator
{
    public class Hand
    {
        //Local variables
        private List<Card> m_cardsSorted = new List<Card>(5);
        private List<FaceValue> m_duplicates;

        /// <summary>
        /// Initializes a new instance of the <see cref="Hand" /> class.
        /// </summary>
        /// <param name="cardsStr">The cards STR.</param>
        public Hand(string cardsStr)
        {
            //Retrieve individual cards from cardsStr
            string[] cards = cardsStr.Split(' ');

            //Validate some input here (test boundaray conditions)
            //Must have exactly 5 cards
            if (cards.Length != 5)
                throw new FormatException("Input was not in expected format.  Please use this format: '5H AS 5C 4D AC'");

            //Initialize all five cards
            foreach (string crd in cards)
                m_cardsSorted.Add(new Card(crd));

            //Make sure we sort the cards
            m_cardsSorted.Sort();
        }

        /// <summary>
        /// Gets the hand score.
        /// </summary>
        /// <returns></returns>
        public string GetHandScore()
        {
            //Check each case from Highest value to lowest value 
            //ensureing we report the highest value.
            if (IsStraightFlush())
                return "Straight Flush";
            else if (IsFourOfaKind())
                return "Four of a Kind";
            else if (IsFullHouse())
                return "Full House";
            else if (IsFlush())
                return "Flush";
            else if (IsStraight())
                return "Straight";
            else if (IsThreePair())
                return "Three Pair";
            else if (IsTwoPair())
                return "Two Pair";
            else if (IsOnePair())
                return "One Pair";
            

            //Return default of High Card
            return "High Card";
        }

        #region helper methods

        /// <summary>
        /// Gets the duplicate cards this hand has
        /// </summary>
        /// <returns></returns>
        private List<FaceValue> GetDuplicates()
        {
            //If duplicates is null then initialize
            if (m_duplicates == null)
            {
                //Retrieve list of duplicate values from cards.
                //Thanks to linq we can now use sql format to group and 
                //return list of values that have one or more occurances
                IEnumerable<FaceValue> duplicates = from c in m_cardsSorted
                                                 group c by c.MyFaceValue into grouped
                                                 where grouped.Count() > 1
                                                 select grouped.Key;

                //Hold a reference to the list of duplicate values for later use
                m_duplicates = new List<FaceValue>(duplicates);
            }

            //return single instance of duplicates
            return m_duplicates;
        }

        private bool IsStraightFlush()
        {
            //If we have both a straight and flush then we have a Straight Flush
            if (IsStraight() && IsFlush())
                return true;

            return false;
        }

        private bool IsFourOfaKind()
        {
            //Lets grab a handle to our duplicates 
            List<FaceValue> dup = GetDuplicates();

            //Check if we only have one pair
            if (dup.Count() == 1)
            {
                //Check to make sure we only have 4 of that card
                if (m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(0)) == 4)
                    return true;
            }

            return false;
        }

        private bool IsFullHouse()
        {
            //Lets grab a handle to our duplicates 
            List<FaceValue> dup = GetDuplicates();

            //Check if we only have one pair
            if (dup.Count() == 2)
            {
                int cntFirst = m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(0));
                int cntSecond = m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(1));

                //Check to make sure we only have 2 of each card and 1 of the pairs has 3
                if ((cntFirst == 3 || cntSecond == 3) && 
                    cntFirst > 1 && cntSecond > 2)
                    return true;
            }

            return false;
        }

        private bool IsFlush()
        {
            //Lets look for duplicate values based on 
            //the Suit and make sure we look for 5 of them
            IEnumerable<Suit> duplicates = from c in m_cardsSorted
                                           group c by c.MySuit into grouped
                                           where grouped.Count() == 5
                                           select grouped.Key;

            //If we found a match we have a flush
            if (duplicates.Count<Suit>() > 0)
                return true;
            
            return false;
        }

        private bool IsStraight()
        {
            //Grab first card, and convert its enum value to integer for comparison
            int currentCrd = (int)m_cardsSorted.First().MyFaceValue;
            
            //Loop through (asending) the cards checking they are just one value appart.
            for(int i=1; i<m_cardsSorted.Count; i++)
            {
                //Get next cards face value converted to int
                int nextCrd = (int)m_cardsSorted[i].MyFaceValue;

                //Check the two cards are in sequence and account for the Ace value working both as a 1 and as 14
                if ((nextCrd - currentCrd != 1) && currentCrd != (int)FaceValue.Ace)
                    return false;

                //Incriment currentCrd
                currentCrd = nextCrd;

                //Check for King then Ace value
                if (currentCrd == (int)FaceValue.King &&
                    m_cardsSorted.Exists(card => card.MyFaceValue == FaceValue.Ace))
                {
                    //Since we know the hand is sorted lowest to highest we can assume the ace completes the straight.
                    return true;
                }
            }

            return true;
        }

        private bool IsThreePair()
        {
            //Lets grab a handle to our duplicates 
            List<FaceValue> dup = GetDuplicates();

            //Check if we only have one pair
            if (dup.Count() == 1)
            {
                //Check to make sure we only have 3 of that card
                if (m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(0)) == 3)
                    return true;
            }

            return false;
        }

        private bool IsTwoPair()
        {
            //Lets grab a handle to our duplicates 
            List<FaceValue> dup = GetDuplicates();

            //Check if we only have one pair
            if (dup.Count() == 2)
            {
                //Check to make sure we only have 2 of each card
                if (m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(0)) == 2 &&
                    m_cardsSorted.Count(c => c.MyFaceValue == dup.ElementAt(1)) == 2)
                    return true;
            }

            return false;
        }

        private bool IsOnePair()
        {
            //Lets grab a handle to our duplicates 
            List<FaceValue> dup = GetDuplicates();

            //Check if we only have one pair
            if (dup.Count() == 1)
            {
                //Check to make sure we only have 2 of that card
                if (m_cardsSorted.Count(c => c.MyFaceValue == dup.First()) == 2)
                    return true;
            }

            //Looks like we don't have just one pair
            return false;
        }

        #endregion 

    }
}
