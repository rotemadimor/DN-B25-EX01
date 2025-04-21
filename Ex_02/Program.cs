using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    public class Program
    {
        const int maxDigitIndex = 8;
        const int minDigitIndex = 0;
        const char space = ' ';
        const string TreeLog = "|8|";
        public static void Main()
        {
            char maxFloor = 'G';
            printTreeByFloor(maxFloor);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
        public static void printTreeByFloor(char maxFloor)
        {
            int leafDigitToPrint = 0;
            char FloorOfTree = 'A';
            int[] digitsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            recursionFunc(digitsArray, leafDigitToPrint, FloorOfTree, maxFloor);
        }

        public static void recursionFunc(int[] i_digitsArray, int i_nextLeafDigitToPrint, char i_FloorOfTree, char maxFloor)
        {
            int numberOfFloors = i_FloorOfTree - 'A';
            int digitsPrintedInThisFloor = 2 * (i_FloorOfTree - 'A') + 1;
            string stringToPrint = GetDigitsToPrintByFloor(i_FloorOfTree, i_digitsArray, i_nextLeafDigitToPrint, digitsPrintedInThisFloor, maxFloor);
            string formattedString1 = String.Format("{0}  {1}", i_FloorOfTree, stringToPrint);
            Console.WriteLine(formattedString1);
            i_FloorOfTree++;
            if (i_FloorOfTree <= maxFloor)
            {
                int nextDigit = GetNextDigitToPrintAsLeaf(i_nextLeafDigitToPrint, digitsPrintedInThisFloor);
                recursionFunc(i_digitsArray, nextDigit, i_FloorOfTree, maxFloor);
            }
        }
        private static int GetNextDigitToPrintAsLeaf(int i_nextLeafDigitToPrint, int digitsPrintedInThisFloor)
        {
            int nextDigitIndex = i_nextLeafDigitToPrint + digitsPrintedInThisFloor;
            if (nextDigitIndex > maxDigitIndex)
            {
                nextDigitIndex = minDigitIndex;
            }
            return nextDigitIndex;
        }

        private static string GetDigitsToPrintByFloor(char floor, int[] io_digitsArray, int i_nextLeafDigitToPrint, int digitsPrintedInThisFloor, char maxFloor)
        {
            int maxCharactersInFloor = maxFloor - 'A' + 14; // TODO
            char firstFloorOfTreeLog = (char)(maxFloor - 2);
            string stringToPrint = string.Empty;
            char[] arrayToPrint = new string(space, maxCharactersInFloor).ToCharArray();
            int indexOffset = 2 * (floor - 'A') - 1;
            int startingPoint = (arrayToPrint.Length) / 2 - indexOffset;
            if (floor < firstFloorOfTreeLog)
            {
                for (int i = 0; i < digitsPrintedInThisFloor; i++)
                {
                    if (i_nextLeafDigitToPrint > maxDigitIndex)
                    {
                        i_nextLeafDigitToPrint = minDigitIndex;
                    }
                    arrayToPrint[startingPoint] = (char)(io_digitsArray[i_nextLeafDigitToPrint] + 48);
                    i_nextLeafDigitToPrint++;

                    startingPoint += 2;
                }
                stringToPrint = new string(arrayToPrint);
            }
            else if (floor < maxFloor)
            {
                string rightSideSpaces = new string(space, 10);
                stringToPrint = string.Concat(rightSideSpaces, TreeLog);
            }
            return stringToPrint;
        }
    }
}
