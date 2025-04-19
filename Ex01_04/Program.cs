using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01_04
{
    class Program
    {
        public static void Main()
        {
            string inputString;
            bool isInputStringValid;
            bool isInputStringPalindrom;
            bool isInputStringAllDigits;
            bool isInputStringAllLetters;
            bool isInputStringAscendingAlphabeticalOrder;

            System.Console.WriteLine("Please enter 12 characters string.");
            inputString = Console.ReadLine();
            isInputStringValid = checkInputValidation(inputString);
            while (!isInputStringValid)
            {
                System.Console.WriteLine("Please enter 12 characters string.");
                inputString = Console.ReadLine();
                isInputStringValid = checkInputValidation(inputString);
            }
            isInputStringPalindrom = checkIfInputStringAPalindrom(inputString);
            if (isInputStringPalindrom)
            {
                System.Console.WriteLine("Is it a palindrome: Yes");
            }
            else
            {
                System.Console.WriteLine("Is it a palindrome: No");
            }
            isInputStringAllDigits = checkIfStringAllDigits(inputString);
            if (isInputStringAllDigits)
            {
                bool isDividedBy3;
                isDividedBy3 = checkIfStringDividedBy3(inputString);
                if (isDividedBy3)
                {
                    System.Console.WriteLine("Is it divided by 3: Yes");
                }
                else
                {
                    System.Console.WriteLine("Is it divided by 3: No");
                }
            }
            isInputStringAllLetters = checkIfStringAllLetters(inputString);
            if (isInputStringAllLetters)
            {
                int HowManyUpperCaseCharacters;
                HowManyUpperCaseCharacters = checkManyUpperCaseCharacters(inputString);
                Console.WriteLine("Number of uppercase letters: {0}" , HowManyUpperCaseCharacters);
                isInputStringAscendingAlphabeticalOrder = checkIfInputStringAscendingAlphabeticalOrder(inputString);
                if (isInputStringAscendingAlphabeticalOrder)
                {
                    System.Console.WriteLine("Are the characters in ascending alphabetical order: Yes");
                }
                else
                {
                    System.Console.WriteLine("Are the characters in ascending alphabetical order: No");
                }
            }
            System.Console.WriteLine("Please press 'Enter' to exit...");
            System.Console.ReadLine();
        }
        private static bool checkInputValidation(string i_inputString)
        {
            return i_inputString.Length == 12 && i_inputString.All(char.IsLetterOrDigit);
        }

        private static bool checkIfInputStringAPalindrom(string i_inputString)
        {
            string lowerInput = i_inputString.ToLower();
            return checkIfPalindromRec(lowerInput, 0, lowerInput.Length - 1);
        }

        private static bool checkIfPalindromRec(string i_inputString, int left, int right)
        {
            if (left >= right)
            {
                return true;
            }
            if (i_inputString[left] != i_inputString[right])
            {
                return false;
            }
            return checkIfPalindromRec(i_inputString, left + 1, right - 1);
        }

        private static bool checkIfStringAllDigits(string i_inputString)
        {
            return i_inputString.All(char.IsDigit);
        }

        private static bool checkIfStringDividedBy3(string i_inputString)
        {
            if (double.Parse(i_inputString) % 3 == 0)
            {
                return true;
            }
            return false;
        }

        private static bool checkIfStringAllLetters(string i_inputString)
        {
            return i_inputString.All(char.IsLetter);
        }

        private static int checkManyUpperCaseCharacters(string i_inputString)
        {
            return i_inputString.Count(char.IsUpper);
        }

        private static bool checkIfInputStringAscendingAlphabeticalOrder(string i_inputString)
        {
            string lowerInput = i_inputString.ToLower();
            for (int i = 0; i < i_inputString.Length - 1; i++)
            {
                if (lowerInput[i] > lowerInput[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
