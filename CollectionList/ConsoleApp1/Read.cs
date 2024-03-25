namespace connect {
class Reader {

    public static void Read() {

     string filePath = "data.csv";

          // Read the CSV file
          using StreamReader reader = new StreamReader(filePath);
          while (!reader.EndOfStream)
          {
              string line = reader.ReadLine();
              string[] values = line.Split(',');

              // Process the values as needed
              foreach (string value in values)
              {
                  Console.Write(value + " ");
              }
              Console.WriteLine();
          }
    }
    }
}