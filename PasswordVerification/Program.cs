using System;
using System.Text.RegularExpressions;

namespace PasswordVerification
{
    class Program
    {
        static void Main(string[] args)
        {
            Verification verification = new Verification();

            string password = "1S'ыф";
            int minimum = 5;

            bool isPasswordVerificated = verification.IsVerificated(password, minimum);

            if (isPasswordVerificated)
            {
                Console.WriteLine("Пароль соответствует требованиям.");
            }
            else
            {
                Console.WriteLine("Пароль не соответствует требованиям.");
            }

            Console.ReadKey();
        }
    }

    class Verification
    {
        public bool IsVerificated(string password, int minimum)
        {
            bool moreThanMinimum = MoreThanMinimum(password, minimum);
            bool includeSymbAndDigit = IncludeSymbolAndDigit(password);
            bool includeAnotherAlphabet = IncludeAnotherAlphabet(password);

            if (moreThanMinimum && includeAnotherAlphabet && includeSymbAndDigit)
            {
                return true;
            }
            else
            {
                if (!moreThanMinimum)
                {
                    Console.WriteLine($"Пароль должен содержать не менее {minimum} символов.");
                }
                if (!includeAnotherAlphabet)
                {
                    Console.WriteLine($"Пароль должен содержать буквы другого алфавита.");
                }
                if (!includeSymbAndDigit)
                {
                    Console.WriteLine($"Пароль должен содержать не менее одной цифры и одного знака препинания.");
                }

                return false;
            }
        }
        private bool MoreThanMinimum(string password, int minimum)
        {
            if (password.Length >= minimum)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IncludeSymbolAndDigit(string password)
        {
            bool isSymbol = false;
            bool isDigit = false;

            foreach (var charSymb in password)
            {
                if (Char.IsPunctuation(charSymb))
                {
                    isSymbol = true;
                }                
                if (Char.IsDigit(charSymb))
                {
                    isDigit = true;
                }
            }

            if (isSymbol && isDigit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IncludeAnotherAlphabet(string password)
        {
            bool isRus = false;
            bool isLatin = false;
            
            if (Regex.IsMatch(password, @"\p{IsCyrillic}"))
            {
                isRus = true;
            }            
            
            if (Regex.IsMatch(password, @"\p{IsBasicLatin}"))
            {
                isLatin = true;
            }

            if (isRus && isLatin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
