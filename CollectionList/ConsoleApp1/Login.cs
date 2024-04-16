using System;

namespace connect
{
    class Log_in
    {
        public static void Login()
        {
            Console.Clear();
                   Console.WriteLine(@"
             ______      ____          __  _                __    _      __ 
            / ____/___  / / /__  _____/ /_(_)___  ____     / /   (_)____/ /_
           / /   / __ \/ / / _ \/ ___/ __/ / __ \/ __ \   / /   / / ___/ __/
          / /___/ /_/ / / /  __/ /__/ /_/ / /_/ / / / /  / /___/ (__  ) /_  
          \____/\____/_/_/\___/\___/\__/_/\____/_/ /_/  /_____/_/____/\__/  
            ");
            Console.WriteLine("Konts izveidots");
            Console.WriteLine();
            Console.WriteLine("Ievadi datus lai ielogotos!");
            Console.WriteLine();
            Console.Write("Ievadi ID: ");
            string ConfirmUserId = Console.ReadLine();
            Console.Write("Ievadi Paroli: ");
            string ConfirmPassword = Console.ReadLine();

            while (true)
            {
                if (Registry.userId == ConfirmUserId && Registry.password == ConfirmPassword)
                {
                    Console.WriteLine("Esat veiksmīgi ielogojies!");
                    break;
                }
                else
                {
                    Console.WriteLine("Nepareizi ievadīti dati, Mēģini vēlreiz!");
                    Console.WriteLine();
                    Console.Write("Ievadi ID: ");
                    ConfirmUserId = Console.ReadLine();
                    Console.Write("Ievadi Paroli: ");
                    ConfirmPassword = Console.ReadLine();
                }
            }
        }
    }
}
