using System.ComponentModel;
using connect;

namespace connect
{
  class Program {

    public static void Main(string[] args) {
      string filePath = "data.csv";

      //  Registry.Register();
      //  Log_in.Login();
      // Editor.Edit();

      // bool ascendingOrder = false; // Change this to true or false as needed
            
      // Sort.SortCsv(filePath, 1, ascendingOrder);
      // Console.WriteLine($"CSV file sorted in {(ascendingOrder ? "ascending" : "descending")} order by the second column.");


      // Add.AddRecord(filePath);
      // Reader.Read();
      // Remove.RemoveRecord(filePath);
      // Reader.Read();
      // SortByRating.SortAndSaveByRating(filePath);
      // Reader.Read();
      SortByRating.SortAndSaveByRating(filePath);
      // Reader.Read();
    } 
  }
}