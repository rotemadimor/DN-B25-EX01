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
            int leafDigitToPrint = 0;
            char FloorOfTree = 'A';
            int[] digitsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int inputValue = 0;
            System.Console.WriteLine("Please enter a number for a tree floors, between 4-15.");
            string inputFromUser = Console.ReadLine();
            while (!checkInputValidation(inputFromUser, out inputValue))
            {
                Console.WriteLine("Invalid input. Please enter a number between 4-15.");
                inputFromUser = Console.ReadLine();
            }
            
            FloorOfTree = (char)(inputValue + 'A');
            Ex_02.Program.PrintTreeByFloor(FloorOfTree);
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
        
        private static bool checkInputValidation(string i_inputFromUser, out int io_inputValue)
        {
            io_inputValue = 0;
            bool isInputValueValid = false;
            bool isInputTypeValid = !string.IsNullOrEmpty(i_inputFromUser) && int.TryParse(i_inputFromUser, out io_inputValue) ;
            
            if (isInputTypeValid)
            {
                isInputValueValid = io_inputValue >= 4 && io_inputValue <= 15;
            }
            
            return isInputValueValid;
        }
    }
}
