using System;

namespace connect
{
    class Log_in
    {
        public static void Login()
        {
            Console.Clear();
            Console.WriteLine(@"

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/  
            ");
             Console.WriteLine();
            Console.WriteLine("     Account created");
            Console.WriteLine();
            Console.WriteLine("     Enter data to log in!");
            Console.WriteLine();
            Console.Write("     Enter Username: ");
            string ConfirmUserId = Console.ReadLine();
            Console.Write("     Enter Password: ");
            string ConfirmPassword = Console.ReadLine();

            while (true)
            {
                if (Registry.userId == ConfirmUserId && Registry.password == ConfirmPassword)
                {
                    Console.WriteLine("     Successfully logged in!");
                    break;
                }
                else
                {
                    Console.WriteLine("     Incorrect data entered, Please try again!");
                    Console.WriteLine();
                    Console.Write("     Enter Username: ");
                    ConfirmUserId = Console.ReadLine();
                    Console.Write("     Enter Password: ");
                    ConfirmPassword = Console.ReadLine();
                }
            }
        }
    }
}
