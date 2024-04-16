namespace connect {
class Reader {

    public static void Read() {

     string filePath = "data.csv";

          using StreamReader reader = new StreamReader(filePath);
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