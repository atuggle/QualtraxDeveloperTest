QualtraxDeveloperTest
=====================

Qualtrax Developer Test - Roman Numeral Calculator &amp; Score Poker Hand

Actual code delivered...  Please ignore all the code comments and the missing unit test.  I am now a firm believer in TDD.

##################################
## Notes from Instructions.txt  ##
##################################

Please make sure you read and understand the initial requirements found in the solution folder "Documentation" called "QualtraxDeveloperTest.pdf"

While solving the two coding problems identified I implemented two console applications in this solution
1) PokerHandScoreCalculator
2) RomanNumeralConverter

Both programs used the same input format so the common code they both used to get and validate the input was put in a common dll for both projects to share.
Also both projects have an "InputFiles" folder with test input files that can be used.


PokerHandScoreCalculator: 
This program takes in a poker hand as outlined in the "QualtraxDeveloperTest.pdf" and produces the score (named score) of the hand (i.e. "Straight Flush")
Assumptions: Hand passed into the program is a valid hand. Specifically no one has extra cards of the same value and suit (No one is hiding aces up their sleeves).
To execute PokerHandScoreCalculator please compile the solution.  Open a console window and type in the location of and name of the application followed by the input file with the poker hand described inside it.
"...\PokerHandScoreCalculator.exe ..\TextFile1.txt" 

RomanNumeralConverter:
This program takes a Roman Numeral as input as outlined in the "QualtraxDeveloperTest.pdf" and produces the numeric representation of it. (i.e. MMXII == 2012)
Design Considerations: Implemented a RomanNumeral object and modeled it very similar to other common numeric types such as the Decimal, Integer, etc. 
					   I also choose to use a RomanNumeralBase that has the base Roman Numeral comparables to be used and I implemented it using the Singleton. 
					   Knowing the singleton patter was not necessary, I implemented it this way because this solution yeilds itself to being used more often
					   in a similar pattern to that of other numeric types that it was modeled after.


