using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_03
{
    class Program
    {
        public static void Main()
        {
            int leafDigitToPrint = 0;
            char FloorOfTree = 'A';

            int[] digitsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            recursionFunc(digitsArray, leafDigitToPrint,FloorOfTree);
            Console.ReadLine();
        }

        public static void recursionFunc(int[] i_digitsArray, int i_nextLeafDigitToPrint, char i_FloorOfTree)
        {
            int digitsPrintedInThisFloor = 2*(i_FloorOfTree - 'A' + 1) - 1;
            string stringToPrint = GetDigitsToPrintByFloor(i_FloorOfTree, i_digitsArray, i_nextLeafDigitToPrint, digitsPrintedInThisFloor);
            string formattedString1 = String.Format("{0}  {1}", i_FloorOfTree, stringToPrint);
            Console.WriteLine(formattedString1);
            i_FloorOfTree++;
            if(i_FloorOfTree < 'E')
            {
             recursionFunc(i_digitsArray, i_nextLeafDigitToPrint + digitsPrintedInThisFloor, i_FloorOfTree);
            }

        }

        public static string GetDigitsToPrintByFloor(char floor, int[] io_digitsArray, int i_nextLeafDigitToPrint, int digitsPrintedInThisFloor)
        {
            char[] arrayToPrint = new string(' ', 16).ToCharArray();
            int indexOffset = 2*(floor - 'A') - 1;
            int startingPoint = (arrayToPrint.Length) / 2 - indexOffset;
            
            for (int i = 0; i< digitsPrintedInThisFloor; i++)
            {   
                if (i_nextLeafDigitToPrint > 8)
                {
                    i_nextLeafDigitToPrint = 0;
                }
                arrayToPrint[startingPoint] = (char)(io_digitsArray[i_nextLeafDigitToPrint] + 48);
                i_nextLeafDigitToPrint++;
                
                startingPoint += 2;
            }
            string stringToPrint = new string(arrayToPrint);
            return stringToPrint;
        }
    }
}
