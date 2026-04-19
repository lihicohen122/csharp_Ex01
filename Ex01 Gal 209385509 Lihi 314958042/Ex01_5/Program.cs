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

            calculateAndPrintNumberOfDigitsBiggerThanUnitNumber(parsedUserInputToNumber);
            printNumberOfDigitsDivisibleByFour(userInputString);
            printMultiplicationOfMinimumDigitAndMaximumDigit(userInputString);
            printNumberOfUniqueDigitsInNumber(userInputString);
        }

        private static string printRequirementsAndGetUserInput(out int o_ParsedUserInputToNumber)
        {
            const int k_UserInputNumberLength = 9;
            string requirementMessage = string.Format("Please enter a {0} digit number: ", k_UserInputNumberLength);
            string invalidMessage = string.Format("Invalid input! Please enter a {0} digit number: ", k_UserInputNumberLength);

            Console.WriteLine(requirementMessage);
            string userInputString = Console.ReadLine();
            bool areAllCharactersDigits = int.TryParse(userInputString, out o_ParsedUserInputToNumber);

            while (!areAllCharactersDigits || string.IsNullOrEmpty(userInputString) || userInputString.Length != k_UserInputNumberLength)
            {
                Console.WriteLine(invalidMessage);
                userInputString = Console.ReadLine();
                areAllCharactersDigits = int.TryParse(userInputString, out o_ParsedUserInputToNumber);
            }

            return userInputString;
        }

        private static void calculateAndPrintNumberOfDigitsBiggerThanUnitNumber(int i_UserInputNumber)
        {
            int unitNumber = i_UserInputNumber % 10;
            string unitNumberSubString = string.Format("Unit number is: {0}.", unitNumber);
            StringBuilder numberOfDigitsBiggerThanUnitNumberStringBuilder = new StringBuilder(unitNumberSubString);
            int numberOfDigitsBiggerThanUnitNumber = 0;

            while(i_UserInputNumber > 0)
            {
                int currentDigit = i_UserInputNumber % 10;

                if(currentDigit > unitNumber)
                {
                    numberOfDigitsBiggerThanUnitNumber++;
                    if(numberOfDigitsBiggerThanUnitNumber == 1)
                    {
                        numberOfDigitsBiggerThanUnitNumberStringBuilder.Append(" Digits bigger than the unit number (excluding the unit number): ");
                    }
                    numberOfDigitsBiggerThanUnitNumberStringBuilder.Append(currentDigit);
                    numberOfDigitsBiggerThanUnitNumberStringBuilder.Append(", ");
                    
                }

                i_UserInputNumber /= 10;
            }

            if(numberOfDigitsBiggerThanUnitNumber > 0)
            {
                int indexOfLastComma = numberOfDigitsBiggerThanUnitNumberStringBuilder.ToString().LastIndexOf(',');

                numberOfDigitsBiggerThanUnitNumberStringBuilder.Replace(',', '.', indexOfLastComma, 1);
            }
            else
            {
                numberOfDigitsBiggerThanUnitNumberStringBuilder.Append(" No digits bigger than the unit number. ");
            }

            string subStringOfNumberOfDigitsBiggerThanUnitNumber = string.Format("Total of: {0}.", numberOfDigitsBiggerThanUnitNumber);

            numberOfDigitsBiggerThanUnitNumberStringBuilder.Append(subStringOfNumberOfDigitsBiggerThanUnitNumber);
            Console.WriteLine(numberOfDigitsBiggerThanUnitNumberStringBuilder.ToString());
        }

        private static void printNumberOfDigitsDivisibleByFour(string i_UserInputString)
        {
            int numberOfDigitsDivisibleByFour = calculateNumberOfDigitsDivisibleByFour(i_UserInputString);
            string divisibleByFourMessage = string.Format("How many digits divisible by 4? {0}.", numberOfDigitsDivisibleByFour);

            Console.WriteLine(divisibleByFourMessage);
        }

        private static int calculateNumberOfDigitsDivisibleByFour(string i_UserInputString)
        {
            int numberOfDigitsDivisibleByFour = 0;
            int userInputStringLength = i_UserInputString.Length;

            for (int i = 0; i < userInputStringLength; ++i)
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

            for (int i = 0; i < userInputStringLength; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_UserInputString[i]);

                if (currentDigit > maximumDigitInUserString)
                {
                    maximumDigitInUserString = currentDigit;
                }

                if (currentDigit < minimumDigitInUserString)
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
            string numberOfUniqueDigitsInNumberCalculationString = "0000000000";
            int userInputStringLength = i_UserInputString.Length;

            for (int i = 0; i < userInputStringLength; ++i)
            {
                int currentDigit = (int)char.GetNumericValue(i_UserInputString[i]);

                if (numberOfUniqueDigitsInNumberCalculationString[currentDigit] == '0')
                {
                    numberOfUniqueDigitsInNumberResult++;
                    StringBuilder stringBuilder = new StringBuilder(numberOfUniqueDigitsInNumberCalculationString);

                    stringBuilder[currentDigit] = '1';
                    numberOfUniqueDigitsInNumberCalculationString = stringBuilder.ToString();
                }
            }

            return numberOfUniqueDigitsInNumberResult;
        }
    }
}