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
            var hasNumberOrLetter = new Regex(@"^(?=.*[a-zA-Z0-9]).{7,16}$");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-,',""]");
            Console.WriteLine(@"

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/                                
            ");
            Console.WriteLine();
            Console.WriteLine("     Welcome to the Watchlist!");
            Console.WriteLine("     Please register!");
            Console.Write("     Enter Username: ");
            userId = Console.ReadLine();
            Console.Write("     Enter Password: ");
            password = Console.ReadLine();

            while (!hasUpperChar.IsMatch(userId))
            {
                Console.WriteLine("     Username does not contain uppercase letters, please try again!");
                Console.Write("     Enter a different ID: ");
                userId = Console.ReadLine();
                Console.Write("     Enter Password: ");
                password = Console.ReadLine();
            }
            while (!hasNumberOrLetter.IsMatch(password) || hasSymbols.IsMatch(password))
            {
                Console.WriteLine("     Password must contain  7 to 16 letters or numbers and cannot contain symbols, please try again!");
                Console.Write("     Enter a different password: ");
                password = Console.ReadLine();
            }
        }
    }
}
