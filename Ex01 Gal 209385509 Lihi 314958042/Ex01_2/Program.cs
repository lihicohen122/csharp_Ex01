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
            int maxWidth = (i_TreeDepth - 2) * 2 - 1;

            if(i_TreeDepth < 3)
            {
                string invalidMessage = string.Format("The tree depth entered ({0}) is invalid. Please enter a new tree depth between 4 and 15.", i_TreeDepth);
                Console.WriteLine(invalidMessage);

                return;
            }

            printTreeRecursive(currentLevel, ref currentCharToPrint, currentWidth, maxWidth, i_TreeDepth);
        }

        private static void printTreeRecursive(int i_CurrentLevel, ref char i_CurrentCharToPrint, int i_CurrentWidth, int i_MaxWidth, int i_TreeDepth)
        {
            if(i_CurrentLevel + 2 > i_TreeDepth)
            {
                printRoot(i_CurrentLevel, i_CurrentCharToPrint, i_MaxWidth);
                printRoot(i_CurrentLevel + 1, i_CurrentCharToPrint, i_MaxWidth);

                return;
            }

            printLine(i_CurrentLevel, ref i_CurrentCharToPrint, i_CurrentWidth, i_MaxWidth);
            printTreeRecursive(i_CurrentLevel + 1, ref i_CurrentCharToPrint, i_CurrentWidth + 2, i_MaxWidth, i_TreeDepth);
        }

        private static void printLine(int i_CurrentLevel, ref char i_CurrentCharToPrint, int i_CurrentWidth, int i_MaxWidth)
        {
            string baseTreeLine = string.Format("{0}  ", i_CurrentLevel);
            StringBuilder treeLine = new StringBuilder(baseTreeLine);
            int currentLettersAmount = 1;
            string spacesInTreeLine = i_MaxWidth - i_CurrentWidth - 1 >= 0 ? new string(' ', i_MaxWidth - i_CurrentWidth - 1) : new string('\b', 1);

            treeLine.Append(spacesInTreeLine);
            treeLine.Append(' ');
            while(currentLettersAmount <= i_CurrentWidth)
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