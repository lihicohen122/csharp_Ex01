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
            const int k_RequiredLength = 9;
            Console.WriteLine("Please enter a {0} digit number: ", k_RequiredLength);
            string userInput = Console.ReadLine();

            while (!isValidInput(userInput, k_RequiredLength, out o_ParsedUserInputToNumber))
            {
                Console.WriteLine("Invalid input! Please enter a positive {0} digit number: ", k_RequiredLength);
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

        private static void calculateAndPrintNumberOfDigitsBiggerThanUnitNumber(int i_UserInputNumber)
        {
            int unitNumber = i_UserInputNumber % 10;
            string numberAsString = i_UserInputNumber.ToString();
            string unitNumberSubString = string.Format("Unit number is: {0}.", unitNumber);
            StringBuilder stringBuilder = new StringBuilder(unitNumberSubString);
            int numberOfDigitsBiggerThanUnitNumber = 0;

            for(int i = 0; i < numberAsString.Length; ++i)
            {
                int currentDigit = numberAsString[i] - '0';

                if (currentDigit > unitNumber)
                {
                    numberOfDigitsBiggerThanUnitNumber++;
                    if (numberOfDigitsBiggerThanUnitNumber == 1)
                    {
                        stringBuilder.Append(" Digits bigger than the unit number (excluding the unit number): ");
                    }

                    stringBuilder.Append(currentDigit);
                    stringBuilder.Append(", ");
                }
            }

            if (numberOfDigitsBiggerThanUnitNumber > 0)
            {
                stringBuilder.Length -= 2;
                stringBuilder.Append(". ");
            }
            else
            {
                stringBuilder.Append(" No digits bigger than the unit number. ");
            }

            stringBuilder.Append(string.Format("Total of: {0}.", numberOfDigitsBiggerThanUnitNumber));
            Console.WriteLine(stringBuilder.ToString());
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