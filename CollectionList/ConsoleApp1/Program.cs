namespace connect
{
  class Program {

    public static void Main(string[] args) {

      // Registry.Register();
      // Log_in.Login();
      Add.CreateAndDisplayArray();
      // Editor.Edit();
      string filePath = "data.csv";

      bool ascendingOrder = false; // Change this to true or false as needed
            
      // Call the Sort method to sort the CSV file by the second column in the specified order
      Sort.SortCsv(filePath, 1, ascendingOrder);
      Console.WriteLine($"CSV file sorted in {(ascendingOrder ? "ascending" : "descending")} order by the second column.");


      Reader.Read();

    } 
  }
}