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
            Ex_02.Program.recursionFunc(digitsArray, leafDigitToPrint, FloorOfTree);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }

       
    }
}
