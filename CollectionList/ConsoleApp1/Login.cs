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
            Console.WriteLine("     Konts izveidots");
            Console.WriteLine();
            Console.WriteLine("     Ievadi datus lai ielogotos!");
            Console.WriteLine();
            Console.Write("     Ievadi ID: ");
            string ConfirmUserId = Console.ReadLine();
            Console.Write("     Ievadi Paroli: ");
            string ConfirmPassword = Console.ReadLine();

            while (true)
            {
                if (Registry.userId == ConfirmUserId && Registry.password == ConfirmPassword)
                {
                    Console.WriteLine("     Esat veiksmīgi ielogojies!");
                    break;
                }
                else
                {
                    Console.WriteLine("     Nepareizi ievadīti dati, Mēģini vēlreiz!");
                    Console.WriteLine();
                    Console.Write("     Ievadi ID: ");
                    ConfirmUserId = Console.ReadLine();
                    Console.Write("     Ievadi Paroli: ");
                    ConfirmPassword = Console.ReadLine();
                }
            }
        }
    }
}
