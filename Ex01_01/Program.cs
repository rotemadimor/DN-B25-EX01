using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_01
{
    class Program
    {
        public static void Main()
        {
            bool isInputValid = false;
            String[] binaryNumbers = new string[4];
            int i = 0;

            while (i < 4)
            {
                System.Console.WriteLine("Please Enter a binary number with 7 digits");
                binaryNumbers[i] = Console.ReadLine();
                isInputValid = checkInputValidation(binaryNumbers[i]); //TODO
                if (isInputValid)
                {
                    i++;
                }
            }

            int[] decimalNumbers = new int[4];
            for(i = 0; i < 4; i++)
            {
                decimalNumbers[i] = convertBinaryToDecimal(binaryNumbers[i]);
            }
            Array.Sort(decimalNumbers);
            Array.Reverse(decimalNumbers);
            foreach (int number in decimalNumbers)
            {
                Console.WriteLine(number);
            }

            System.Console.WriteLine("Please press 'Enter' to exit...");
            System.Console.ReadLine();


        }

        private static bool checkInputValidation(string binaryNumbers) // TODO
        {
            //throw new NotImplementedException();
            return true;
        }

        private static int convertBinaryToDecimal(string i_binaryNumber)
        {
            int result = 0;
            int indexOfLSB = i_binaryNumber.Length - 1;
            for (int i = indexOfLSB; i >= 0 ; i--)
            {
                int currentDigitToAdd = int.Parse(i_binaryNumber[i].ToString());
                int exponent = 6 - i;
                result += currentDigitToAdd * (int)Math.Pow(2, exponent);
            }
            
            return result;
        }
    }
}
