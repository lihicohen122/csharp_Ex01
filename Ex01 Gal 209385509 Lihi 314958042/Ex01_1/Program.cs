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

        public static void runApp()
        {
            const int desiredAmountOfNumbers = 4;
            const int desiredBinaryNumberLength = 7;
            int currentAmountOfNumbers = 0;
            string[] binaryNumbers;
            int[] decimalNumbers = new int[desiredAmountOfNumbers];
            
            Console.WriteLine("Please enter 4 binary numbers.");
            Console.WriteLine("Each binary number entered must be exactly 7 characters long and contain only 0 or 1: ");
            while (currentAmountOfNumbers < desiredAmountOfNumbers)
            {
                string currentUserEnteredBinaryNumber = Console.ReadLine();
                bool isCurrentBinaryNumberParsable = isParsable(currentUserEnteredBinaryNumber, desiredBinaryNumberLength);
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
            int binaryNumberLength = binaryNumber.Length;
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
                if (array[leftIndex] >= array[rightIndex])
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

        private static string convertDecimalNumberToBinaryNumber(int decimalNumber, int length)
        {
            char[] binaryArray = new char[length];
            for(int i = 0; i < length; i++)
            {
                binaryArray[i] = '0';
            }

            int index = length - 1;
            while (decimalNumber > 0 && index >= 0)
            {
                binaryArray[index] = (char)((decimalNumber % 2) + '0');
                decimalNumber /= 2;
                index--;
            }

            return new string(binaryArray);
        }

        private static void printStatisticsOnNumbers(int[] decimalNumbers, string[] binaryNumbers)
        {
            printAllNumberInDescendingOrder(decimalNumbers, binaryNumbers);
            printAverageOfAllNumber(decimalNumbers);
            printLongestBitSequenceOfBinaryNumber(binaryNumbers);
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

        private static void printLongestBitSequenceOfBinaryNumber(string[] binaryNumbers)
        {
            if (binaryNumbers == null || binaryNumbers.Length == 0)
                return;

            string[] numbersWithMaxSequence = new string[4];
            int numbersCount = 0;
            int recordSequence = 0;

            foreach (string currentNumber in binaryNumbers)
            {
                int currentMax = getMaxBitSequence(currentNumber);

                if (currentMax > recordSequence)
                {
                    recordSequence = currentMax;
                    numbersCount = 0;
                    numbersWithMaxSequence[numbersCount++] = currentNumber;
                }
                else if (currentMax == recordSequence && currentMax > 0 && numbersCount < 4)
                {
                    numbersWithMaxSequence[numbersCount++] = currentNumber;
                }
            }

            string baseMessage = string.Format("Longest bit sequence: {0}", recordSequence);
            StringBuilder output = new StringBuilder(baseMessage);

            if (numbersCount > 0)
            {
                output.Append(" (");

                for (int i = 0; i < numbersCount; i++)
                {
                    output.Append(string.Format("{0}", numbersWithMaxSequence[i]));

                    if (i < numbersCount - 1)
                    {
                        output.Append(", ");
                    }
                }
                output.Append(")");
            }

            Console.WriteLine(output.ToString());
        }

        private static int getMaxBitSequence(string binaryNumber)
        {
            if (string.IsNullOrEmpty(binaryNumber))
                return 0;

            int maxCount = 1;
            int currentCount = 1;

            for (int i = 0; i < binaryNumber.Length - 1; i++)
            {
                if (binaryNumber[i] == binaryNumber[i + 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > maxCount)
                {
                    maxCount = currentCount;
                }
            }

            return maxCount;
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
            string binaryNumberWithMostTransitions = string.Empty;
            
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
                if (currentBinaryNumber.EndsWith("00"))
                {
                    binaryNumbersDvisibleByFour[counterOfNumbersDivisibleByFour] = currentBinaryNumber;
                    counterOfNumbersDivisibleByFour++;
                }
            }

            string startString = string.Format("Numbers divisible by 4: {0}",  counterOfNumbersDivisibleByFour);
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