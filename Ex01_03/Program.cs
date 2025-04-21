using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex_02;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            char FloorOfTree;
            System.Console.WriteLine("Please enter a number for a tree floors, between 4-15.");
            string inputFromUser = Console.ReadLine();
            while (!checkInputValidation(inputFromUser, out FloorOfTree))
            {
                Console.WriteLine("Invalid input. Please enter a number between 4-15.");
                inputFromUser = Console.ReadLine();
            }

            Ex_02.Program.printTreeByFloor(FloorOfTree);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }

        private static bool checkInputValidation(string inputFromUser, out char FloorOfTree)
        {
            FloorOfTree = ' ';
            //int inputValue;
            bool isInputValueValid = false;
            bool isInputTypeValid = !string.IsNullOrEmpty(inputFromUser) && inputFromUser.Length == 1;
            if (isInputTypeValid)
            {
                int inputValue = getInputValue(inputFromUser, out FloorOfTree);
                isInputValueValid = inputValue >= 4 && inputValue <= 15;
            }
            return isInputValueValid;
        }

        private static int getInputValue(string inputFromUser, out char FloorOfTree)
        {
            int floorNumber = int.Parse(inputFromUser);
            FloorOfTree = (char)(floorNumber + 'A');
            return floorNumber;
        }
    }
}
