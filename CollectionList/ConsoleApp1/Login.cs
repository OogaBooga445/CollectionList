namespace connect
{
    class Log_in
    {
        public static void Login()
        {
            Console.WriteLine("Ievadi datus lai ielogotos!");
            Console.WriteLine();
            Console.WriteLine("Ievadi ID: ");
            string ConfirmUserId = Console.ReadLine();
            Console.WriteLine("Ievadi Paroli: ");
            string ConfirmPassword = Console.ReadLine();
            while (Registry.userId != ConfirmUserId && Registry.password != ConfirmPassword || Registry.userId == ConfirmUserId && Registry.password != ConfirmPassword || Registry.userId != ConfirmUserId && Registry.password == ConfirmPassword)
            {
                Console.WriteLine("Nepareizi ievadīti dati, Mēģini vēlreiz!");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Ievadi ID: ");
                ConfirmUserId = Console.ReadLine();
                Console.WriteLine("Ievadi Paroli: ");
                ConfirmPassword = Console.ReadLine();

                if (Registry.userId == ConfirmUserId && Registry.password == ConfirmPassword)
                {
                    Console.WriteLine("Esat veiksmīgi ielogojies!");
                }
            }
        }
    }
}
