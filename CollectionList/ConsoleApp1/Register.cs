using System;
using System.Text.RegularExpressions;

namespace connect
{
    class Registry
    {
        public static string userId;
        public static string password;

        public static void Register()
        {
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
                   Console.WriteLine(@"
             ______      ____          __  _                __    _      __ 
            / ____/___  / / /__  _____/ /_(_)___  ____     / /   (_)____/ /_
           / /   / __ \/ / / _ \/ ___/ __/ / __ \/ __ \   / /   / / ___/ __/
          / /___/ /_/ / / /  __/ /__/ /_/ / /_/ / / / /  / /___/ (__  ) /_  
          \____/\____/_/_/\___/\___/\__/_/\____/_/ /_/  /_____/_/____/\__/  
            ");

            Console.Write("Ievadi ID: ");
            userId = Console.ReadLine();
            Console.Write("Ievadi Paroli: ");
            password = Console.ReadLine();

            while (!hasUpperChar.IsMatch(userId))
            {
                Console.WriteLine("ID nesatur Lielos burtus, mēģiniet vēlreiz!");
                Console.Write("Ievadiet citu ID: ");
                userId = Console.ReadLine();
                Console.Write("Ievadiet Paroli: ");
                password = Console.ReadLine();
            }
            while (hasSymbols.IsMatch(password))
            {
                Console.WriteLine("Parole nevar saturēt simbolus,mēģiniet vēlreiz!");
                Console.Write("Ievadiet citu paroli: ");
                password = Console.ReadLine();
            }
        }
    }
}

     