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

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/                                
            ");
            Console.WriteLine();
            Console.Write("     Ievadi ID: ");
            userId = Console.ReadLine();
            Console.Write("     Ievadi Paroli: ");
            password = Console.ReadLine();

            while (!hasUpperChar.IsMatch(userId))
            {
                Console.WriteLine("     ID nesatur Lielos burtus, mēģiniet vēlreiz!");
                Console.Write("     Ievadiet citu ID: ");
                userId = Console.ReadLine();
                Console.Write("     Ievadiet Paroli: ");
                password = Console.ReadLine();
            }
            while (hasSymbols.IsMatch(password))
            {
                Console.WriteLine("     Parole nevar saturēt simbolus,mēģiniet vēlreiz!");
                Console.Write("     Ievadiet citu paroli: ");
                password = Console.ReadLine();
            }
        }
    }
}

     