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
        public static void Main()
        {
            char maxFloor = 'G';
            PrintTreeByFloor(maxFloor);

            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }
        public static void PrintTreeByFloor(char i_maxFloor)
        {
            char FloorOfTree = 'A';
            int leafDigitToPrint = 0;
            int[] digitsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            recursionFunc(ref digitsArray, leafDigitToPrint, FloorOfTree, i_maxFloor);
        }

        private static void recursionFunc(ref int[] i_digitsArray, int i_nextLeafDigitToPrint,
                                         char i_FloorOfTree, char i_maxFloor)
        {
            int numberOfFloors = i_FloorOfTree - 'A';
            int digitsPrintedInThisFloor = 2 * (i_FloorOfTree - 'A') + 1;
            string stringToPrint = getDigitsToPrintByFloor(i_FloorOfTree, ref i_digitsArray, i_nextLeafDigitToPrint, digitsPrintedInThisFloor, i_maxFloor);
            Console.WriteLine($"{i_FloorOfTree}  {stringToPrint}");
            i_FloorOfTree++;
            if (i_FloorOfTree < i_maxFloor)
            {
                int nextDigit = getNextDigitToPrintAsLeaf(i_nextLeafDigitToPrint, digitsPrintedInThisFloor);
                recursionFunc(ref i_digitsArray, nextDigit, i_FloorOfTree, i_maxFloor);
            }
        }
        private static int getNextDigitToPrintAsLeaf(int i_nextLeafDigitToPrint, int i_digitsPrintedInThisFloor)
        {
            int nextDigitIndex = i_nextLeafDigitToPrint + i_digitsPrintedInThisFloor;
            if (nextDigitIndex > 8)
            {
                nextDigitIndex = 0;
            }
            return nextDigitIndex;
        }

        private static string getDigitsToPrintByFloor(char i_floor,ref int[] i_digitsArray, int i_nextLeafDigitToPrint, int i_digitsPrintedInThisFloor, char i_maxFloor)
        {
            int maxCharactersInFloor = 4*(i_maxFloor - 'A') + 5;
            int indexOffset = 2 * (i_floor - 'A') - 1;
            int startingPoint = maxCharactersInFloor / 2 - indexOffset;
            char firstFloorOfTreeLog = (char)(i_maxFloor - 2);
            char[] arrayToPrint = new string(' ', maxCharactersInFloor).ToCharArray();
            string stringToPrint = string.Empty;

            if (i_floor < firstFloorOfTreeLog)
            {
                for (int i = 0; i < i_digitsPrintedInThisFloor; i++)
                {
                    if (i_nextLeafDigitToPrint > 8)
                    {
                        i_nextLeafDigitToPrint = 0;
                    }
                    arrayToPrint[startingPoint] = (char)(i_digitsArray[i_nextLeafDigitToPrint] + 48);
                    i_nextLeafDigitToPrint++;
                    startingPoint += 2;
                }
                stringToPrint = new string(arrayToPrint);
            }
            else if (i_floor < i_maxFloor)
            {
                string rightSideSpaces = new string(' ', maxCharactersInFloor/2);
                stringToPrint = string.Concat(rightSideSpaces, "|8|");
            }
            return stringToPrint;
        }
    }
}
