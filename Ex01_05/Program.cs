using System;
using System.Linq;
 

namespace Ex01_05
{   class Program
    {
        public static void Main()
        {
            string inputString;
            bool isInputStringValid;
            System.Console.WriteLine("Please enter a 8 digits number:");
            inputString = Console.ReadLine();
            isInputStringValid = checkInputValidation(inputString);
            while (!isInputStringValid)
            {
                System.Console.WriteLine("Please enter a 8 digits number:");
                inputString = Console.ReadLine();
                isInputStringValid = checkInputValidation(inputString);
            }
            int howManyNumbersAreSmallerThanTheFirst = checkhowManyNumbersAreSmallerThanTheFirst(inputString);
            Console.Write("The left digit is: {0}.", inputString[0]);
            Console.Write(" Digits smaller than it(excluding the first one): ");
            if (howManyNumbersAreSmallerThanTheFirst == 0)
            {
                Console.Write("none.");
            }
            else
            {
                printDigitsThatSmallerThanTheFirst(inputString, howManyNumbersAreSmallerThanTheFirst);
            }
            Console.WriteLine(" Total: {0}:",howManyNumbersAreSmallerThanTheFirst);
            int howManyDigitsAreDividedBy3 = checkhowManyDigitsAreDividedBy3(inputString);
            Console.Write("Digits divided by 3: ");
            if (howManyDigitsAreDividedBy3 == 0)
            {
                Console.Write("none.");
            }
            else
            {
                printDigitsThatDividedBy3(inputString, howManyDigitsAreDividedBy3);
            }
            Console.WriteLine(" Total: {0}:", howManyDigitsAreDividedBy3);
            int maxNumber = checkMaxNumber(inputString);
            int minNumber = checkMinNumber(inputString);
            Console.WriteLine("difference: {0}",maxNumber - minNumber);
            int howManyTimesTheMostFrequentNumberAppears = 0;
            int mostFrequentNumber = checkMostFrequentNumber(inputString, ref howManyTimesTheMostFrequentNumberAppears);
            //int howManyTimesTheMostFrequentNumberAppears = checkHowManyTimesTheMostFrequentNumberAppears(inputString, mostFrequentNumber);
            if (howManyTimesTheMostFrequentNumberAppears == 1)
            {
                Console.WriteLine("The most frequent digit is: {0} (appears 1 time)", mostFrequentNumber);
            }
            else
            {
                Console.WriteLine("The most frequent digit is: {0} (appears {1} time)", mostFrequentNumber, howManyTimesTheMostFrequentNumberAppears);
            }
        }
        private static bool checkInputValidation(string i_inputString)
        {
            return i_inputString.Length == 8 && i_inputString.All(char.IsDigit);
        }
        private static int checkhowManyNumbersAreSmallerThanTheFirst(string i_inputString)
        {
            int smallerNumbersCounter = 0;
            for (int i = 1; i < i_inputString.Length; i++)
            {
                if (i_inputString[0] > i_inputString[i])
                {
                    smallerNumbersCounter++;
                }
            }
            return smallerNumbersCounter;
        }
        private static void printDigitsThatSmallerThanTheFirst(string i_inputString, double i_howManyNumbersAreSmallerThanTheFirst)
        {
            int numCounter = 0;
            for (int i = 1; i < i_inputString.Length; i++)
            {
                if (i_inputString[0] > i_inputString[i])
                {
                    numCounter++;
                    if (numCounter < i_howManyNumbersAreSmallerThanTheFirst)
                    {
                        Console.Write("{0},", i_inputString[i]);
                    }
                    else
                    {
                        Console.Write("{0}.", i_inputString[i]);
                    }
                }

            }
        }
        private static int checkhowManyDigitsAreDividedBy3(string i_inputString)
        {
            int dividedBy3Counter = 0;
            for (int i = 0; i < i_inputString.Length; i++)
            {
                if (i_inputString[i] % 3 == 0)
                {
                    dividedBy3Counter++;
                }
            }
            return dividedBy3Counter;
        }
        private static void printDigitsThatDividedBy3(string i_inputString, double i_howManyDigitsAreDividedBy3)
        {
            int numCounter = 0;
            for (int i = 0; i < i_inputString.Length; i++)
            {
                if (i_inputString[i] % 3 == 0)
                {
                    numCounter++;
                    if (numCounter < i_howManyDigitsAreDividedBy3)
                    {
                        Console.Write("{0},", i_inputString[i]);
                    }
                    else
                    {
                        Console.Write("{0}.", i_inputString[i]);
                    }
                }

            }
        }
        private static int checkMaxNumber(string i_inputString)
        {
            int maxDigit = int.Parse(i_inputString[0].ToString()); ;
            for (int i = 1; i < i_inputString.Length; i++)
            {
                    int currentDigit = int.Parse(i_inputString[i].ToString());
                    maxDigit = Math.Max(maxDigit, currentDigit);
            }
            return maxDigit;
        }
        private static int checkMinNumber(string i_inputString)
        {
            int minDigit = int.Parse(i_inputString[0].ToString());

            for (int i = 1; i < i_inputString.Length; i++)
            {
                int currentDigit = int.Parse(i_inputString[i].ToString());
                minDigit = Math.Min(minDigit, currentDigit);
            }

            return minDigit;
        }
        private static int checkMostFrequentNumber(string i_inputString, ref int io_mostFrequentNumberCounter)
        {
            int mostFrequentDigit = 0;
            
            for (int currentDigit = 0; currentDigit < 10; currentDigit++)
            {
                int currentCounter = 0;

                for (int i = 0; i < i_inputString.Length; i++)
                {
                    
                    if (i_inputString[i] == (char)('0' + currentDigit))
                    {
                        currentCounter++;
                    }
                }

                if (currentCounter > io_mostFrequentNumberCounter || (currentCounter == io_mostFrequentNumberCounter && currentDigit > mostFrequentDigit))
                {
                    io_mostFrequentNumberCounter = currentCounter;
                    mostFrequentDigit = currentDigit;
                }
            }

            return mostFrequentDigit;
        }
        /*private static int checkHowManyTimesTheMostFrequentNumberAppears(string i_inputString, int i_mostFrequentNumber)
        {
            int mostFrequentNumberCounter = 1;

            for (int i = 0; i < i_inputString.Length; i++)
            {
                
                if (i_inputString[i] == i_mostFrequentNumber)
                {
                    mostFrequentNumberCounter++;
                }
            }

            return mostFrequentNumberCounter;
        }*/
    }
}
