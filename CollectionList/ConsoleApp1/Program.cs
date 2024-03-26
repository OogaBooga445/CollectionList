namespace connect
{
  class Program {

    public static void Main(string[] args) {
      // Adding.Add();
      // Reader.Read();
      //Registry.Register();
      // Log_in.Login();
      
      string filePath = "data.csv";
      Add.WriteToCsv(filePath);

    } 
  }
}