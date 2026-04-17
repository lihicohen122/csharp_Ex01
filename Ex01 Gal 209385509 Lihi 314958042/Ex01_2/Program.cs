using System;
using System.Text;

namespace Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintTree();
        }

        public static void PrintTree(int i_TreeDepth = 7)
        {
            int currentWidth = 1;
            int currentLevel = 1;
            char currentCharToPrint = 'A';

            if (i_TreeDepth < 3)
            {
                string invalidMessage = string.Format("The tree depth entered ({0}) is invalid. Please enter a new tree depth between 4 and 15.", i_TreeDepth);
                Console.WriteLine(invalidMessage);
                return;
            }

            int maxWidth = (i_TreeDepth - 2) * 2 - 1;

            while (currentLevel + 2 <= i_TreeDepth)
            {
                printLine(currentLevel, ref currentCharToPrint, currentWidth, maxWidth);
                currentLevel++;
                currentWidth += 2;
            }

            printRoot(currentLevel, currentCharToPrint, maxWidth);
            currentLevel++;
            printRoot(currentLevel, currentCharToPrint, maxWidth);
        }

        private static void printLine(int i_CurrentLevel, ref char i_CurrentCharToPrint, int i_CurrentWidth, int i_MaxWidth)
        {
            string baseTreeLine = string.Format("{0}  ", i_CurrentLevel);
            StringBuilder treeLine = new StringBuilder(baseTreeLine);
            int currentLettersAmount = 1;
            string spacesInTreeLine = i_MaxWidth - i_CurrentWidth - 1 >= 0 ? new string(' ', i_MaxWidth - i_CurrentWidth - 1) : new string('\b', 1);

            treeLine.Append(spacesInTreeLine);
            treeLine.Append(' ');
            while (currentLettersAmount <= i_CurrentWidth)
            {
                treeLine.Append(i_CurrentCharToPrint);
                treeLine.Append(' ');
                i_CurrentCharToPrint = getNextChar(i_CurrentCharToPrint);
                currentLettersAmount++;
            }

            treeLine.Append(spacesInTreeLine);
            Console.WriteLine(treeLine.ToString());
        }

        private static char getNextChar(char i_CurrentChar)
        {
            return i_CurrentChar == 'Z' ? 'A' : (char)(i_CurrentChar + 1);
        }

        private static void printRoot(int i_CurrentLevel, char i_CurrentCharToPrint, int i_MaxWidth)
        {
            string baseRootLine = string.Format("{0}  ", i_CurrentLevel);
            StringBuilder rootLine = new StringBuilder(baseRootLine);
            string spacesInRootLine = new string(' ', i_MaxWidth - 2);

            rootLine.Append(spacesInRootLine);
            rootLine.Append(string.Format("|{0}|", i_CurrentCharToPrint));
            rootLine.Append(spacesInRootLine);
            Console.WriteLine(rootLine.ToString());
        }
    }
}
