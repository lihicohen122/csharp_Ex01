using System;
using System.Text;

namespace Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        private static void runApp()
        {
            const int k_DesiredAmountOfNumbers = 4;
            const int k_DesiredBinaryNumberLength = 7;

            getUserInput(k_DesiredAmountOfNumbers, k_DesiredBinaryNumberLength, out int[] decimalNumbers);
            descendingMergeSortDecimalNumbersArray(decimalNumbers);
            convertDecimalNumbersArrayToBinaryNumbersArray(out string[] binaryNumbers, decimalNumbers, k_DesiredBinaryNumberLength);
            printStatisticsOnNumbers(decimalNumbers, binaryNumbers);
        }

        private static void getUserInput(int i_DesiredAmountOfNumbers, int i_DesiredBinaryNumberLength, out int[] o_DecimalNumbers)
        {
            int currentAmountOfNumbers = 0;
            o_DecimalNumbers = new int[i_DesiredAmountOfNumbers];

            Console.WriteLine("Please enter 4 binary numbers.");
            Console.WriteLine("Each binary number entered must be exactly 7 characters long and contain only 0 or 1: ");
            while(currentAmountOfNumbers < i_DesiredAmountOfNumbers)
            {
                string currentUserEnteredBinaryNumber = Console.ReadLine();
                bool isCurrentBinaryNumberParsable = isParsable(currentUserEnteredBinaryNumber, i_DesiredBinaryNumberLength);
                if(isCurrentBinaryNumberParsable)
                {
                    o_DecimalNumbers[currentAmountOfNumbers] = convertBinaryNumberToDecimalNumber(currentUserEnteredBinaryNumber);
                    currentAmountOfNumbers++;
                }
                else
                {
                    Console.WriteLine("The number entered does not match the criteria and is therefore invalid.");
                    Console.WriteLine("Please enter a new valid binary number, exactly 7 characters long and containing only 0 or 1:");
                }
            }
        }

        private static bool isParsable(string i_BinaryNumber, int i_DesiredBinaryNumberLength)
        {
            return !string.IsNullOrEmpty(i_BinaryNumber) && isBinary(i_BinaryNumber) && isCorrectLength(i_BinaryNumber, i_DesiredBinaryNumberLength);
        }

        private static bool isCorrectLength(string i_BinaryNumber, int i_DesiredBinaryNumberLength)
        {
            return i_BinaryNumber.Length == i_DesiredBinaryNumberLength;
        }

        private static bool isBinary(string i_BinaryNumber)
        { 
            bool isBinary = true;
            for(int i = 0; i < i_BinaryNumber.Length; ++i)
            {
                if(i_BinaryNumber[i] != '0' && i_BinaryNumber[i] != '1')
                {
                    isBinary = false;
                }
            }

            return isBinary;
        }

        private static int convertBinaryNumberToDecimalNumber(string i_BinaryNumber)
        {
            int result = 0;
            int binaryNumberLength = i_BinaryNumber.Length;

            for(int i = 0; i < binaryNumberLength; ++i)
            {
                if(i_BinaryNumber[i] == '1')
                {
                    result += (int)Math.Pow(2, binaryNumberLength - 1 - i);
                }
            }
            
            return result;
        }

        private static void descendingMergeSortDecimalNumbersArray(int[] i_DecimalNumbers)
        {
            if(i_DecimalNumbers == null || i_DecimalNumbers.Length < 2)
            {
                return;
            }

            mergeSort(i_DecimalNumbers, 0, i_DecimalNumbers.Length - 1, new int[i_DecimalNumbers.Length]);
        }

        private static void mergeSort(int[] i_DecimalNumbers, int i_Left, int i_Right, int[] i_TempDecimalsArray)
        {
            if(i_Left >= i_Right)
            {
                return;
            }

            int middle = i_Left + ((i_Right - i_Left) / 2);
            mergeSort(i_DecimalNumbers, i_Left, middle, i_TempDecimalsArray);
            mergeSort(i_DecimalNumbers, middle + 1, i_Right, i_TempDecimalsArray);
            merge(i_DecimalNumbers, i_Left, middle, i_Right, i_TempDecimalsArray);
        }

        private static void merge(int[] i_InputArray, int i_Left, int i_Middle, int i_Right, int[] i_TempArray)
        {
            int leftIndex = i_Left;
            int rightIndex = i_Middle + 1;
            int tempIndex = i_Left;

            while(leftIndex <= i_Middle && rightIndex <= i_Right)
            {
                if(i_InputArray[leftIndex] >= i_InputArray[rightIndex])
                {
                    i_TempArray[tempIndex++] = i_InputArray[leftIndex++];
                }
                else
                {
                    i_TempArray[tempIndex++] = i_InputArray[rightIndex++];
                }
            }

            while(leftIndex <= i_Middle)
            {
                i_TempArray[tempIndex++] = i_InputArray[leftIndex++];
            }

            while(rightIndex <= i_Right)
            {
                i_TempArray[tempIndex++] = i_InputArray[rightIndex++];
            }

            for(int i = i_Left; i <= i_Right; ++i)
            {
                i_InputArray[i] = i_TempArray[i];
            }
        }

        private static void convertDecimalNumbersArrayToBinaryNumbersArray(out string[] o_BinaryNumbers, int[] i_DecimalNumbers, int i_DesiredBinaryNumberLength)
        {
            o_BinaryNumbers = new string[i_DecimalNumbers.Length];
            for(int i = 0; i < i_DecimalNumbers.Length; ++i)
            {
                o_BinaryNumbers[i] = convertDecimalNumberToBinaryNumber(i_DecimalNumbers[i], i_DesiredBinaryNumberLength);
            }
        }

        private static string convertDecimalNumberToBinaryNumber(int i_DecimalNumber, int i_BinaryNumberLength)
        {
            char[] binaryNumber = new char[i_BinaryNumberLength];
            int index = i_BinaryNumberLength - 1;

            for (int i = 0; i < i_BinaryNumberLength; ++i)
            {
                binaryNumber[i] = '0';
            }
            
            while(i_DecimalNumber > 0 && index >= 0)
            {
                binaryNumber[index] = (char)((i_DecimalNumber % 2) + '0');
                i_DecimalNumber /= 2;
                index--;
            }

            return new string(binaryNumber);
        }

        private static void printStatisticsOnNumbers(int[] i_DecimalNumbers, string[] i_BinaryNumbers)
        {
            printAllNumberInDescendingOrder(i_DecimalNumbers, i_BinaryNumbers);
            printAverageOfAllNumber(i_DecimalNumbers);
            printLongestBitSequenceOfBinaryNumber(i_BinaryNumbers);
            printTotalOfOneBitsInBinaryNumbers(i_BinaryNumbers);
            printNumberOfMostBinaryNumbersTransitions(i_BinaryNumbers, i_DecimalNumbers);
            printNumbersDivisibleByFour(i_BinaryNumbers);
        }

        private static void printAllNumberInDescendingOrder(int[] i_DecimalNumbers, string[] i_BinaryNumbers)
        {
            StringBuilder allNumbersStringOutput = new StringBuilder("Decimal numbers in descending order: ");

            for(int i = 0; i < i_DecimalNumbers.Length; ++i)
            {
                allNumbersStringOutput.Append(i_DecimalNumbers[i] + "(" + i_BinaryNumbers[i] + ")");
                if(i != i_DecimalNumbers.Length - 1)
                {
                    allNumbersStringOutput.Append(", ");
                }
            }

            Console.WriteLine(allNumbersStringOutput.ToString());
        }

        private static void printAverageOfAllNumber(int[] i_DecimalNumbers)
        {
            float averageOfAllNumber = 0f;

            for(int i = 0; i < i_DecimalNumbers.Length; ++i)
            {
                averageOfAllNumber += i_DecimalNumbers[i];
            }

            averageOfAllNumber /= i_DecimalNumbers.Length;
            string averageString = string.Format("Average: {0:F2}", averageOfAllNumber);

            Console.WriteLine(averageString);
        }

        private static void printLongestBitSequenceOfBinaryNumber(string[] i_BinaryNumbers)
        {
            getLongestBitSequence(i_BinaryNumbers, out string[] numbersWithMaxSequence, out int numbersCount, out int recordSequence);
            string baseMessage = string.Format("Longest bit sequence: {0}", recordSequence);
            StringBuilder longestBitSequenceOfBinaryNumberOutput = new StringBuilder(baseMessage);

            if(numbersCount > 0)
            {
                longestBitSequenceOfBinaryNumberOutput.Append(" (");
                for(int i = 0; i < numbersCount; ++i)
                {
                    longestBitSequenceOfBinaryNumberOutput.Append(string.Format("{0}", numbersWithMaxSequence[i]));

                    if(i < numbersCount - 1)
                    {
                        longestBitSequenceOfBinaryNumberOutput.Append(", ");
                    }
                }

                longestBitSequenceOfBinaryNumberOutput.Append(")");
            }

            Console.WriteLine(longestBitSequenceOfBinaryNumberOutput.ToString());
        }

        private static void getLongestBitSequence(string[] i_BinaryNumbers, out string[] o_NumbersWithMaxSequence,
                                                  out int o_NumbersCount, out int o_RecordSequence)
        {
            o_NumbersWithMaxSequence = new string[4];
            o_NumbersCount = 0;
            o_RecordSequence = 0;

            if(i_BinaryNumbers == null || i_BinaryNumbers.Length == 0)
            {
                return;
            }

            foreach (string currentNumber in i_BinaryNumbers)
            {
                int currentMax = getMaxBitSequence(currentNumber);

                if(currentMax > o_RecordSequence)
                {
                    o_RecordSequence = currentMax;
                    o_NumbersCount = 0;
                    o_NumbersWithMaxSequence[o_NumbersCount] = currentNumber;
                    o_NumbersCount++;
                }
                else if(currentMax == o_RecordSequence && currentMax > 0 && o_NumbersCount < 4)
                {
                    o_NumbersWithMaxSequence[o_NumbersCount] = currentNumber;
                    o_NumbersCount++;
                }
            }
        }

        private static int getMaxBitSequence(string i_BinaryNumber)
        {
            int maxCount = 0;
            bool isInputValid = !string.IsNullOrEmpty(i_BinaryNumber);

            if(isInputValid)
            {
                maxCount = 1;
                int currentCount = 1;

                for(int i = 0; i < i_BinaryNumber.Length - 1; ++i)
                {
                    if(i_BinaryNumber[i] == i_BinaryNumber[i + 1])
                    {
                        currentCount++;
                    }
                    else
                    {
                        currentCount = 1;
                    }

                    if(currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }

            return maxCount;
        }

        private static void printTotalOfOneBitsInBinaryNumbers(string[] i_BinaryNumbers)
        {
            int totalOfOneBitsInBinaryNumberCounter = 0;
            int binaryNumbersLength = i_BinaryNumbers.Length;

            for(int i = 0; i < binaryNumbersLength; ++i)
            {
                string currentBinaryNumber = i_BinaryNumbers[i];
                
                for(int j = 0; j < currentBinaryNumber.Length; ++j)
                {
                    if(currentBinaryNumber[j] == '1')
                    {
                        totalOfOneBitsInBinaryNumberCounter++;
                    }
                }
            }
            
            string totalOfOneBitsMessage = string.Format("Total 1-bits: {0}", totalOfOneBitsInBinaryNumberCounter);

            Console.WriteLine(totalOfOneBitsMessage);
        }

        private static void printNumberOfMostBinaryNumbersTransitions(string[] i_BinaryNumbers, int[] i_DecimalNumbers)
        {
            int mostTransitionsCounter = 0;
            int currentTransitionsCounter = 0;
            int binaryNumbersLength = i_BinaryNumbers.Length;
            int decimalNumberWithMostTransitions = 0;
            string binaryNumberWithMostTransitions = string.Empty;
            
            for(int i = 0; i < binaryNumbersLength; ++i)
            {
                string currentBinaryNumber = i_BinaryNumbers[i];
                
                for(int j = 0; j < currentBinaryNumber.Length - 1; ++j)
                {
                    if(currentBinaryNumber[j] != currentBinaryNumber[j + 1])
                    {
                        currentTransitionsCounter++;
                    }
                }
                
                if(currentTransitionsCounter >= mostTransitionsCounter)
                {
                    mostTransitionsCounter = currentTransitionsCounter;
                    binaryNumberWithMostTransitions = currentBinaryNumber;
                    decimalNumberWithMostTransitions = i_DecimalNumbers[i];
                }

                currentTransitionsCounter = 0;
            }
            
            string numberWithMostTransitionsMessage = string.Format("Number with most transitions: {0} ({1}) - {2} transitions", decimalNumberWithMostTransitions, binaryNumberWithMostTransitions, mostTransitionsCounter);

            Console.WriteLine(numberWithMostTransitionsMessage);
        }

        private static void printNumbersDivisibleByFour(string[] i_BinaryNumbers)
        {
            getNumbersDivisibleByFour(i_BinaryNumbers, out string[] binaryNumbersDivisibleByFour, out int counterOfNumbersDivisibleByFour);
            string startString = string.Format("Numbers divisible by 4: {0}", counterOfNumbersDivisibleByFour);
            StringBuilder numbersDivisibleByFourString = new StringBuilder(startString);

            if(counterOfNumbersDivisibleByFour > 0)
            {
                numbersDivisibleByFourString.Append(" (");
                for(int j = 0; j < counterOfNumbersDivisibleByFour; ++j)
                {
                    numbersDivisibleByFourString.Append(binaryNumbersDivisibleByFour[j]);
                    if(j < counterOfNumbersDivisibleByFour - 1)
                    {
                        numbersDivisibleByFourString.Append(", ");
                    }
                }

                numbersDivisibleByFourString.Append(")");
            }

            Console.WriteLine(numbersDivisibleByFourString.ToString());
        }

        private static void getNumbersDivisibleByFour(string[] i_BinaryNumbers, out string[] o_BinaryNumbersDivisibleByFour, out int o_CounterOfNumbersDivisibleByFour)
        {
            int binaryNumbersLength = i_BinaryNumbers.Length;
            o_BinaryNumbersDivisibleByFour = new string[binaryNumbersLength];
            o_CounterOfNumbersDivisibleByFour = 0;

            for(int i = binaryNumbersLength - 1; i >= 0; --i)
            {
                string currentBinaryNumber = i_BinaryNumbers[i];

                if(currentBinaryNumber.EndsWith("00"))
                {
                    o_BinaryNumbersDivisibleByFour[o_CounterOfNumbersDivisibleByFour] = currentBinaryNumber;
                    o_CounterOfNumbersDivisibleByFour++;
                }
            }
        }
    }
}