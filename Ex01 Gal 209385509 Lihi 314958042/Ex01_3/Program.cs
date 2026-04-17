using System;

namespace Ex01_3
{
    public class Program
    {
        public static void Main()
        {
            runApp();
        }

        private static void runApp()
        {
            int treeDepth = getUserInput();
            Ex01_2.Program.PrintTree(treeDepth);
        }

        private static int getUserInput()
        {
            bool isTreeDepthNumber = printRequirementsMessageReceiveInputAndTryParse(out int userIntInputTreeHeight);

            while (isTreeDepthNumber == false || isValidTreeDepth(userIntInputTreeHeight) == false)
            {
                printIfNotANumberInputMessage(isTreeDepthNumber);
                if(isTreeDepthNumber == true)
                {
                    printIfNotAValidNumberRange(userIntInputTreeHeight);
                }

                isTreeDepthNumber = printRequirementsMessageReceiveInputAndTryParse(out userIntInputTreeHeight);
            }

            return userIntInputTreeHeight;
        }

        private static bool isValidTreeDepth(int i_TreeDepth)
        {
            return i_TreeDepth >= 4 && i_TreeDepth <= 15;
        }

        private static void printIfNotANumberInputMessage(bool i_IsTypeOfInputInteger)
        {
            if(i_IsTypeOfInputInteger == false)
            {
                Console.WriteLine("Invalid input! Input is not a number!");
            }
        }

        private static void printIfNotAValidNumberRange(int i_TreeDepth)
        {
            string invalidMessage = string.Format("The tree depth entered ({0}) is invalid.", i_TreeDepth);
            Console.WriteLine(invalidMessage);
        }

        private static bool printRequirementsMessageReceiveInputAndTryParse(out int io_UserIntInputTreeHeight)
        {
            Console.WriteLine("Please enter the desired tree height including the root (between 4 and 15): ");
            string userStringInputTreeHeight = Console.ReadLine();
            return int.TryParse(userStringInputTreeHeight, out io_UserIntInputTreeHeight);
        }
    }
}
