using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Qualtrax.DevTest.RomanNumeralConverter
{
    public class RomanNumeral
    {
        //Local variables
        private string m_romanNumeralValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="RomanNumeral" /> class.
        /// </summary>
        /// <param name="romanNumeral">The roman numeral.</param>
        public RomanNumeral(string romanNumeral)
        {
            //Store local copy, and upper case the whole value for consistency
            m_romanNumeralValue = romanNumeral.ToUpper();
        }

        /// <summary>
        /// Converts the value of the specified RomanNumeral to System.Decimal
        /// </summary>
        /// <returns></returns>
        public Decimal ToDecimal()
        {
            //filed to return after we populate it
            Decimal result = 0;
            RomanNumeralsBase romanBase = RomanNumeralsBase.Instance();
            
            //We need to loop all base roman numerals
            foreach (KeyValuePair<string, short> baseRomanNumeral in romanBase.Numerals)
            {
                //Each time the current Base Roman Numeral is found we need to act on it    
                while (m_romanNumeralValue.IndexOf(baseRomanNumeral.Key) == 0)
                {
                    //Add current value
                    result += baseRomanNumeral.Value;

                    //Remove current value so we don't double count it.
                    m_romanNumeralValue = m_romanNumeralValue.Substring(baseRomanNumeral.Key.Length);
                }
            }

            return result;
        }

        
    }
}
