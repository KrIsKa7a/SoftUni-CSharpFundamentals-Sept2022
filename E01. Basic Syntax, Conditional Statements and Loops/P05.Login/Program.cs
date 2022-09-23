namespace P05.Login
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            //String index -> 0 to string.Length - 1
            //From end to start (reverse) -> from Length - 1 to 0
            string username = Console.ReadLine();
            string password = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                char currCh = username[i];
                password += currCh;
            }

            //string pass2 = String.Join("", username.Reverse());
            //From start to end -> From 0 to Length - 1
            //for (int i = 0; i < password.Length; i++)
            //{

            //}

            //While entered password is different from the correct one
            int totalTries = 1;
            string enteredPassword;
            while ((enteredPassword = Console.ReadLine()) != password)
            {
                //Wrong password is entered
                if (totalTries >= 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                totalTries++;
            }

            //Correct password OR Blocked User
            if (totalTries < 4)
            {
                //Correct password
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
