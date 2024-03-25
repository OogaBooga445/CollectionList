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

            Console.WriteLine("Ievadi ID: ");
            userId = Console.ReadLine();
            Console.WriteLine("Ievadi Paroli: ");
            password = Console.ReadLine();

            while (!hasUpperChar.IsMatch(userId))
            {
                Console.WriteLine("ID nesatur Lielos burtus, mēģiniet vēlreiz!");
                Console.WriteLine("Ievadiet citu ID: ");
                userId = Console.ReadLine();
                Console.WriteLine("Ievadiet Paroli: ");
                password = Console.ReadLine();
            }
            while (hasSymbols.IsMatch(password))
            {
                Console.WriteLine("Parole nevar saturēt simbolus,mēģiniet vēlreiz!");
                Console.WriteLine("Ievadiet citu paroli: ");
                password = Console.ReadLine();
            }
            Console.Clear();

            Console.WriteLine("Konts izveidots");
        }
    }
}
