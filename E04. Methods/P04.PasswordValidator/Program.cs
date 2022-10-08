namespace P04.PasswordValidator
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter min pass length: ");
            //int minLength = int.Parse(Console.ReadLine());
            //Console.Write("Enter max pass length: ");
            //int maxLength = int.Parse(Console.ReadLine());
            string inputPassword = Console.ReadLine();

            bool isLengthValid = IsPasswordLengthValid(inputPassword);
            bool isPassAlphanumeric = IsPasswordAlphaNumeric(inputPassword);
            bool hasTwoDigits = IsPasswordContaingAtLeastTwoDigits(inputPassword);

            if (!isLengthValid)
            {
                Console.WriteLine($"Password must be between 6 and 10 characters");
            }

            if (!isPassAlphanumeric)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!hasTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isLengthValid && isPassAlphanumeric && hasTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool IsPasswordLengthValid(string password)
        {
            bool isValid = password.Length >= 6 && password.Length <= 10;
            return isValid;
        }

        static bool IsPasswordAlphaNumeric(string password)
        {
            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    //Character different from digit or letter
                    return false;
                }
            }

            return true;
        }

        static bool IsPasswordContaingAtLeastTwoDigits(string password)
        {
            int digitsCnt = 0;
            foreach (char ch in password)
            {
                if (Char.IsDigit(ch))
                {
                    digitsCnt++;
                }
            }

            return digitsCnt >= 2;
        }
    }
}
