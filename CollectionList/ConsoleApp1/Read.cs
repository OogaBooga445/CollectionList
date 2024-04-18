namespace connect {
class Reader {

    public static void Read() {

     string filePath = "data.csv";

    using StreamReader reader = new StreamReader(filePath);
    Console.WriteLine(@"

     _       __      __       __    __    _      __ 
    | |     / /___ _/ /______/ /_  / /   (_)____/ /_
    | | /| / / __ `/ __/ ___/ __ \/ /   / / ___/ __/
    | |/ |/ / /_/ / /_/ /__/ / / / /___/ (__  ) /_  
    |__/|__/\__,_/\__/\___/_/ /_/_____/_/____/\__/  
            ");
            Console.WriteLine();
          while (!reader.EndOfStream)
          {
              string line = reader.ReadLine();
              string[] values = line.Split(',');


              foreach (string value in values)
              {
                  Console.Write(value + " ");
              }
              Console.WriteLine();
          }
        }
    }
}