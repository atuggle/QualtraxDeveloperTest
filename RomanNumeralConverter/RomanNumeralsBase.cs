using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Qualtrax.DevTest.RomanNumeralConverter
{
    public class RomanNumeralsBase
    {
        //Local variables
        private static Dictionary<string, short> m_baseRomanNumerals;
        private static RomanNumeralsBase m_currentInstance; //Singleton instance
        private static object m_locker = new object();

        #region Constructor with Singleton pattern

        /// <summary>
        /// Prevents a default instance of the <see cref="RomanNumeralsBase" /> class from being created.
        /// </summary>
        private RomanNumeralsBase() 
        {
            m_baseRomanNumerals = new Dictionary<string, short>(13);
            m_baseRomanNumerals.Add("M", 1000);
            m_baseRomanNumerals.Add("CM", 900);
            m_baseRomanNumerals.Add("D", 500);
            m_baseRomanNumerals.Add("CD", 400);
            m_baseRomanNumerals.Add("C", 100);
            m_baseRomanNumerals.Add("XC", 90);
            m_baseRomanNumerals.Add("L", 50);
            m_baseRomanNumerals.Add("XL", 40);
            m_baseRomanNumerals.Add("X", 10);
            m_baseRomanNumerals.Add("IX", 9);
            m_baseRomanNumerals.Add("V", 5);
            m_baseRomanNumerals.Add("IV", 4);
            m_baseRomanNumerals.Add("I", 1);
        }

        /// <summary>
        /// Creates a single instance of this object.
        /// </summary>
        /// <returns></returns>
        public static RomanNumeralsBase Instance()
        {
            lock (m_locker)
            {
                if (m_currentInstance == null)
                    m_currentInstance = new RomanNumeralsBase();
            }
            return m_currentInstance;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the numerals.
        /// </summary>
        /// <value>
        /// The numerals.
        /// </value>
        public Dictionary<string, short> Numerals
        {
            get { return m_baseRomanNumerals; }
        }

        #endregion
    }
}
