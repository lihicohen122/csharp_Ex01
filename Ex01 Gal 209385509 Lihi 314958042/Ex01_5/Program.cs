using System;
using System.Text;

namespace Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        private static void runApp()
        {
            string userInputString = printRequirementsAndGetUserInput(out int parsedUserInputToNumber);

            calculateAndPrintNumberOfDigitsBiggerThanUnitNumber(userInputString);
            printNumberOfDigitsDivisibleByFour(userInputString);
            printMultiplicationOfMinimumDigitAndMaximumDigit(userInputString);
            printNumberOfUniqueDigitsInNumber(userInputString);
        }

        private static string printRequirementsAndGetUserInput(out int o_ParsedUserInputToNumber)
        {
            const int k_RequiredNumberLength = 9;
            string requirementMessage = string.Format("Please enter a {0} digit number: ", k_RequiredNumberLength);
            string invalidMessage = string.Format("Invalid input! Please enter a {0} digit number: ", k_RequiredNumberLength);

            Console.WriteLine(requirementMessage);
            string userInput = Console.ReadLine();

            while(!isValidInput(userInput, k_RequiredNumberLength, out o_ParsedUserInputToNumber))
            {
                Console.WriteLine(invalidMessage);
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static bool isValidInput(string i_Input, int i_Length, out int o_ParsedValue)
        {
            o_ParsedValue = 0;

            return !string.IsNullOrEmpty(i_Input) && i_Input.Length == i_Length &&
                   i_Input[0] != '-' && int.TryParse(i_Input, out o_ParsedValue);
        }

        private static void calculateAndPrintNumberOfDigitsBiggerThanUnitNumber(string i_UserInputString)
        {
            int unitNumber = (int)char.GetNumericValue(i_UserInputString[i_UserInputString.Length - 1]);
            string unitNumberSubString = string.Format("Unit number is: {0}.", unitNumber);
            StringBuilder biggerDigitsMessage = new StringBuilder(unitNumberSubString);
            int numberOfDigitsBiggerThanUnitNumber = 0;

            for(int i = 0; i < i_UserInputString.Length; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_UserInputString[i]);

                if(currentDigit > unitNumber)
                {
                    numberOfDigitsBiggerThanUnitNumber++;
                    if(numberOfDigitsBiggerThanUnitNumber == 1)
                    {
                        biggerDigitsMessage.Append(" Digits bigger than the unit number (excluding the unit number): ");
                    }

                    biggerDigitsMessage.Append(currentDigit);
                    biggerDigitsMessage.Append(", ");
                }
            }

            if(numberOfDigitsBiggerThanUnitNumber > 0)
            {
                biggerDigitsMessage.Length -= 2;
                biggerDigitsMessage.Append(". ");
            }
            else
            {
                biggerDigitsMessage.Append(" No digits bigger than the unit number. ");
            }

            biggerDigitsMessage.Append(string.Format("Total of: {0}", numberOfDigitsBiggerThanUnitNumber));
            Console.WriteLine(biggerDigitsMessage.ToString());
        }

        private static void printNumberOfDigitsDivisibleByFour(string i_UserInputString)
        {
            int numberOfDigitsDivisibleByFour = calculateNumberOfDigitsDivisibleByFour(i_UserInputString);
            string divisibleByFourMessage = string.Format("How many digits divisible by 4? {0}", numberOfDigitsDivisibleByFour);

            Console.WriteLine(divisibleByFourMessage);
        }

        private static int calculateNumberOfDigitsDivisibleByFour(string i_UserInputString)
        {
            int numberOfDigitsDivisibleByFour = 0;
            int userInputStringLength = i_UserInputString.Length;

            for(int i = 0; i < userInputStringLength; ++i)
            {
                if((int)char.GetNumericValue(i_UserInputString[i]) % 4 == 0)
                {
                    numberOfDigitsDivisibleByFour++;
                }
            }

            return numberOfDigitsDivisibleByFour;
        }

        private static void printMultiplicationOfMinimumDigitAndMaximumDigit(string i_UserInputString)
        {
            int multiplicationOfMinimumDigitAndMaximumDigit = findAndCalculateTheMultiplicationOfMinimumDigitAndMaximumDigit(i_UserInputString);
            string multiplicationOfMinimumDigitAndMaximumDigitMessage = string.Format("The Multiplication of the biggest digit and smallest digit is: {0}", multiplicationOfMinimumDigitAndMaximumDigit);

            Console.WriteLine(multiplicationOfMinimumDigitAndMaximumDigitMessage);
        }

        private static int findAndCalculateTheMultiplicationOfMinimumDigitAndMaximumDigit(string i_UserInputString)
        {
            int minimumDigitInUserString = 9;
            int maximumDigitInUserString = 0;
            int userInputStringLength = i_UserInputString.Length;

            for(int i = 0; i < userInputStringLength; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_UserInputString[i]);

                if(currentDigit > maximumDigitInUserString)
                {
                    maximumDigitInUserString = currentDigit;
                }

                if(currentDigit < minimumDigitInUserString)
                {
                    minimumDigitInUserString = currentDigit;
                }
            }

            return maximumDigitInUserString * minimumDigitInUserString;
        }

        private static void printNumberOfUniqueDigitsInNumber(string i_UserInputString)
        {
            int numberOfUniqueDigitsInNumber = calculateNumberOfUniqueDigitsInNumber(i_UserInputString);
            string numberOfUniqueDigitsInNumberMessage = string.Format("The number of unique digits in the number is: {0}", numberOfUniqueDigitsInNumber);

            Console.WriteLine(numberOfUniqueDigitsInNumberMessage);
        }

        private static int calculateNumberOfUniqueDigitsInNumber(string i_UserInputString)
        {
            int numberOfUniqueDigitsInNumberResult = 0;
            string digitFoundFlags = "0000000000";
            int userInputStringLength = i_UserInputString.Length;

            for(int i = 0; i < userInputStringLength; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_UserInputString[i]);

                if(digitFoundFlags[currentDigit] == '0')
                {
                    numberOfUniqueDigitsInNumberResult++;
                    StringBuilder flagsStringBuilder = new StringBuilder(digitFoundFlags);

                    flagsStringBuilder[currentDigit] = '1';
                    digitFoundFlags = flagsStringBuilder.ToString();
                }
            }

            return numberOfUniqueDigitsInNumberResult;
        }
    }
}