using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        public static void runApp()
        {
            const int desiredAmountOfNumbers = 4;
            const int desiredBinaryNumberLength = 7;
            int currentAmountOfNumbers = 0;
            string[] binaryNumbers;
            int[] decimalNumbers = new int[desiredAmountOfNumbers];
            bool isCurrentBinaryNumberParsable = false;
            
            Console.WriteLine("Please enter 4 binary numbers.");
            Console.WriteLine("Each binary number entered must be exactly 7 characters long and contain only 0 or 1: ");
            while (currentAmountOfNumbers < desiredAmountOfNumbers)
            {
                string currentUserEnteredBinaryNumber = Console.ReadLine();
                isCurrentBinaryNumberParsable = isParsable(currentUserEnteredBinaryNumber, desiredBinaryNumberLength);
                if (isCurrentBinaryNumberParsable == true)
                {
                    decimalNumbers[currentAmountOfNumbers] = convertBinaryNumberToDecimalNumber(currentUserEnteredBinaryNumber);
                    currentAmountOfNumbers++;
                }
                else
                {
                    Console.WriteLine("The number entered does not match the criteria and is therefore invalid.");
                    Console.WriteLine("Please enter a new valid binary number, exactly 7 characters long and containing only 0 or 1:");
                }
            }

            mergeSortToDecimalNumbersArray(decimalNumbers);
            convertDecimalNumbersArrayToBinaryNumbersArray(out binaryNumbers, decimalNumbers, desiredBinaryNumberLength);
            printStatisticsOnNumbers(decimalNumbers, binaryNumbers);
        }

        private static bool isParsable(string binaryNumber, int desiredBinaryNumberLength)
        {
            if (binaryNumber == null)
            {
                return false;
            }

            int binaryNumberLength = binaryNumber.Length;
            if (binaryNumberLength != desiredBinaryNumberLength)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < binaryNumberLength; i++)
                {
                    if (binaryNumber[i] != '0' && binaryNumber[i] != '1')
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private static int convertBinaryNumberToDecimalNumber(string binaryNumber)
        {
            int result = 0;
            binaryNumberLength = binaryNumber.Length;
            for (int i = 0; i < binaryNumberLength; i++)
            {
                if (binaryNumber[i] == '1')
                {
                    result += (int)Math.Pow(2, binaryNumberLength - 1 - i);
                }
            }
            
            return result;
        }

        public static void mergeSortToDecimalNumbersArray(int[] decimalNumbers)
        {
            if (decimalNumbers == null || decimalNumbers.Length < 2)
            {
                return;
            }

            mergeSort(decimalNumbers, 0, decimalNumbers.Length - 1, new int[decimalNumbers.Length]);
        }

        private static void mergeSort(int[] array, int left, int right, int[] tempArray)
        {
            if (left >= right)
            {
                return;
            }

            int middle = left + ((right - left) / 2);
            mergeSort(array, left, middle, tempArray);
            mergeSort(array, middle + 1, right, tempArray);
            merge(array, left, middle, right, tempArray);
        }

        private static void merge(int[] array, int left, int middle, int right, int[] tempArray)
        {
            int leftIndex = left;
            int rightIndex = middle + 1;
            int tempIndex = left;

            while (leftIndex <= middle && rightIndex <= right)
            {
                if (array[leftIndex] <= array[rightIndex])
                {
                    tempArray[tempIndex++] = array[leftIndex++];
                }
                else
                {
                    tempArray[tempIndex++] = array[rightIndex++];
                }
            }

            while (leftIndex <= middle)
            {
                tempArray[tempIndex++] = array[leftIndex++];
            }

            while (rightIndex <= right)
            {
                tempArray[tempIndex++] = array[rightIndex++];
            }

            for (int i = left; i <= right; i++)
            {
                array[i] = tempArray[i];
            }
        }

        private static void convertDecimalNumbersArrayToBinaryNumbersArray(out string[] binaryNumbers, int[] decimalNumbers, int desiredBinaryNumberLength)
        {
            binaryNumbers = new string[decimalNumbers.Length];
            for (int i = 0; i < decimalNumbers.Length; i++)
            {
                binaryNumbers[i] = convertDecimalNumberToBinaryNumber(decimalNumbers[i], desiredBinaryNumberLength);
            }
        }

        private static string convertDecimalNumberToBinaryNumber(int decimalNumber, int desiredBinaryNumberLength)
        {
            string resultBinaryNumber = "0000000";
            
            if (decimalNumber == 0)
            {
                return resultBinaryNumber;
            }
            else
            {
                int i = 0;
                string reversedBinaryNumber = new string[desiredBinaryNumberLength];
                while (decimalNumber > 0)
                {
                    reversedBinaryNumber[i] = decimalNumber % 2;
                    decimalNumber /= 2;
                    i++;
                }

                for (; i > 0; i--)
                {
                    resultBinaryNumber[desiredBinaryNumberLength - i] = reversedBinaryNumber[i - 1];
                }
                return resultBinaryNumber;
            }
        }

        private static void printStatisticsOnNumbers(int[] decimalNumbers, string[] binaryNumbers)
        {
            printAllNumberInDescendingOrder(decimalNumbers, binaryNumbers);
            printAverageOfAllNumber(decimalNumbers);
            printLongestBitSequenceOfAbinaryNumber(binaryNumbers);
            printTotalOfOneBitsInBinaryNumbers(binaryNumbers);
            printNumberOfBinaryNumbersTransitions(binaryNumbers, decimalNumbers);
            printNumbersDivisibleByFour(binaryNumbers);
        }

        private static void printAllNumberInDescendingOrder(int[] decimalNumbers, string[] binaryNumbers)
        {
            StringBuilder allNumbersStringOutput = new StringBuilder("Decimal numbers in descending order: ");
            for (int i = 0; i < decimalNumbers.Length; i++)
            {
                allNumbersStringOutput.Append(decimalNumbers[i] + "(" + binaryNumbers[i] + ")");
                if (i != decimalNumbers.Length - 1)
                {
                    allNumbersStringOutput.Append(", ");
                }
            }

            Console.WriteLine(allNumbersStringOutput.ToString());
        }

        private static void printAverageOfAllNumber(int[] decimalNumbers)
        {
            float averageOfAllNumber = 0;
            for (int i = 0; i < decimalNumbers.Length; i++)
            {
                averageOfAllNumber += decimalNumbers[i];
            }
            averageOfAllNumber /= decimalNumbers.Length;
            string averageString = string.Format("Average: {0}", averageOfAllNumber);
            Console.WriteLine(averageString);
        }

        private static void printLongestBitSequenceOfAbinaryNumber(string[] binaryNumbers)
        {
            int binaryNumberLength = binaryNumbers[0].Length;
            int longestBitSequenceOfABinaryNumber = 0;
            int binaryNumbersWithLongestBitsSequenceCounter = 0;
            string[] binaryNumbersWithLongestBitSequence = new string[binaryNumbers.Length];

            for (int i = binaryNumbers.Length - 1; i > 0; i--)
            {
                string currentBinaryNumber = binaryNumbers[i];
                for (int j = 0; j < currentBinaryNumber.Length; j++)
                {
                    int currentBitSequence = 1;
                    while (j < currentBinaryNumber.Length - 1)
                    {
                        if (currentBinaryNumber[j] == currentBinaryNumber[j + 1])
                        {
                            currentBitSequence++;
                        }
                        else
                        {
                            currentBitSequence = 1;
                        }
                        j++;
                        
                        if (currentBitSequence == longestBitSequenceOfABinaryNumber)
                        {
                            binaryNumbersWithLongestBitSequence[binaryNumbersWithLongestBitsSequenceCounter] = currentBinaryNumber;
                            binaryNumbersWithLongestBitsSequenceCounter++;
                        }
                        
                        if (currentBitSequence > longestBitSequenceOfABinaryNumber)
                        {
                            binaryNumbersWithLongestBitsSequenceCounter = 0;
                            longestBitSequenceOfABinaryNumber = currentBitSequence;
                            binaryNumbersWithLongestBitSequence[binaryNumbersWithLongestBitsSequenceCounter] = currentBinaryNumber;
                            binaryNumbersWithLongestBitsSequenceCounter++;
                        }
                    }
                }
            }
            
            string startString = string.Format("Longest bit sequence: {0}",  longestBitSequenceOfABinaryNumber);
            StringBuilder longestBitSequenceMessage = new StringBuilder(startString);

            if (binaryNumbersWithLongestBitsSequenceCounter > 0)
            {
                longestBitSequenceMessage.Append("(");
                for (int j = 0; j < binaryNumbersWithLongestBitsSequenceCounter; j++)
                {
                    longestBitSequenceMessage.Append(binaryNumbersDvisibleByFour[binaryNumbersWithLongestBitsSequenceCounter]);
                    if (j < binaryNumbersWithLongestBitsSequenceCounter - 1)
                    {
                        longestBitSequenceMessage.Append(", ");
                    }
                }
                longestBitSequenceMessage.Append(")");
            }
            Console.WriteLine(longestBitSequenceMessage);
        }

        private static void printTotalOfOneBitsInBinaryNumbers(string[] binaryNumbers)
        {
            int totalOfOneBitsInBinaryNumberCounter = 0;
            int binaryNumbersLength = binaryNumbers.Length;

            for (int i = 0; i < binaryNumbersLength; i++)
            {
                string currentBinaryNumber = binaryNumbers[i];
                
                for (int j = 0; j < currentBinaryNumber.Length; j++)
                {
                    if (currentBinaryNumber[j] == '1')
                    {
                        totalOfOneBitsInBinaryNumberCounter++;
                    }
                }
            }
            
            string totalOfOneBitsMessage = string.Format("Total 1-bits: {0}", totalOfOneBitsInBinaryNumberCounter);
            Console.WriteLine(totalOfOneBitsMessage);
        }

        private static void printNumberOfBinaryNumbersTransitions(string[] binaryNumbers, int[] decimalNumbers)
        {
            int mostTransitionsCounter = 0;
            int currentTransitionsCounter = 0;
            int binaryNumbersLength = binaryNumbers.Length;
            int decimalNumberWithMostTransitions = 0;
            string binaryNumberWithMostTransitions = new string[binaryNumberLength];
            
            for (int i = 0; i < binaryNumbersLength; i++)
            {
                string currentBinaryNumber = binaryNumbers[i];
                
                for (int j = 0; j < currentBinaryNumber.Length - 1; j++)
                {
                    if (currentBinaryNumber[j] != currentBinaryNumber[j+1])
                    {
                        currentTransitionsCounter++;
                    }
                }
                
                if (currentTransitionsCounter >= mostTransitionsCounter)
                {
                    mostTransitionsCounter = currentTransitionsCounter;
                    binaryNumberWithMostTransitions = currentBinaryNumber;
                    decimalNumberWithMostTransitions = decimalNumbers[i];
                }
                
                string numberWithMostTranstionsMessage = string.Format("Number with most transitions: {0} ({1}) - {2} transitions", decimalNumberWithMostTransitions, binaryNumberWithMostTransitions, mostTransitionsCounter);
                Console.WriteLine(numberWithMostTranstionsMessage);
            }
        }

        private static void printNumbersDivisibleByFour(string[] binaryNumbers)
        {
            int counterOfNumbersDivisibleByFour = 0;
            int binaryNumbersLength = binaryNumbers.Length;
            string[] binaryNumbersDvisibleByFour = new string[binaryNumbersLength];

            for (int i = 0; i < binaryNumbersLength; i++)
            {
                string currentBinaryNumber = binaryNumbers[i];
                if currentBinaryNumber.EndsWith("00")
                {
                    binaryNumbersDvisibleByFour[counterOfNumbersDivisibleByFour] = currentBinaryNumber;
                    counterOfNumbersDivisibleByFour++;
                }
            }

            string startString = string.Format("Numbers divisible by 4: {0}",  ounterOfNumbersDivisibleByFour);
            StringBuilder numbersDivisibleByFourString = new StringBuilder(startString);

            if (counterOfNumbersDivisibleByFour > 0)
            {
                numbersDivisibleByFourString.Append("(");
                for (int j = 0; j < counterOfNumbersDivisibleByFour; j++)
                {
                    numbersDivisibleByFourString.Append(binaryNumbersDvisibleByFour[counterOfNumbersDivisibleByFour]);
                    if (j < counterOfNumbersDivisibleByFour - 1)
                    {
                        numbersDivisibleByFourString.Append(", ");
                    }
                }
                numbersDivisibleByFourString.Append(")");
            }
            Console.WriteLine(numbersDivisibleByFourString);
        }
    }
}