using System;

namespace Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        private static void runApp()
        {
            string userInputString = printRequirementMessageCheckValidityAndGetUserInput();

            printIsStringPalindrome(userInputString.ToLower());
            printIsNumberDivisibleByFourIfStringIsNumber(userInputString);
            bool areAllCharactersEnglishLetters = isAllEnglishLetters(userInputString);

            if(areAllCharactersEnglishLetters)
            {
                printNumberOfUpperCaseLettersIfStringIsAllEnglishLetters(userInputString);
                printIsReversedAlphabeticalOrderIfStringIsAllEnglishLetters(userInputString);
            }

        }

        private static string printRequirementMessageCheckValidityAndGetUserInput()
        {
            Console.WriteLine("Please enter an 8 character string: ");
            string userInputString = Console.ReadLine();

            while(userInputString == null || userInputString.Length != 8)
            {
                Console.WriteLine("Invalid input! Please enter an 8 character string: ");
                userInputString = Console.ReadLine();
            }

            return userInputString;
        }

        private static bool isUserInputPalindrome(string i_UserStringInput)
        {
            bool isPalindromeResult = false;

            if(i_UserStringInput.Length <= 1)
            {
                isPalindromeResult = true;
            }
            else if(i_UserStringInput[0] != i_UserStringInput[i_UserStringInput.Length - 1])
            {
                isPalindromeResult = false;
            }
            else
            {
                isPalindromeResult =
                    isUserInputPalindrome(i_UserStringInput.Substring(1, i_UserStringInput.Length - 2));
            }

            return isPalindromeResult;
        }

        private static void printIsStringPalindrome(string i_UserInputString)
        {
            bool isPalindrome = isUserInputPalindrome(i_UserInputString);
            string isPalindromeSubString = isPalindrome ? "" : "not ";
            string palindromeMessage = string.Format("The string is {0}a palindrome.", isPalindromeSubString);

            Console.WriteLine(palindromeMessage);
        }

        private static void printIsNumberDivisibleByFourIfStringIsNumber(string i_UserInputString)
        {
            // bool areAllCharactersDigits = userInputString.All(char.IsDigit);
            bool areAllCharactersDigits = int.TryParse(i_UserInputString, out int userInputNumber);

            if(areAllCharactersDigits)
            {
                string isFourDivisibleSubString = userInputNumber % 4 == 0 ? "" : "not ";
                string fourDivisibleMessage = string.Format(
                    "The number is {0}divisible by 4.",
                    isFourDivisibleSubString);
                Console.WriteLine(fourDivisibleMessage);
            }
        }

        private static void printNumberOfUpperCaseLettersIfStringIsAllEnglishLetters(string i_UserInputString)
        {
            int numOfUpperCaseLetters = 0;

            for(int i = 0; i < i_UserInputString.Length; i++)
            {
                if(char.IsUpper(i_UserInputString[i]))
                {
                    numOfUpperCaseLetters++;
                }
            }

            string upperCaseLettersMessage = string.Format(
                "The number of uppercase letters in the string is: {0}.",
                numOfUpperCaseLetters);

            Console.WriteLine(upperCaseLettersMessage);
        }

        private static bool isAllEnglishLetters(string i_UserInputString)
        {
            bool isAllEnglishLetters = true;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if ((i_UserInputString[i] < 'A' || i_UserInputString[i] > 'Z')
                    && (i_UserInputString[i] < 'a' || i_UserInputString[i] > 'z'))
                {
                    isAllEnglishLetters = false;
                    break;
                }
            }

            return isAllEnglishLetters;
        }

        private static void printIsReversedAlphabeticalOrderIfStringIsAllEnglishLetters(string i_UserInputString)
        {
            string allLowerCasedString = i_UserInputString.ToLower();
            bool isStringInReverseAlphabeticalOrder = true;

            for(int i = 0; i < allLowerCasedString.Length - 1; i++)
            {
                if(allLowerCasedString[i] < allLowerCasedString[i + 1])
                {
                    isStringInReverseAlphabeticalOrder = false;
                    break;
                }
            }

            string reverseAlphabeticalOrderSubString = isStringInReverseAlphabeticalOrder ? "" : "not ";
            string reverseAlphabeticalOrderMessage = string.Format(
                "The string is {0}in reverse alphabetical order.",
                reverseAlphabeticalOrderSubString);

            Console.WriteLine(reverseAlphabeticalOrderMessage);
        }
    } 


}