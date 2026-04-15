using System;
using System.Text;

namespace Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            printTree();
        }

        public static void printTree(int treeDepth = 7)
        {
            if (treeDepth < 4 || treeDepth > 15)
            {
                string invalidMessage = string.Format("The tree depth entered ({0}) is invalid. Please enter a new tree depth between 4 and 15.", treeDepth);
                Console.WriteLine(invalidMessage);
                return;
            }

            int maxWidth = (treeDepth - 2) * 2 - 1;
            int currentWidth = 1;
            int currentLevel = 1;
            char currentCharToPrint = 'A';

            while (currentLevel + 2 < treeDepth)
            {
                printLine(currentLevel, ref currentCharToPrint, currentWidth, maxWidth);
                currentLevel++;
                currentWidth += 2;
            }

            printRoot(currentLevel, currentCharToPrint, maxWidth);
            currentLevel++;
            printRoot(currentLevel, currentCharToPrint, maxWidth);
        }

    private static void printLine(int currentLevel, ref char currentCharToPrint, int currentWidth, int maxWidth)
    {
        string baseTreeLine = string.Format("{0} ", currentLevel);
        StringBuilder treeLine = new StringBuilder(baseTreeLine);
        int currentLettersAmount = 1;
        string spacesInTreeLine = new string(' ', ((maxWidth / 2) - currentWidth) * 2 - 1);

        treeLine.Append(spacesInTreeLine);
        treeLine.Append(' ');
        while (currentLettersAmount <= currentWidth)
        {
            treeLine.Append(currentCharToPrint);
            treeLine.Append(' ');
            currentCharToPrint = getNextChar(currentCharToPrint);
            currentLettersAmount++;
        }
        treeLine.Append(spacesInTreeLine);
        Console.WriteLine(treeLine.ToString());
    }

        private static char getNextChar(char currentChar)
        {
            return currentChar == 'Z' ? 'A' : (char)(currentChar + 1);
        }

    private static void printRoot(int currentLevel, char currentCharToPrint, int maxWidth)
    {
        string baseRootLine = string.Format("{0} ", currentLevel);
        StringBuilder rootLine = new StringBuilder(baseRootLine);
        string spacesInRootLine = new string(' ', ((maxWidth / 2) - 1) * 2 - 1);

        rootLine.Append(spacesInRootLine);
        rootLine.Append(string.Format("|{0}|", currentCharToPrint));
        rootLine.Append(spacesInRootLine);
        Console.WriteLine(rootLine.ToString());
    }
}
