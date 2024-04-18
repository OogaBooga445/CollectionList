using System.ComponentModel;
using connect;

namespace connect
{
  class Program {

    public static void Main(string[] args) {

      //  Registry.Register();
      //  Log_in.Login();
      // Editor.Edit();
      // string filePath = "data.csv";

      // bool ascendingOrder = false; // Change this to true or false as needed
            
      // Sort.SortCsv(filePath, 1, ascendingOrder);
      // Console.WriteLine($"CSV file sorted in {(ascendingOrder ? "ascending" : "descending")} order by the second column.");


      string filePath = "data.csv";
      Add.AddRecord(filePath);
      Reader.Read();


    } 
  }
}