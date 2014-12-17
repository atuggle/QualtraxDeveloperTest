using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualtrax.DevTest.PokerHandScoreCalculator
{
    #region Public Enums used by Card Class

    /// <summary>
    /// Enumeration defining all possible Suit values a card could have
    /// </summary>
    public enum Suit
    {
        H,
        D,
        C,
        S
    }

    /// <summary>
    /// Enumeration defining all possible Face values a card could have
    /// </summary>
    public enum FaceValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    #endregion
}
